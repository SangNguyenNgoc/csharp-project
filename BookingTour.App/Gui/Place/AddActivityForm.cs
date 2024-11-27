using BookingTour.App.Bus;
using BookingTour.App.Gui.Utils;

namespace BookingTour.App.Gui.Place;

public partial class AddActivityForm : Form
{
    public string ActivityName { get; private set; } = string.Empty;
    public string ActivityDescription { get; private set; } = string.Empty;

    public AddActivityForm(int? activityId)
    {
        InitializeComponent();
        Text = @"Thêm hoạt động";

        // Tạo giao diện
        var nameLabel = new Label { Text = @"Tên hoạt động:", Top = 20, Left = 20, AutoSize = true };
        var nameTextBox = new TextBox { Top = 50, Left = 20, Width = 300 };

        var descriptionLabel = new Label { Text = @"Mô tả hoạt động:", Top = 90, Left = 20, AutoSize = true };
        var descriptionTextBox = new TextBox { Top = 120, Left = 20, Width = 300, Height = 100, Multiline = true };

        var okButton = new Button { Text = @"Đồng ý", Top = 240, Left = 20, Width = 100 };
        var cancelButton = new Button { Text = @"Hủy", Top = 240, Left = 140, Width = 100 };

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
                MessageBox.Show(@"Tên hoạt động không được để trống!", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTextBox.Focus();
                return;
            }

            if (ActivityName.Length > 50)
            {
                MessageBox.Show(@"Tên hoạt động không được vượt quá 50 ký tự!", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ActivityDescription))
            {
                MessageBox.Show(@"Mô tả hoạt động không được để trống!", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                descriptionTextBox.Focus();
                return;
            }

            if (ActivityDescription.Length > 500)
            {
                MessageBox.Show(@"Mô tả hoạt động không được vượt quá 500 ký tự!", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                descriptionTextBox.Focus();
                return;
            }

            // Dữ liệu hợp lệ
            DialogResult = DialogResult.OK;
            Close();
        };

        // Xử lý khi nhấn nút Hủy
        cancelButton.Click += (sender, e) =>
        {
            DialogResult = DialogResult.Cancel;
            Close();
        };

        Controls.Add(nameLabel);
        Controls.Add(nameTextBox);
        Controls.Add(descriptionLabel);
        Controls.Add(descriptionTextBox);
        Controls.Add(okButton);
        Controls.Add(cancelButton);

        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        Size = new Size((int)(500 * scaleFactor),(int) (400 * scaleFactor));        
        ScaleControls(this, scaleFactor);
        StartPosition = FormStartPosition.CenterParent;
    }
    
    private void ScaleControls(Control parent, float scaleFactor)
    {
        foreach (Control control in parent.Controls)
        {
            // Điều chỉnh kích thước và vị trí
            control.Width = (int)(control.Width * scaleFactor);
            control.Height = (int)(control.Height * scaleFactor);
            control.Location = new Point((int)(control.Location.X * scaleFactor),
                (int)(control.Location.Y * scaleFactor));


            if (control is FontAwesome.Sharp.IconButton iconButton)
            {
                iconButton.IconSize = (int)(iconButton.IconSize * scaleFactor);
            }

            // Nếu control có children, gọi đệ quy
            if (control.HasChildren)
            {
                ScaleControls(control, scaleFactor);
            }
        }
    }

    public sealed override string Text
    {
        get => base.Text;
        set => base.Text = value;
    }
}
