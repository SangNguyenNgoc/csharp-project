using BookingTour.App.Bus;
using BookingTour.App.Context;
using BookingTour.App.Models;
using Session = BookingTour.App.Context.Session;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection.Metadata;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ExcelDataReader;

namespace BookingTour.App.Gui.BillGui;
public partial class AddBillForm : System.Windows.Forms.Form
{
    private readonly BillForm _parentForm;
    private readonly int? _billId;
    private string nameT;
    public AddBillForm(BillForm parentForm, int? billId)
    {
        InitializeComponent();
        _parentForm = parentForm;
        _billId = billId;
        LoadData(null, null);
        if (_billId != null)
        {
            InitData();
        }
    }
    private void InitData()
    {
        var bill = BillBus.Instance.GetBillById(_billId!.Value);
        var tour = TourBus.Instance.GetToursOfBill(_billId!.Value);
        var listpassengers = PassengerBus.Instance.GetPassengersOfBill(_billId!.Value);
        totalpriceTextbox.Text = bill.TotalPrice.ToString();
        userIdTextBox.Text = bill.InvoiceIssuer.ToString();
        foreach (DataGridViewRow row in dgvTour.Rows)
        {
            if (Convert.ToInt32(row.Cells["idTour"].Value) == tour.Id)
            {
                row.Cells["choose"].Value = true;
                nameT = Convert.ToString(row.Cells["nameTour"].Value);
            }
        }
        foreach (DataGridViewRow row in dgvPassenger.Rows)
        {
            foreach (Passenger passenger in listpassengers)
            {
                if (Convert.ToInt32(row.Cells["idKH"].Value) == passenger.Id)
                {
                    row.Cells["join"].Value = true;
                }
            }

        }
    }
    public void LoadData(ICollection<Passenger>? data, ICollection<Models.Tour>? data1)
    {
        dgvPassenger.Rows.Clear();
        try
        {
            data ??= PassengerBus.Instance.GetAllPassengers();

            foreach (var passenger in data)
            {
                dgvPassenger.Rows.Add(
                    passenger.Id,
                    passenger.Name
                );
            }
        }
        catch (System.Exception ex)
        {
            // Hiển thị lỗi nếu có
            MessageBox.Show($@"Lỗi khi tải dữ liệu: {ex.Message}", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        dgvTour.Rows.Clear();
        try
        {
            data1 ??= TourBus.Instance.GetAllForBill();

            foreach (var tour in data1)
            {
                dgvTour.Rows.Add(
                    tour.Id,
                    tour.Itinerary?.Name,
                    tour.Price
                );
            }
        }
        catch (System.Exception ex)
        {
            // Hiển thị lỗi nếu có
            MessageBox.Show($@"Lỗi khi tải dữ liệu: {ex.Message}", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvTour_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        // Kiểm tra nếu ô thay đổi là checkbox
        if (e.RowIndex >= 0 && e.ColumnIndex == dgvTour.Columns["choose"].Index)
        {
            var cell = dgvTour.Rows[e.RowIndex].Cells["choose"];
            if (cell != null)
            {
                var isChecked = Convert.ToBoolean(cell.Value);

                if (isChecked)
                {
                    // Nếu checkbox được chọn, bỏ chọn tất cả các checkbox khác
                    foreach (DataGridViewRow row in dgvTour.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            row.Cells["choose"].Value = false;
                        }
                    }
                }
            }

        }
    }

    private void dgvTour_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (dgvTour.CurrentCell is DataGridViewCheckBoxCell)
        {
            dgvTour.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }

    private void UpdateTotalPrice()
    {
        decimal totalPrice = 0;
        int selectedPassengerCount = 0;

        // Đếm số khách hàng đã chọn
        foreach (DataGridViewRow row in dgvPassenger.Rows)
        {
            if (Convert.ToBoolean(row.Cells["join"].Value) == true)
            {
                selectedPassengerCount += 1;
            }
        }

        decimal selectedPrice = 0;

        // Kiểm tra dòng trong dgvTour có checkbox được chọn
        foreach (DataGridViewRow row in dgvTour.Rows)
        {
            if (Convert.ToBoolean(row.Cells["choose"].Value))
            {
                // Lấy giá trị từ cột "Giá" của dòng được chọn
                selectedPrice = Convert.ToDecimal(row.Cells["price"].Value);
            }
        }

        // Tính tổng tiền = số lượng khách hàng * giá trị của tour
        totalPrice = selectedPassengerCount * selectedPrice;

        // Hiển thị tổng tiền vào TextBox
        totalpriceTextbox.Text = totalPrice.ToString();
    }

    private void dgvTour_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex == dgvTour.Columns["choose"].Index)
        {
            UpdateTotalPrice();
        }
    }

    private void dgvPassenger_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex == dgvPassenger.Columns["join"].Index)
        {
            UpdateTotalPrice();
        }
    }

    private void AddBillForm_Load(object sender, EventArgs e)
    {
        userIdTextBox.Text = Session.Get<Models.User>("CurrentUser")?.Name;
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        if (_billId == null)
        {
            List<Passenger> selectedPassengers = GetSelectedPassengers();
            Models.Tour tour = TourBus.Instance.GetById(GetSelectedTour());
            Bill bill = new Bill
            {
                TotalPassenger = selectedPassengers.Count,
                TotalPrice = Convert.ToInt32(totalpriceTextbox.Text),
                InvoiceIssuer = Convert.ToInt32(Session.Get<Models.User>("CurrentUser")?.Id),
            };
            int billId = BillBus.Instance.CreateBill(bill);

            foreach (var passenger in selectedPassengers)
            {
                Ticket ticket = new Ticket
                {
                    Price = Convert.ToInt32(tour.Price),
                    PassengerId = passenger.Id,
                    BillId = billId,
                    TourId = tour.Id,
                };
                TicketBus.Instance.CreateTicket(ticket);
            }

            MessageBox.Show(@"Hóa đơn thêm thành công!", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetParentForm();
            this.Close();
        }
        else
        {
            TicketBus.Instance.DeleteTicketByBillId(_billId!.Value);
            List<Passenger> selectedPassengers = GetSelectedPassengers();
            Models.Tour tour = TourBus.Instance.GetById(GetSelectedTour());
            Bill bill = new Bill
            {
                Id = _billId!.Value,
                TotalPassenger = selectedPassengers.Count,
                TotalPrice = Convert.ToInt32(totalpriceTextbox.Text),
                InvoiceIssuer = Convert.ToInt32(Session.Get<Models.User>("CurrentUser")?.Id),
            };
            BillBus.Instance.UpdateBill(bill);

            foreach (var passenger in selectedPassengers)
            {
                Ticket ticket = new Ticket
                {
                    Price = Convert.ToInt32(tour.Price),
                    PassengerId = passenger.Id,
                    BillId = _billId,
                    TourId = tour.Id,
                };
                TicketBus.Instance.CreateTicket(ticket);
            }

            MessageBox.Show(@"Hóa đơn sửa thành công!", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetParentForm();
            this.Close();
        }
    }
    private void ResetParentForm()
    {
        _parentForm?.LoadBillData(null);
    }
    private List<Passenger> GetSelectedPassengers()
    {
        List<Passenger> selectedPassengers = new List<Passenger>();

        // Duyệt qua tất cả các dòng trong dgvPassenger
        foreach (DataGridViewRow row in dgvPassenger.Rows)
        {
            // Kiểm tra xem khách hàng có được chọn không (checkbox "join")
            if (Convert.ToBoolean(row.Cells["join"].Value) == true)
            {
                Passenger passenger = new Passenger
                {
                    Id = Convert.ToInt32(row.Cells["idKH"].Value),
                    Name = row.Cells["name"].Value.ToString(),

                };

                // Thêm vào danh sách các khách hàng đã chọn
                selectedPassengers.Add(passenger);
            }
        }

        return selectedPassengers;
    }
    private int GetSelectedTour()
    {
        // Duyệt qua tất cả các dòng trong dgvPassenger
        foreach (DataGridViewRow row in dgvTour.Rows)
        {
            // Kiểm tra xem khách hàng có được chọn không (checkbox "join")
            if (Convert.ToBoolean(row.Cells["choose"].Value) == true)
            {
                Models.Tour tour = new Models.Tour
                {
                    Id = Convert.ToInt32(row.Cells["idTour"].Value),
                    Price = Convert.ToInt32(row.Cells["price"].Value),

                };
                return tour.Id;
            }
        }

        return -1;
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void buttonPDF_Click(object sender, EventArgs e)
    {
        if (_billId != null)
        {
            List<Passenger> selectedPassengers = GetSelectedPassengers();
            Models.Tour tour = TourBus.Instance.GetById(GetSelectedTour());
            var bill = BillBus.Instance.GetBillById(_billId!.Value);
            try
            {
                iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(document, new FileStream("E:/abc.pdf", FileMode.Create));

                document.Open();
                // Font định dạng
                iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                iTextSharp.text.Font regularFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                iTextSharp.text.Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

                // Thêm tiêu đề hóa đơn
                document.Add(new Paragraph("--- Bill ---", headerFont) { Alignment = Element.ALIGN_CENTER });
                document.Add(new Paragraph("\n"));

                // Thông tin hóa đơn
                document.Add(new Paragraph($"Nguoi Lap: {Session.Get<Models.User>("CurrentUser")?.Name}", regularFont));
                document.Add(new Paragraph($"Total Passenger: {bill.TotalPassenger}", regularFont));
                document.Add(new Paragraph($"Total Price: {bill.TotalPrice}", regularFont));
                document.Add(new Paragraph("-------------------------------------------", regularFont));
                document.Add(new Paragraph("\n"));

                // Thêm bảng hành khách
                PdfPTable table = new PdfPTable(3);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 3, 2, 2 }); // Tỷ lệ các cột

                // Thêm tiêu đề bảng
                table.AddCell(new PdfPCell(new Phrase("Mã Khách Hàng")) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Tên Khách Hàng")) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Giá vé")) { HorizontalAlignment = Element.ALIGN_CENTER });

                // Thêm dữ liệu vào bảng
                foreach (Passenger passenger in selectedPassengers)
                {
                    table.AddCell($"{passenger.Id}");
                    table.AddCell($"{passenger.Name}");
                    table.AddCell($"{tour.Price}");
                }

                // Thêm bảng vào tài liệu
                document.Add(table);

                document.Add(new Paragraph("\n-------------------------------------------", regularFont));
                document.Add(new Paragraph("\n"));

                // Thông tin tour
                document.Add(new Paragraph($"Tên tour: {nameT}", regularFont));
                document.Add(new Paragraph($"Ngày khởi hành: {tour.DateStart}", regularFont));
                document.Add(new Paragraph($"Ngày kết thúc: {tour.DateStart}", regularFont));
                // Đóng tài liệu
                document.Close();
            }
            catch (PdfException ex)
            {
                Console.WriteLine("Error creating PDF: " + ex.Message);
            }
        }
        else
        {
            MessageBox.Show("Hóa đơn chưa được lưu trong Database");
        }
    }

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
                            var listpassengers = new List<Passenger>(); 
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
                                
                                int lastid = PassengerBus.Instance.CreatePassengerLastId(passenger);
                                passenger.Id = lastid;
                                listpassengers.Add(passenger);
                            }

                            LoadData(null,null);
                            foreach (DataGridViewRow row in dgvPassenger.Rows)
                            {
                                foreach (Passenger passenger in listpassengers)
                                {
                                    if (Convert.ToInt32(row.Cells["idKH"].Value) == passenger.Id)
                                    {
                                        row.Cells["join"].Value = true;
                                    }
                                }

                            }
                            
                            
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
}

