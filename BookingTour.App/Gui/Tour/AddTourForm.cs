using BookingTour.App.Gui.Utils;

namespace BookingTour.App.Gui.Tour;

public partial class AddTourForm : Form
{
    private DateTimePicker dtpStartDate;
    private DateTimePicker dtpEndDate;
    private TextBox txtPrice;
    private Button btnOk;
    private Button btnCancel;

    public DateOnly? StartDate { get; private set; }
    public DateOnly? EndDate { get; private set; }
    public int? Price { get; private set; }

    public AddTourForm()
    {
        this.Text = "Nhập thông tin khoảng thời gian và giá";
        this.Size = new System.Drawing.Size(400, 300);
        this.StartPosition = FormStartPosition.CenterParent;

        int labelX = 20;
        int inputX = 150;
        int verticalSpacing = 30;
        int controlHeight = 30;
        int labelWidth = 120;
        int inputWidth = 200;

        Font labelFont = new Font("Arial", 12, FontStyle.Regular);
        Font inputFont = new Font("Arial", 12, FontStyle.Regular);

        // Label Start Date
        var lblStartDate = new Label
        {
            Text = "Ngày bắt đầu:",
            Font = labelFont,
            Location = new System.Drawing.Point(labelX, verticalSpacing),
            Size = new System.Drawing.Size(labelWidth, controlHeight)
        };
        this.Controls.Add(lblStartDate);

        // DateTimePicker Start Date
        dtpStartDate = new DateTimePicker
        {
            Location = new System.Drawing.Point(inputX, verticalSpacing),
            Font = inputFont,
            Format = DateTimePickerFormat.Short,
            Size = new System.Drawing.Size(inputWidth, controlHeight)
        };
        this.Controls.Add(dtpStartDate);

        // Label End Date
        var lblEndDate = new Label
        {
            Text = "Ngày kết thúc:",
            Font = labelFont,
            Location = new System.Drawing.Point(labelX, lblStartDate.Bottom + verticalSpacing),
            Size = new System.Drawing.Size(labelWidth, controlHeight)
        };
        this.Controls.Add(lblEndDate);

        // DateTimePicker End Date
        dtpEndDate = new DateTimePicker
        {
            Location = new System.Drawing.Point(inputX, lblStartDate.Bottom + verticalSpacing),
            Font = inputFont,
            Format = DateTimePickerFormat.Short,
            Size = new System.Drawing.Size(inputWidth, controlHeight)
        };
        this.Controls.Add(dtpEndDate);

        // Label Price
        var lblPrice = new Label
        {
            Text = "Giá tiền:",
            Font = labelFont,
            Location = new System.Drawing.Point(labelX, lblEndDate.Bottom + verticalSpacing),
            Size = new System.Drawing.Size(labelWidth, controlHeight)
        };
        this.Controls.Add(lblPrice);

        // TextBox Price
        txtPrice = new TextBox
        {
            Location = new System.Drawing.Point(inputX, lblEndDate.Bottom + verticalSpacing),
            Font = inputFont,
            Size = new System.Drawing.Size(inputWidth, controlHeight)
        };
        this.Controls.Add(txtPrice);

        // Button OK
        btnOk = new Button
        {
            Text = "OK",
            Location = new System.Drawing.Point(80, txtPrice.Bottom + verticalSpacing),
            Font = new Font("Arial", 12, FontStyle.Bold),
            Size = new System.Drawing.Size(100, 40)
        };
        btnOk.Click += BtnOk_Click;
        this.Controls.Add(btnOk);

        // Button Cancel
        btnCancel = new Button
        {
            Text = "Hủy",
            Location = new System.Drawing.Point(200, txtPrice.Bottom + verticalSpacing),
            Font = new Font("Arial", 12, FontStyle.Bold),
            Size = new System.Drawing.Size(100, 40)
        };
        btnCancel.Click += (s, e) => this.Close();
        this.Controls.Add(btnCancel);
    }

    private void BtnOk_Click(object sender, EventArgs e)
    {
        var start = DateOnly.FromDateTime(dtpStartDate.Value);
        var end = DateOnly.FromDateTime(dtpEndDate.Value);

        if (start > end)
        {
            MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Kiểm tra giá tiền hợp lệ
        if (string.IsNullOrWhiteSpace(txtPrice.Text) || !int.TryParse(txtPrice.Text, out var price) || price < 0)
        {
            MessageBox.Show("Vui lòng nhập giá tiền hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        StartDate = start;
        EndDate = end;
        Price = price;

        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}