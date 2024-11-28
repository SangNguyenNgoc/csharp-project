using BookingTour.App.Bus;
using BookingTour.App.Gui.Utils;
using BookingTour.App.Models;

namespace BookingTour.App.Gui.Place;

public partial class PlaceForm : Form
{
    public PlaceForm()
    {
        InitializeComponent();
        LoadPaceData(null);
    }

    private void PlaceForm_Load(object sender, EventArgs e)
    {
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        ScaleControls(this, scaleFactor);
    }

    private void ScaleControls(Control parent, float scaleFactor)
    {
        foreach (Control control in parent.Controls)
        {
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

    private void LoadPaceData(ICollection<Models.Place>? data)
    {
        dataGridView1.Rows.Clear();
        try
        {
            data ??= PlaceBus.Instance.GetAllPlaces();

            foreach (var place in data)
            {
                dataGridView1.Rows.Add(
                    place.Id,
                    place.Name
                );
            }
        }
        catch (System.Exception ex)
        {
            MessageBox.Show($@"Lỗi khi tải dữ liệu: {ex.Message}", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void createPlaceButton_Click(object sender, EventArgs e)
    {
        var inputName = ShowInputDialog("Nhập tên địa điểm:", "Thêm địa điểm", null);
        if (string.IsNullOrEmpty(inputName)) return;
        var place = new Models.Place
        {
            Id = 0,
            Name = inputName,
            Activities = null
        };
        PlaceBus.Instance.CreatePlace(place);
        LoadPaceData(null);
    }

    private string? ShowInputDialog(string prompt, string title, string? placeName)
    {
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        var inputBox = new Form
        {
            Width = (int) (400 * scaleFactor),
            Height = (int) (180 * scaleFactor),
            Text = title,
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MinimizeBox = false,
            MaximizeBox = false
        };

        var textLabel = new Label { Left = 20, Top = 20, Text = prompt, AutoSize = true };
        var inputTextBox = new TextBox { Left = 20, Top = 50, Width = 340 };
        var confirmationButton = new Button
        {
            Text = @"OK",
            Left = 250,
            Width = 80,
            Top = 90,
            DialogResult = DialogResult.OK
        };
        var cancelButton = new Button
        {
            Text = @"Hủy",
            Left = 150,
            Width = 80,
            Top = 90,
            DialogResult = DialogResult.Cancel
        };

        inputBox.Controls.Add(textLabel);
        inputBox.Controls.Add(inputTextBox);
        inputBox.Controls.Add(confirmationButton);
        inputBox.Controls.Add(cancelButton);
        inputBox.AcceptButton = confirmationButton;
        inputBox.CancelButton = cancelButton;

        if (name != null)
        {
            inputTextBox.Text = placeName;
        }
        

        GuiUtils.Scale(inputBox, scaleFactor);
        var result = inputBox.ShowDialog();
        return result == DialogResult.OK ? inputTextBox.Text.Trim() : null;
    }

    private void searchButton_Click(object sender, EventArgs e)
    {
        var keywords = searchTextbox.Text.Trim().ToLower();
        var keywordList = keywords.Split(' ');
        var filteredData = PlaceBus.Instance.GetAllPlaces().Where(user =>
            keywordList.All(keyword =>
                user.Name!.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
            )
        ).ToList();

        // Hiển thị dữ liệu đã lọc
        LoadPaceData(filteredData);
        searchTextbox.Text = "";
    }

    private void refreshButton_Click(object sender, EventArgs e)
    {
        LoadPaceData(null);
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, dataGridView1.Font.Size * scaleFactor);
        // Scale kích thước các hàng
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            row.Height = (int)(row.Height * scaleFactor);
        }
    }

    private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // ReSharper disable once InvertIf
        if (e.ColumnIndex == dataGridView1.Columns["Action"]!.Index && e.RowIndex >= 0)
        {
            var placeId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            var place = PlaceBus.Instance.GetPlaceById(placeId);
            var inputName = ShowInputDialog("Nhập tên địa điểm:", "Thêm địa điểm", place?.Name);
            if (string.IsNullOrEmpty(inputName)) return;
            place!.Name = inputName;
            PlaceBus.Instance.UpdatePlace(place);
            LoadPaceData(null);
        }
    }

    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        if (dataGridView1.CurrentRow == null) return;
        var placeId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
        var data = ActivityBus.Instance.GetActivitiesByPlaceId(placeId);
        LoadActivityData(data);
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        dataGridView2.Font = new Font(dataGridView2.Font.FontFamily, dataGridView2.Font.Size * scaleFactor);
        foreach (DataGridViewRow row in dataGridView2.Rows)
        {
            row.Height = (int)(row.Height * scaleFactor);
        }
    }

    private void LoadActivityData(ICollection<Activity> data)
    {
        try
        {
            dataGridView2.Rows.Clear();
            foreach (var place in data)
            {
                dataGridView2.Rows.Add(
                    place.Id,
                    place.Name
                );
            }
        }
        catch (System.Exception ex)
        {
            MessageBox.Show($@"Lỗi khi tải dữ liệu: {ex.Message}", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void addActivityButton_Click(object sender, EventArgs e)
    {
        using var form = new AddActivityForm(null);
        var result = form.ShowDialog();

        if (result != DialogResult.OK) return;
        var activityName = form.ActivityName;
        var activityDescription = form.ActivityDescription;
        //MessageBox.Show($"Tên hoạt động: {activityName}\nMô tả: {activityDescription}",
        //    "Thông tin hoạt động", MessageBoxButtons.OK, MessageBoxIcon.Information);
        if (dataGridView1.CurrentRow == null) return;
        var placeId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
        var activity = new Activity
        {
            Id = 0,
            Name = activityName,
            Description = activityDescription,
            PlaceId = placeId,
            ItineraryDetails = null,
            Place = null
        };
        ActivityBus.Instance.CreateActivity(activity);
        var data = ActivityBus.Instance.GetActivitiesByPlaceId(placeId);
        LoadActivityData(data);
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        dataGridView2.Font = new Font(dataGridView2.Font.FontFamily, dataGridView2.Font.Size * scaleFactor);
        // Scale kích thước các hàng
        foreach (DataGridViewRow row in dataGridView2.Rows)
        {
            row.Height = (int)(row.Height * scaleFactor);
        }
    }

    private void refreshActivityButton_Click(object sender, EventArgs e)
    {
        if (dataGridView1.CurrentRow == null) return;
        var placeId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
        var data = ActivityBus.Instance.GetActivitiesByPlaceId(placeId);
        LoadActivityData(data);
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        dataGridView2.Font = new Font(dataGridView2.Font.FontFamily, dataGridView2.Font.Size * scaleFactor);
        
        // Scale kích thước các hàng
        foreach (DataGridViewRow row in dataGridView2.Rows)
        {
            row.Height = (int)(row.Height * scaleFactor);
        }
    }

    private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // ReSharper disable once InvertIf
        if (e.ColumnIndex == dataGridView2.Columns["AcAction"]!.Index && e.RowIndex >= 0)
        {
            var activityId = (int)dataGridView2.Rows[e.RowIndex].Cells["AcId"].Value;
            // MessageBox.Show($"ID được chọn: {activityId}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            using var form = new AddActivityForm(activityId);
            var result = form.ShowDialog();

            if (result != DialogResult.OK) return;
            var activityName = form.ActivityName;
            var activityDescription = form.ActivityDescription;
            //MessageBox.Show($"Tên hoạt động: {activityName}\nMô tả: {activityDescription}",
            //    "Thông tin hoạt động", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dataGridView1.CurrentRow == null) return;
            var placeId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
            var activity = new Activity
            {
                Id = activityId,
                Name = activityName,
                Description = activityDescription,
                PlaceId = placeId,
                ItineraryDetails = null,
                Place = null
            };
            ActivityBus.Instance.UpdateActivity(activity);
            var data = ActivityBus.Instance.GetActivitiesByPlaceId(placeId);
            LoadActivityData(data);
        }
    }

    private void searchActivityButton_Click(object sender, EventArgs e)
    {
        if (dataGridView1.CurrentRow == null) return;
        var placeId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
        var keywords = searchActivityTextbox.Text.Trim().ToLower();
        var keywordList = keywords.Split(' ');
        var filteredData = ActivityBus.Instance.GetActivitiesByPlaceId(placeId).Where(activity =>
            keywordList.All(keyword =>
                activity.Name!.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
            )
        ).ToList();

        LoadActivityData(filteredData);
        searchTextbox.Text = "";
    }
}
