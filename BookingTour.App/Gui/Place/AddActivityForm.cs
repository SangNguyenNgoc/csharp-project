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

namespace BookingTour.App.Gui.Place;

public partial class AddActivityForm : Form
{
    public string ActivityName { get; private set; } = string.Empty;
    public string ActivityDescription { get; private set; } = string.Empty;

    public AddActivityForm(int? activityId)
    {
        InitializeComponent();

        this.Text = "Thêm hoạt động";

        // Tạo giao diện
        var nameLabel = new Label { Text = "Tên hoạt động:", Top = 20, Left = 20, AutoSize = true };
        var nameTextBox = new TextBox { Top = 50, Left = 20, Width = 300 };

        var descriptionLabel = new Label { Text = "Mô tả hoạt động:", Top = 90, Left = 20, AutoSize = true };
        var descriptionTextBox = new TextBox { Top = 120, Left = 20, Width = 300, Height = 100, Multiline = true };

        var okButton = new Button { Text = "Đồng ý", Top = 240, Left = 20, Width = 100 };
        var cancelButton = new Button { Text = "Hủy", Top = 240, Left = 140, Width = 100 };

        if(activityId != null)
        {
            var activity = ActivityBus.Instance.GetActivityById(activityId.Value);
            nameTextBox.Text = activity!.Name;
            descriptionTextBox.Text = activity.Description;
        }

        // Xử lý khi nhấn nút Đồng ý
        okButton.Click += (sender, e) =>
        {
            // Lấy dữ liệu nhập
            ActivityName = nameTextBox.Text.Trim();
            ActivityDescription = descriptionTextBox.Text.Trim();

            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(ActivityName))
            {
                MessageBox.Show("Tên hoạt động không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTextBox.Focus();
                return;
            }

            if (ActivityName.Length > 50)
            {
                MessageBox.Show("Tên hoạt động không được vượt quá 50 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ActivityDescription))
            {
                MessageBox.Show("Mô tả hoạt động không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                descriptionTextBox.Focus();
                return;
            }

            if (ActivityDescription.Length > 500)
            {
                MessageBox.Show("Mô tả hoạt động không được vượt quá 500 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                descriptionTextBox.Focus();
                return;
            }

            // Dữ liệu hợp lệ
            this.DialogResult = DialogResult.OK;
            this.Close();
        };

        // Xử lý khi nhấn nút Hủy
        cancelButton.Click += (sender, e) =>
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        };

        this.Controls.Add(nameLabel);
        this.Controls.Add(nameTextBox);
        this.Controls.Add(descriptionLabel);
        this.Controls.Add(descriptionTextBox);
        this.Controls.Add(okButton);
        this.Controls.Add(cancelButton);

        this.Size = new Size(400, 350);
        this.StartPosition = FormStartPosition.CenterParent;
    }

}
