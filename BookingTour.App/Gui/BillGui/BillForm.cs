using BookingTour.App.Bus;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookingTour.App.Gui.Utils;

namespace BookingTour.App.Gui.BillGui;

using BookingTour.App.Gui.Account;
using BookingTour.App.Models;
public partial class BillForm : Form
{
    public BillForm()
    {
        InitializeComponent();
        LoadBillData(null);
        GuiUtils.ScaleControls(this, GuiUtils.GetScaleInScreen(this));
    }

    public void LoadBillData(ICollection<Bill>? data)
    {
        dgvBill.Rows.Clear();
        try
        {
            data ??= BillBus.Instance.GetAllBills();

            foreach (var bill in data)
            {
                dgvBill.Rows.Add(
                    bill.Id,
                    bill.TotalPassenger,
                    bill.TotalPrice,
                    bill.InvoiceIssuerNavigation.Name
                );
            }
        }
        catch (System.Exception ex)
        {
            // Hiển thị lỗi nếu có
            MessageBox.Show($@"Lỗi khi tải dữ liệu: {ex.Message}", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void createBillButton_Click(object sender, EventArgs e)
    {
        AddBillForm abf = new AddBillForm(this, null);
        abf.Show();
    }

    private void dgvBill_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == dgvBill.Columns["action"]!.Index && e.RowIndex >= 0)
        {
            HandleEditUser(e.RowIndex);
        }
    }

    private void HandleEditUser(int rowIndex)
    {
        var billId = (int)dgvBill.Rows[rowIndex].Cells["id"].Value;
        var addBillForm = new AddBillForm(this, billId);
        addBillForm.Show();
    }
}

