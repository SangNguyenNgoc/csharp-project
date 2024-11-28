﻿using BookingTour.App.Bus;
using BookingTour.App.Gui.Utils;
using BookingTour.App.Models;

namespace BookingTour.App.Gui.Account;

public partial class AccountForm : Form
{
    public AccountForm()
    {
        InitializeComponent();
        LoadUserData(null);
    }

    private void AccountForm_Load(object sender, EventArgs e)
    {
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        ScaleControls(this, scaleFactor);
    }

    private void ScaleControls(Control parent, float scaleFactor)
    {
        foreach (Control control in parent.Controls)
        {
            // // Điều chỉnh kích thước và vị trí của control
            // control.Width = (int)(control.Width * scaleFactor);
            // control.Height = (int)(control.Height * scaleFactor);
            // control.Location = new Point((int)(control.Location.X * scaleFactor),
            //     (int)(control.Location.Y * scaleFactor));
            //
            // Điều chỉnh riêng cho DataGridView
            if (control is DataGridView dataGridView)
            {
                // Scale font chữ
                dataGridView.Font = new Font(dataGridView.Font.FontFamily, dataGridView.Font.Size * scaleFactor);
        
                // Scale kích thước các hàng
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    row.Height = (int)(row.Height * scaleFactor);
                }
        
                // // Scale kích thước các cột
                // foreach (DataGridViewColumn column in dataGridView.Columns)
                // {
                //     column.Width = (int)(column.Width * scaleFactor);
                // }
        
                // Scale kích thước header
                dataGridView.ColumnHeadersHeight = (int)(dataGridView.ColumnHeadersHeight * scaleFactor);
                // dataGridView.RowHeadersWidth = (int)(dataGridView.RowHeadersWidth * scaleFactor);
            }
        
            // Điều chỉnh kích thước IconButton nếu cần
            if (control is FontAwesome.Sharp.IconButton iconButton)
            {
                iconButton.IconSize = (int)(iconButton.IconSize * scaleFactor);
            }
        
            // Nếu control có các con (children), gọi đệ quy
            if (control.HasChildren)
            {
                ScaleControls(control, scaleFactor);
            }
        }
    }


    public void LoadUserData(ICollection<User>? data)
    {
        dataGridView1.Rows.Clear();
        try
        {
            data ??= UserBus.Instance.GetAllUsers();

            foreach (var user in data)
            {
                dataGridView1.Rows.Add(
                    user.Id,
                    user.Username,
                    user.Name,
                    user.Email,
                    user.PhoneNumber,
                    user.IsBlock,
                    user.Role?.Name
                );
            }
        }
        catch (System.Exception ex)
        {
            // Hiển thị lỗi nếu có
            MessageBox.Show($@"Lỗi khi tải dữ liệu: {ex.Message}", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void createAccountButton_Click(object sender, EventArgs e)
    {
        var addAccountForm = new AddAccountForm(this, null);
        addAccountForm.Show();
    }

    // Sự kiện khi giá trị của checkbox thay đổi
    private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        //// Kiểm tra xem người dùng có thay đổi giá trị trong cột "IsBlock"
        //if (e.ColumnIndex == dataGridView1.Columns["IsBlock"].Index && e.RowIndex >= 0)
        //{
        //    bool isChecked = (bool)dataGridView1.Rows[e.RowIndex].Cells["IsBlock"].Value;
        //    // Xử lý khi giá trị checkbox thay đổi
        //    MessageBox.Show($"Checkbox at row {e.RowIndex} is {(isChecked ? "checked" : "unchecked")}");
        //}
    }

    private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if ((e.ColumnIndex == dataGridView1.Columns["IsBlock"]!.Index && e.RowIndex >= 0))
        {
            HandleBlockUser(e.RowIndex);
            return;
        }
        // ReSharper disable once InvertIf
        if (e.ColumnIndex == dataGridView1.Columns["Action"]!.Index && e.RowIndex >= 0)
        {
            HandleEditUser(e.RowIndex);
        }
    }

    private void HandleBlockUser(int rowIndex)
    {
        var isChecked = (bool)dataGridView1.Rows[rowIndex].Cells["IsBlock"].Value;
        var userId = (int)dataGridView1.Rows[rowIndex].Cells["Id"].Value;
        var confirmMessage = isChecked
            ? "Bạn có chắc chắn muốn kích hoạt người dùng này không?"
            : "Bạn có chắc chắn muốn vô hiệu hóa người dùng này không?";
        var dialogResult = MessageBox.Show(confirmMessage, @"Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (dialogResult != DialogResult.Yes)
        {
            dataGridView1.Rows[rowIndex].Cells["IsBlock"].Value = isChecked;
            return;
        }
        if (isChecked)
        {
            UserBus.Instance.EnableUser(userId);
        }
        else
        {
            UserBus.Instance.Disable(userId);
        }
        dataGridView1.Rows[rowIndex].Cells["IsBlock"].Value = !isChecked;
    }

    private void HandleEditUser(int rowIndex)
    {
        var userId = (int)dataGridView1.Rows[rowIndex].Cells["Id"].Value;
        // MessageBox.Show($@"Chỉnh sửa ID: {userId}", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        var addAccountForm = new AddAccountForm(this, userId);
        addAccountForm.Show();
    }

    private void searchButton_Click(object sender, EventArgs e)
    {
        var keywords = searchTextbox.Text.Trim().ToLower();
        var keywordList = keywords.Split(' ');
        var filteredData = UserBus.Instance.GetAllUsers().Where(user =>
            keywordList.All(keyword =>
                user.Username!.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                user.Name!.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                user.Email!.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                user.Role!.Name.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
            )
        ).ToList();

        // Hiển thị dữ liệu đã lọc
        LoadUserData(filteredData);
        searchTextbox.Text = "";
    }

    private void refreshButton_Click(object sender, EventArgs e)
    {
        LoadUserData(null);
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, dataGridView1.Font.Size * scaleFactor);
        
        // Scale kích thước các hàng
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            
            row.Height = (int)(row.Height * scaleFactor);
        }
    }

    private void titleLabel_Click(object sender, EventArgs e)
    {

    }
}