using BookingTour.App.Bus;
using BookingTour.App.Gui.Utils;

namespace BookingTour.App.Gui.Service;

public partial class ServiceForm : Form
{
    private readonly List<string> _types = new List<string> { "Thể thao", "Văn hóa", "Giải trí", "Học tập" };
    public ServiceForm()
    {
        InitializeComponent();
        LoadServiceData(null);
    }

    private void ServiceForm_Load(object sender, EventArgs e)
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

    public void LoadServiceData(ICollection<Models.Service>? data)
    {
        dataGridView1.Rows.Clear();
        try
        {
            data ??= ServiceBus.Instance.GetAllServices();

            foreach (var item in data)
            {
                dataGridView1.Rows.Add(
                    item.Id,
                    item.Name,
                    item.Type,
                    item.Description
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
        using var inputForm = new AddServiceForm(_types, null);
        if (inputForm.ShowDialog() != DialogResult.OK) return;
        var serviceName = inputForm.ServiceName!; 
        var type = inputForm.ServiceType!;
        var description = inputForm.ServiceDescription!;
        
        var service = new Models.Service
        {
            Id = 0,
            Name = serviceName,
            Type = type,
            Description = description,
            ItineraryDetails = null
        };
        ServiceBus.Instance.CreateService(service);
        LoadServiceData(null);
    }
    
    private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // ReSharper disable once InvertIf
        if (e.ColumnIndex == dataGridView1.Columns["Action"]!.Index && e.RowIndex >= 0)
        {
            var serviceId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            var data = ServiceBus.Instance.GetServiceById(serviceId);
            using var inputForm = new AddServiceForm(_types, data);
            if (inputForm.ShowDialog() != DialogResult.OK) return;
            var serviceName = inputForm.ServiceName!; 
            var type = inputForm.ServiceType!;
            var description = inputForm.ServiceDescription!;
        
            var service = new Models.Service
            {
                Id = serviceId,
                Name = serviceName,
                Type = type,
                Description = description,
                ItineraryDetails = null
            };
            ServiceBus.Instance.UpdateService(service);
            LoadServiceData(null);
        }
    }

    private void searchButton_Click(object sender, EventArgs e)
    {
        var keywords = searchTextbox.Text.Trim().ToLower();
        var keywordList = keywords.Split(' ');
        var filteredData = ServiceBus.Instance.GetAllServices().Where(user =>
            keywordList.All(keyword =>
                user.Name!.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                user.Type!.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
            )
        ).ToList();
        LoadServiceData(filteredData);
        searchTextbox.Text = "";
    }

    private void refreshButton_Click(object sender, EventArgs e)
    {
        LoadServiceData(null);
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, dataGridView1.Font.Size * scaleFactor);
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            
            row.Height = (int)(row.Height * scaleFactor);
        }
    }
}
