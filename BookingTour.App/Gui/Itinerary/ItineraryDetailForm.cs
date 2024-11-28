using BookingTour.App.Bus;
using BookingTour.App.Models;

namespace BookingTour.App.Gui.Itinerary;

public partial class ItineraryDetailForm : Form
{
    private int _itineraryid;

    public ItineraryDetailForm(int itineraryId)
    {
        this._itineraryid = itineraryId;
        InitializeComponent();
        LoadItineratyDetails(itineraryId);
    }

    public void LoadItineratyDetails(int itineraryId)
    {
        typeDetailGridView.Rows.Clear();
        typeDetailGridView.Columns.Clear();

        // Tạo các cột trong DataGridView
        var activityColumn = new DataGridViewTextBoxColumn
        {
            Name = "Activity",
            HeaderText = "Hoạt động",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Tự động phủ đầy chiều ngang
        };

        var placeColumn = new DataGridViewTextBoxColumn
        {
            Name = "Place",
            HeaderText = "Nơi diễn ra",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Tự động phủ đầy chiều ngang
        };

        var serviceColumn = new DataGridViewTextBoxColumn
        {
            Name = "Service",
            HeaderText = "Dịch vụ",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Tự động phủ đầy chiều ngang
        };

        var numberOfDaysColumn = new DataGridViewTextBoxColumn
        {
            Name = "Number",
            HeaderText = "Ngày diễn ra",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Tự động phủ đầy chiều ngang
        };

        var startColumn = new DataGridViewTextBoxColumn
        {
            Name = "Start",
            HeaderText = "Giờ bắt đầu",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Tự động phủ đầy chiều ngang
        };

        var endColumn = new DataGridViewTextBoxColumn
        {
            Name = "End",
            HeaderText = "Giờ kết thúc",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Tự động phủ đầy chiều ngang
        };

        // Thêm các cột vào DataGridView
        typeDetailGridView.Columns.Add(activityColumn);
        typeDetailGridView.Columns.Add(placeColumn);
        typeDetailGridView.Columns.Add(serviceColumn);
        typeDetailGridView.Columns.Add(numberOfDaysColumn);
        typeDetailGridView.Columns.Add(startColumn);
        typeDetailGridView.Columns.Add(endColumn);


        // Tùy chọn: Đặt chế độ chỉnh sửa (nếu cần)
        typeDetailGridView.AllowUserToResizeColumns = false;
        typeDetailGridView.AllowUserToResizeRows = false;

        // Đảm bảo tất cả các cột chia đều chiều ngang
        typeDetailGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        List<Models.ItineraryDetail> itineraryDetails = ItineraryDetailBus.Instance.GetItineraryDetailsOfItinerary(itineraryId);

        foreach (var itineraryDetail in itineraryDetails)
        {
            typeDetailGridView.Rows.Add(
                itineraryDetail.Activity.Name,
                itineraryDetail.Activity.Place.Name,
                itineraryDetail.Service.Name,
                itineraryDetail.DayNumber,
                itineraryDetail.StartTime,
                itineraryDetail.EndTime
            );
        }
    }

    private void createAccountButton_Click(object sender, EventArgs e)
    {

        var serviceList = ServiceBus.Instance.GetAllServices();
        var activityList = ActivityBus.Instance.GetAllActivities();

        var services = serviceList.Select(service => new KeyValuePair<int, string>(service.Id, service.Name)).ToList();
        var activities = activityList.Select(activity => new KeyValuePair<int, string>(activity.Id, activity.Name)).ToList();
        var form = new AddItineraryDetailForm(services, activities);

        if (form.ShowDialog() != DialogResult.OK) return;
        var detail = new ItineraryDetail
        {
            TourInterfaceId = _itineraryid,
            ActivityId = form.ActivityId,
            DayNumber = form.DayNumber,
            ServiceId = form.ActivityId,
            StartTime = TimeOnly.FromTimeSpan(form.StartTime),
            EndTime = TimeOnly.FromTimeSpan(form.EndTime),
            Activity = null,
            Service = null,
            TourInterface = null
        };
        ItineraryDetailBus.Instance.CreateItineraryDetail(detail);
        LoadItineratyDetails(_itineraryid);
    }

    private void refershButton_Click(object sender, EventArgs e)
    {
        LoadItineratyDetails(_itineraryid);
    }
}
