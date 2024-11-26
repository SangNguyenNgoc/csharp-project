using BookingTour.App.Bus;
using BookingTour.App.Models;
using ExcelDataReader;
using Google.Protobuf.Compiler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BookingTour.App.Gui.PassengerGui;

public partial class PassengerForm : Form
{
    public PassengerForm()
    {
        InitializeComponent();
        LoadPassengerData(null);
    }

    public void LoadPassengerData(ICollection<Passenger>? data)
    {
        dgvPassenger.Rows.Clear();
        try
        {
            data ??= PassengerBus.Instance.GetAllPassengers();

            foreach (var passenger in data)
            {
                dgvPassenger.Rows.Add(
                    passenger.Id,
                    passenger.Name,
                    passenger.Email,
                    passenger.PhoneNumber,
                    passenger.Age
                );
            }
        }
        catch (System.Exception ex)
        {
            // Hiển thị lỗi nếu có
            MessageBox.Show($@"Lỗi khi tải dữ liệu: {ex.Message}", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void createPassengerButton_Click(object sender, EventArgs e)
    {

    }
    DataSet result;
    private void ImportExcel_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog ofd = new OpenFileDialog()
        {
            Filter = "Excel Workbook|*.xls;*.xlsx",
            ValidateNames = true
        })
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Mở FileStream để đọc file
                    using (FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        // Đọc file Excel
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
                        {
                            // Chuyển đổi dữ liệu Excel thành DataSet
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true // Sử dụng hàng đầu tiên làm header
                                }
                            });

                            // Lấy DataTable đầu tiên
                            DataTable dataTable = result.Tables[0];

                            foreach (DataRow row in dataTable.Rows)
                            {
                                Passenger passenger = new Passenger()
                                {
                                    Id = Convert.ToInt32(row["id"]),
                                    Name = row["name"].ToString(),
                                    Email = row["email"].ToString(),
                                    PhoneNumber = row["phone_number"].ToString(),
                                    Age = Convert.ToInt32(row["age"])
                                };

                                PassengerBus.Instance.CreatePassenger(passenger);
                            }

                            LoadPassengerData(null);
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show($"Lỗi khi đọc file Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void ExportExcel_Click(object sender, EventArgs e)
    {
        DGV_To_Excel(dgvPassenger);
    }

    public void DGV_To_Excel(DataGridView dataGridView)
    {
        // Tạo ứng dụng Excel
        Excel.Application excelApp = new Excel.Application();
        if (excelApp == null)
        {
            MessageBox.Show("Excel chưa được cài đặt!");
            return;
        }

        // Tạo Workbook và Worksheet
        Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
        Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
        worksheet.Name = "ExportedData";

        // Xuất tiêu đề cột từ DataGridView
        for (int i = 1; i <= dataGridView.Columns.Count; i++)
        {
            worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
        }

        // Xuất dữ liệu từ DataGridView vào Excel
        for (int i = 0; i < dataGridView.Rows.Count; i++)
        {
            for (int j = 0; j < dataGridView.Columns.Count -1; j++)
            {
                if (dataGridView.Rows[i].Cells[j].Value != null)
                {
                    worksheet.Cells[i + 2, j + 1] = "'"+dataGridView.Rows[i].Cells[j].Value.ToString();
                }
                else
                {
                    worksheet.Cells[i + 2, j + 1] = "";
                }
            }
        }

        // Hiển thị ứng dụng Excel
        excelApp.Visible = true;

        // Giải phóng tài nguyên
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Marshal.ReleaseComObject(worksheet);
        Marshal.ReleaseComObject(workbook);
        Marshal.ReleaseComObject(excelApp);
    }
}

