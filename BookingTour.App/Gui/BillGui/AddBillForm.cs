using Blazorise;
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

namespace BookingTour.App.Gui.BillGui;
public partial class AddBillForm : System.Windows.Forms.Form
{
    private readonly BillForm _parentForm;
    private readonly int? _billId;
    public AddBillForm(BillForm parentForm, int? billId)
    {
        InitializeComponent();
        _parentForm = parentForm;
        _billId = billId;
        LoadData(null, null);

    }
    public void LoadData(ICollection<Passenger>? data, ICollection<Tour>? data1)
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
        List<Passenger> selectedPassengers = GetSelectedPassengers();
        Tour tour = TourBus.Instance.GetById(GetSelectedTour());
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
                Tour tour = new Tour
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
}

