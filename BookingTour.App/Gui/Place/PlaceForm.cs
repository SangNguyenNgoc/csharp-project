using BookingTour.App.Bus;

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
        using var g = this.CreateGraphics();
        var dpiX = g.DpiX;  // Lấy DPI của màn hình hiện tại
        var scaleFactor = dpiX / 96.0f; // Tính tỷ lệ so với DPI chuẩn (96 DPI)

        ScaleControls(this, scaleFactor);
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
        if (!string.IsNullOrEmpty(inputName))
        {
            var place = new Models.Place
            {
                Id = 0,
                Name = inputName,
                Activities = null
            };
            PlaceBus.Instance.CreatePlace(place);
            LoadPaceData(null);
        }
        else
        {
            MessageBox.Show(@"Tên địa điểm không được để trống!", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string? ShowInputDialog(string prompt, string title, string? placeName)
    {
        var inputBox = new Form
        {
            Width = 400,
            Height = 180,
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
    }
    
    private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // ReSharper disable once InvertIf
        if (e.ColumnIndex == dataGridView1.Columns["Action"]!.Index && e.RowIndex >= 0)
        {
            var placeId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            var place = PlaceBus.Instance.GetPlaceById(placeId);
            var inputName = ShowInputDialog("Nhập tên địa điểm:", "Thêm địa điểm", place?.Name);
            if (!string.IsNullOrEmpty(inputName))
            {
                place!.Name = inputName;
                PlaceBus.Instance.UpdatePlace(place);
                LoadPaceData(null);
            }
            else
            {
                MessageBox.Show(@"Tên địa điểm không được để trống!", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
