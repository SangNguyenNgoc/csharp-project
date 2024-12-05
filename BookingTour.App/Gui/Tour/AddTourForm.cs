using BookingTour.App.Gui.Utils;
using BookingTour.App.Models;

namespace BookingTour.App.Gui.Tour;

public partial class AddTourForm : Form
{
    private readonly DateTimePicker _dtpStartDate;
    private readonly TextBox _txtPrice;
    private readonly ComboBox _cbGuide;
    private readonly Button _btnOk;
    private readonly Button _btnCancel;

    public DateOnly? StartDate { get; private set; }
    public int? Price { get; private set; }
    public int? SelectedGuide { get; private set; } // Lưu hướng dẫn viên được chọn

    public AddTourForm(List<Models.Guide> guides)
    {
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        Text = "Nhập thông tin khoảng thời gian, giá và hướng dẫn viên";
        Size = new Size((int)(400 * scaleFactor), (int)(400 * scaleFactor)); // Tăng chiều cao form để chứa ComboBox
        StartPosition = FormStartPosition.CenterParent;

        const int labelX = 20;
        const int inputX = 150;
        const int verticalSpacing = 30;
        const int controlHeight = 30;
        const int labelWidth = 120;
        const int inputWidth = 200;

        var labelFont = new Font("Arial", 12, FontStyle.Regular);
        var inputFont = new Font("Arial", 12, FontStyle.Regular);

        // Label Start Date
        var lblStartDate = new Label
        {
            Text = "Ngày bắt đầu:",
            Font = labelFont,
            Location = new Point(labelX, verticalSpacing),
            Size = new Size(labelWidth, controlHeight)
        };
        Controls.Add(lblStartDate);

        // DateTimePicker Start Date
        _dtpStartDate = new DateTimePicker
        {
            Location = new Point(inputX, verticalSpacing),
            Font = inputFont,
            Format = DateTimePickerFormat.Short,
            Size = new Size(inputWidth, controlHeight)
        };
        Controls.Add(_dtpStartDate);

        // Label Price
        var lblPrice = new Label
        {
            Text = "Giá tiền:",
            Font = labelFont,
            Location = new Point(labelX, lblStartDate.Bottom + verticalSpacing),
            Size = new Size(labelWidth, controlHeight)
        };
        Controls.Add(lblPrice);

        // TextBox Price
        _txtPrice = new TextBox
        {
            Location = new Point(inputX, lblStartDate.Bottom + verticalSpacing),
            Font = inputFont,
            Size = new Size(inputWidth, controlHeight)
        };
        Controls.Add(_txtPrice);

        // Label Guide
        var lblGuide = new Label
        {
            Text = "HDV:",
            Font = labelFont,
            Location = new Point(labelX, _txtPrice.Bottom + verticalSpacing),
            Size = new Size(labelWidth, controlHeight)
        };
        Controls.Add(lblGuide);

        // ComboBox Guide
        _cbGuide = new ComboBox
        {
            Location = new Point(inputX, _txtPrice.Bottom + verticalSpacing),
            Font = inputFont,
            Size = new Size(inputWidth, controlHeight),
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        _cbGuide.DataSource = guides;
        _cbGuide.DisplayMember = "FullName";
        _cbGuide.ValueMember = "Id";
        Controls.Add(_cbGuide);

        // Button OK
        _btnOk = new Button
        {
            Text = "OK",
            Location = new Point(80, _cbGuide.Bottom + verticalSpacing),
            Font = new Font("Arial", 12, FontStyle.Bold),
            Size = new Size(100, 40)
        };
        _btnOk.Click += BtnOk_Click;
        Controls.Add(_btnOk);

        // Button Cancel
        _btnCancel = new Button
        {
            Text = "Hủy",
            Location = new Point(200, _cbGuide.Bottom + verticalSpacing),
            Font = new Font("Arial", 12, FontStyle.Bold),
            Size = new Size(100, 40)
        };
        _btnCancel.Click += (s, e) => Close();
        Controls.Add(_btnCancel);
        
        GuiUtils.Scale(this, scaleFactor);
    }

    public sealed override string Text
    {
        get { return base.Text; }
        set { base.Text = value; }
    }

    private void BtnOk_Click(object? sender, EventArgs e)
    {
        var start = DateOnly.FromDateTime(_dtpStartDate.Value);
        if (string.IsNullOrWhiteSpace(_txtPrice.Text) || !int.TryParse(_txtPrice.Text, out var price) || price < 0)
        {
            MessageBox.Show("Vui lòng nhập giá tiền hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (_cbGuide.SelectedItem == null)
        {
            MessageBox.Show("Vui lòng chọn hướng dẫn viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        StartDate = start;
        Price = price;
        SelectedGuide = (int) _cbGuide.SelectedValue!;
        
        Console.WriteLine(SelectedGuide);

        DialogResult = DialogResult.OK;
        Close();
    }
}