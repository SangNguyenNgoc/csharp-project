using BookingTour.App.Bus;
using BookingTour.App.Gui.Utils;

namespace BookingTour.App.Gui.Service;

public partial class AddServiceForm : Form
{
    private readonly TextBox _txtName;
    private readonly ComboBox _cmbType;
    private readonly TextBox _txtDescription;
    private readonly Button _btnOk;

    public string? ServiceName { get; private set; }
    public string? ServiceType { get; private set; }
    public string? ServiceDescription { get; private set; }

    public AddServiceForm(List<string> types, Models.Service? data)
    {
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        Text = @"Nhập thông tin dịch vụ";
        Size = new Size((int)(500 * scaleFactor),(int) (400 * scaleFactor));
        StartPosition = FormStartPosition.CenterParent;

        const int labelX = 20;
        const int inputX = 150;
        const int verticalSpacing = 30; // Khoảng cách giữa các thành phần
        const int controlHeight = 40; // Tăng chiều cao của các control

        // Tăng kích thước font
        var labelFont = new Font("Arial", 12, FontStyle.Regular);
        var inputFont = new Font("Arial", 12, FontStyle.Regular);
        var buttonFont = new Font("Arial", 12, FontStyle.Bold);

        // Label Name
        var lblName = new Label
        {
            Text = @"Tên dịch vụ:",
            Location = new Point(labelX, verticalSpacing),
            AutoSize = true,
            Font = labelFont // Set font
        };
        Controls.Add(lblName);

        // TextBox Name
        _txtName = new TextBox
        {
            Location = new Point(inputX, verticalSpacing - 5),
            Width = 300,
            Height = controlHeight,
            Font = inputFont // Set font
        };
        Controls.Add(_txtName);

        // Label Type
        var lblType = new Label
        {
            Text = @"Loại:",
            Location = new Point(labelX, lblName.Bottom + verticalSpacing),
            AutoSize = true,
            Font = labelFont // Set font
        };
        Controls.Add(lblType);

        // ComboBox Type
        _cmbType = new ComboBox
        {
            Location = new Point(inputX, lblName.Bottom + verticalSpacing - 5),
            Width = 300,
            Height = controlHeight,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Font = inputFont // Set font
        };
        _cmbType.Items.AddRange(types.ToArray());
        Controls.Add(_cmbType);

        // Label Description
        var lblDescription = new Label
        {
            Text = @"Mô tả:",
            Location = new Point(labelX, lblType.Bottom + verticalSpacing),
            AutoSize = true,
            Font = labelFont // Set font
        };
        Controls.Add(lblDescription);

        // TextBox Description (Multiline)
        _txtDescription = new TextBox
        {
            Location = new Point(inputX, lblType.Bottom + verticalSpacing - 5),
            Width = 300,
            Height = 120,
            Multiline = true,
            ScrollBars = ScrollBars.Vertical,
            Font = inputFont // Set font
        };
        Controls.Add(_txtDescription);

        // Button OK
        _btnOk = new Button
        {
            Text = @"Lưu",
            Location = new Point(150, _txtDescription.Bottom + verticalSpacing),
            Width = 100,
            Height = 40,
            Font = buttonFont, // Set font
            DialogResult = DialogResult.OK
        };
        _btnOk.Click += BtnOk_Click;
        Controls.Add(_btnOk);

        // Button Cancel
        var btnCancel = new Button
        {
            Text = @"Hủy",
            Location = new Point(270, _txtDescription.Bottom + verticalSpacing),
            Width = 100,
            Height = 40,
            Font = buttonFont, // Set font
            DialogResult = DialogResult.Cancel
        };
        Controls.Add(btnCancel);
        
        ScaleControls(this, scaleFactor);

        if (data == null) return;
        _txtName.Text = data.Name;
        _txtDescription.Text = data.Description;
        _cmbType.Text = data.Type;
    }

    public sealed override string Text
    {
        get => base.Text;
        set => base.Text = value;
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

    private void BtnOk_Click(object? sender, EventArgs e)
    {
        // Kiểm tra đầu vào hợp lệ
        if (string.IsNullOrWhiteSpace(_txtName.Text))
        {
            MessageBox.Show(@"Vui lòng nhập tên dịch vụ!", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (_cmbType.SelectedIndex == -1)
        {
            MessageBox.Show(@"Vui lòng chọn loại dịch vụ!", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (string.IsNullOrWhiteSpace(_txtDescription.Text))
        {
            MessageBox.Show(@"Vui lòng nhập mô tả dịch vụ!", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Lưu dữ liệu
        ServiceName = _txtName.Text.Trim();
        ServiceType = _cmbType.SelectedItem?.ToString();
        ServiceDescription = _txtDescription.Text.Trim();
        DialogResult = DialogResult.OK;
        Close();
    }
}