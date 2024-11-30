using BookingTour.App.Bus;
using BookingTour.App.Gui.Tour;
using BookingTour.App.Gui.Utils;
using BookingTour.App.Models;

namespace BookingTour.App.Gui.Itinerary;

public partial class AddItineraryForm : Form
{
    private TextBox txtName;
    private NumericUpDown nudNumberOfDays;
    private ComboBox cmbVehicle;
    private TextBox txtDescription;
    private NumericUpDown nudCapacity;
    private Button btnOk;
    private Button btnCancel;
    private Button addTourButton;
    private Button viewDetailButton;

    private Models.Itinerary? Data;

    public string? ItineraryName { get; private set; }
    public int? NumberOfDays { get; private set; }
    public string? Vehicle { get; private set; }
    public string? Description { get; private set; }
    public int? Capacity { get; private set; }

    public AddItineraryForm(List<string> vehicles, Models.Itinerary? data)
    {
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        this.Text = "Nhập thông tin lịch trình";
        this.Size = new System.Drawing.Size((int)(450*scaleFactor), (int) (450 * scaleFactor));
        this.StartPosition = FormStartPosition.CenterParent;

        int labelX = 20;
        int inputX = 150;
        int verticalSpacing = 20; // Giảm khoảng cách dọc
        int controlHeight = 30;
        int labelWidth = 120;
        int inputWidth = 250;

        Font labelFont = new Font("Arial", 12, FontStyle.Regular);
        Font inputFont = new Font("Arial", 12, FontStyle.Regular);

        // Label Name
        var lblName = new Label
        {
            Text = "Tên:",
            Font = labelFont,
            Location = new System.Drawing.Point(labelX, verticalSpacing),
            Size = new System.Drawing.Size(labelWidth, controlHeight)
        };
        this.Controls.Add(lblName);

        // TextBox Name
        txtName = new TextBox
        {
            Location = new System.Drawing.Point(inputX, verticalSpacing),
            Font = inputFont,
            Size = new System.Drawing.Size(inputWidth, controlHeight)
        };
        this.Controls.Add(txtName);

        // Label NumberOfDays
        var lblNumberOfDays = new Label
        {
            Text = "Số ngày:",
            Font = labelFont,
            Location = new System.Drawing.Point(labelX, lblName.Bottom + verticalSpacing),
            Size = new System.Drawing.Size(labelWidth, controlHeight)
        };
        this.Controls.Add(lblNumberOfDays);

        // NumericUpDown NumberOfDays
        nudNumberOfDays = new NumericUpDown
        {
            Location = new System.Drawing.Point(inputX, lblName.Bottom + verticalSpacing),
            Font = inputFont,
            Minimum = 1,
            Maximum = 365,
            Size = new System.Drawing.Size(inputWidth, controlHeight)
        };
        this.Controls.Add(nudNumberOfDays);

        // Label Vehicle
        var lblVehicle = new Label
        {
            Text = "Phương tiện:",
            Font = labelFont,
            Location = new System.Drawing.Point(labelX, lblNumberOfDays.Bottom + verticalSpacing),
            Size = new System.Drawing.Size(labelWidth, controlHeight)
        };
        this.Controls.Add(lblVehicle);

        // ComboBox Vehicle
        cmbVehicle = new ComboBox
        {
            Location = new System.Drawing.Point(inputX, lblNumberOfDays.Bottom + verticalSpacing),
            Font = inputFont,
            Size = new System.Drawing.Size(inputWidth, controlHeight),
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        cmbVehicle.Items.AddRange(vehicles.ToArray());
        this.Controls.Add(cmbVehicle);

        // Label Description
        var lblDescription = new Label
        {
            Text = "Mô tả:",
            Font = labelFont,
            Location = new System.Drawing.Point(labelX, lblVehicle.Bottom + verticalSpacing),
            Size = new System.Drawing.Size(labelWidth, controlHeight)
        };
        this.Controls.Add(lblDescription);

        // TextBox Description
        txtDescription = new TextBox
        {
            Location = new System.Drawing.Point(inputX, lblVehicle.Bottom + verticalSpacing),
            Font = inputFont,
            Size = new System.Drawing.Size(inputWidth, 80), // Giảm chiều cao mô tả
            Multiline = true,
            ScrollBars = ScrollBars.Vertical
        };
        this.Controls.Add(txtDescription);

        // Label Capacity
        var lblCapacity = new Label
        {
            Text = "Số lượng:",
            Font = labelFont,
            Location = new System.Drawing.Point(labelX, txtDescription.Bottom + verticalSpacing),
            Size = new System.Drawing.Size(labelWidth, controlHeight)
        };
        this.Controls.Add(lblCapacity);

        // NumericUpDown Capacity
        nudCapacity = new NumericUpDown
        {
            Location = new System.Drawing.Point(inputX, txtDescription.Bottom + verticalSpacing),
            Font = inputFont,
            Minimum = 1,
            Maximum = 1000,
            Size = new System.Drawing.Size(inputWidth, controlHeight)
        };
        this.Controls.Add(nudCapacity);

        // Button OK
        btnOk = new Button
        {
            Text = "Lưu",
            Location = new System.Drawing.Point(20, nudCapacity.Bottom + verticalSpacing),
            Font = new Font("Arial", 12, FontStyle.Bold), // Tăng kích cỡ chữ cho nút
            Size = new System.Drawing.Size(100, 40) // Tăng kích thước nút
        };
        btnOk.Click += BtnOk_Click;
        this.Controls.Add(btnOk);

        // Button Cancel
        btnCancel = new Button
        {
            Text = "Hủy",
            Location = new System.Drawing.Point(140, nudCapacity.Bottom + verticalSpacing),
            Font = new Font("Arial", 12, FontStyle.Bold), // Tăng kích cỡ chữ cho nút
            Size = new System.Drawing.Size(100, 40) // Tăng kích thước nút
        };
        btnCancel.Click += BtnCancel_Click;
        this.Controls.Add(btnCancel);

        if (data != null)
        {
            this.Data = data;
            addTourButton = new Button
            {
                Text = "Thêm tour",
                Location = new System.Drawing.Point(260, nudCapacity.Bottom + verticalSpacing),
                Font = new Font("Arial", 12, FontStyle.Bold), 
                Size = new System.Drawing.Size(100, 40)
            };
            addTourButton.Click += AddTourButton_Click;
            this.Controls.Add(addTourButton);
            
            viewDetailButton = new Button
            {
                Text = "Chi tiết",
                Location = new System.Drawing.Point(380, nudCapacity.Bottom + verticalSpacing),
                Font = new Font("Arial", 12, FontStyle.Bold), 
                Size = new System.Drawing.Size(100, 40)
            };
            viewDetailButton.Click += BtnDetail_Click;
            this.Controls.Add(viewDetailButton);
            
            txtName.Text = data.Name;
            nudNumberOfDays.Text = data.NumberOfDays.ToString();
            cmbVehicle.Text = data.Vehicle;
            txtDescription.Text = data.Description;
            nudCapacity.Text = data.Capacity.ToString();
        }
        
        GuiUtils.Scale(this, scaleFactor);
    }

    private void AddTourButton_Click(object? sender, EventArgs e)
    {
        var guides = GuideBus.Instance.GetAllGuides();
        var dateRangeForm = new AddTourForm(guides);
        if (dateRangeForm.ShowDialog() != DialogResult.OK) return;
        var startDate = dateRangeForm.StartDate;
        var endDate = dateRangeForm.EndDate;
        var price = dateRangeForm.Price;

        if (Data == null) return;
        var tour = new Models.Tour
        {
            Id = 0,
            DateStart = startDate!,
            DateEnd = endDate!,
            ItineraryId = Data.Id,
            Price = price,
            Capacity = Data.Capacity,
            RemainingSlots = Data.Capacity,
            Itinerary = null,
            Tickets = null
        };
        var tourSaved =  TourBus.Instance.CreateTour(tour);
        if (tourSaved != null)
        {
            TourGuideBus.Instance.AddTourGuide(tourSaved.Id, (int)dateRangeForm.SelectedGuide!);
        }

    }

    private void BtnCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void BtnDetail_Click(object? sender, EventArgs e)
    {
        if (Data == null) return;
        var form = new ItineraryDetailForm(Data.Id);
        form.Show();
    }

    private void BtnOk_Click(object sender, EventArgs e)
    {
        // Kiểm tra đầu vào hợp lệ
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show("Vui lòng nhập tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (cmbVehicle.SelectedIndex == -1)
        {
            MessageBox.Show("Vui lòng chọn phương tiện!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (string.IsNullOrWhiteSpace(txtDescription.Text))
        {
            MessageBox.Show("Vui lòng nhập mô tả!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Lưu thông tin
        ItineraryName = txtName.Text.Trim();
        NumberOfDays = (int)nudNumberOfDays.Value;
        Vehicle = cmbVehicle.SelectedItem.ToString();
        Description = txtDescription.Text.Trim();
        Capacity = (int)nudCapacity.Value;

        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}