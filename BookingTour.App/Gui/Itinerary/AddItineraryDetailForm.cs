using BookingTour.App.Gui.Utils;

namespace BookingTour.App.Gui.Itinerary;

public partial class AddItineraryDetailForm : Form
{
    private NumericUpDown numDayNumber;
    private ComboBox cmbService, cmbActivity;
    private DateTimePicker dtpStartTime, dtpEndTime;
    private Button btnSave, btnCancel;

    public int? DayNumber { get; private set; }
    public int? ServiceId { get; private set; }
    public int ActivityId { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }

    public AddItineraryDetailForm(List<KeyValuePair<int, string>> services, List<KeyValuePair<int, string>> activities)
    {
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        this.Text = "Thêm/Chỉnh sửa chi tiết lịch trình";
        this.Size = new System.Drawing.Size((int)(500 * scaleFactor), (int) (500 * scaleFactor));
        this.StartPosition = FormStartPosition.CenterParent;

        int labelX = 20, inputX = 150, verticalSpacing = 40;
        int labelWidth = 120, inputWidth = 200, controlHeight = 30;

        Font labelFont = new Font("Arial", 12, FontStyle.Regular);
        Font inputFont = new Font("Arial", 12, FontStyle.Regular);

        // Label Day Number
        var lblDayNumber = new Label
        {
            Text = "Ngày thứ:",
            Font = labelFont,
            Location = new System.Drawing.Point(labelX, verticalSpacing),
            Size = new System.Drawing.Size(labelWidth, controlHeight)
        };
        this.Controls.Add(lblDayNumber);

        // NumericUpDown Day Number
        numDayNumber = new NumericUpDown
        {
            Location = new System.Drawing.Point(inputX, verticalSpacing),
            Font = inputFont,
            Minimum = 1,
            Maximum = 100,
            Size = new System.Drawing.Size(inputWidth, controlHeight)
        };
        this.Controls.Add(numDayNumber);

        // Label Service
        var lblService = new Label
        {
            Text = "Dịch vụ:",
            Font = labelFont,
            Location = new System.Drawing.Point(labelX, lblDayNumber.Bottom + verticalSpacing),
            Size = new System.Drawing.Size(labelWidth, controlHeight)
        };
        this.Controls.Add(lblService);

        // ComboBox Service
        cmbService = new ComboBox
        {
            Location = new System.Drawing.Point(inputX, lblDayNumber.Bottom + verticalSpacing),
            Font = inputFont,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Size = new System.Drawing.Size(inputWidth, controlHeight),
            DataSource = new BindingSource(services, null),
            DisplayMember = "Value",
            ValueMember = "Key"
        };
        this.Controls.Add(cmbService);

        // Label Activity
        var lblActivity = new Label
        {
            Text = "Hoạt động:",
            Font = labelFont,
            Location = new System.Drawing.Point(labelX, lblService.Bottom + verticalSpacing),
            Size = new System.Drawing.Size(labelWidth, controlHeight)
        };
        this.Controls.Add(lblActivity);

        // ComboBox Activity
        cmbActivity = new ComboBox
        {
            Location = new System.Drawing.Point(inputX, lblService.Bottom + verticalSpacing),
            Font = inputFont,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Size = new System.Drawing.Size(inputWidth, controlHeight),
            DataSource = new BindingSource(activities, null),
            DisplayMember = "Value",
            ValueMember = "Key"
        };
        this.Controls.Add(cmbActivity);

        // Label Start Time
        var lblStartTime = new Label
        {
            Text = "Giờ bắt đầu:",
            Font = labelFont,
            Location = new System.Drawing.Point(labelX, lblActivity.Bottom + verticalSpacing),
            Size = new System.Drawing.Size(labelWidth, controlHeight)
        };
        this.Controls.Add(lblStartTime);

        // DateTimePicker Start Time
        dtpStartTime = new DateTimePicker
        {
            Location = new System.Drawing.Point(inputX, lblActivity.Bottom + verticalSpacing),
            Font = inputFont,
            Format = DateTimePickerFormat.Time,
            ShowUpDown = true,
            Size = new System.Drawing.Size(inputWidth, controlHeight)
        };
        this.Controls.Add(dtpStartTime);

        // Label End Time
        var lblEndTime = new Label
        {
            Text = "Giờ kết thúc:",
            Font = labelFont,
            Location = new System.Drawing.Point(labelX, lblStartTime.Bottom + verticalSpacing),
            Size = new System.Drawing.Size(labelWidth, controlHeight)
        };
        this.Controls.Add(lblEndTime);

        // DateTimePicker End Time
        dtpEndTime = new DateTimePicker
        {
            Location = new System.Drawing.Point(inputX, lblStartTime.Bottom + verticalSpacing),
            Font = inputFont,
            Format = DateTimePickerFormat.Time,
            ShowUpDown = true,
            Size = new System.Drawing.Size(inputWidth, controlHeight)
        };
        this.Controls.Add(dtpEndTime);

        // Button Save
        btnSave = new Button
        {
            Text = "Lưu",
            Location = new System.Drawing.Point(100, dtpEndTime.Bottom + verticalSpacing),
            Font = new Font("Arial", 12, FontStyle.Bold),
            Size = new System.Drawing.Size(100, 40)
        };
        btnSave.Click += BtnSave_Click;
        this.Controls.Add(btnSave);

        // Button Cancel
        btnCancel = new Button
        {
            Text = "Hủy",
            Location = new System.Drawing.Point(220, dtpEndTime.Bottom + verticalSpacing),
            Font = new Font("Arial", 12, FontStyle.Bold),
            Size = new System.Drawing.Size(100, 40)
        };
        btnCancel.Click += (s, e) => this.Close();
        this.Controls.Add(btnCancel);
        
        GuiUtils.Scale(this, scaleFactor);
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        if (dtpStartTime.Value.TimeOfDay >= dtpEndTime.Value.TimeOfDay)
        {
            MessageBox.Show("Giờ bắt đầu phải trước giờ kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DayNumber = (int)numDayNumber.Value;
        ServiceId = (int)cmbService.SelectedValue;
        ActivityId = (int)cmbActivity.SelectedValue;
        StartTime = dtpStartTime.Value.TimeOfDay;
        EndTime = dtpEndTime.Value.TimeOfDay;

        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}