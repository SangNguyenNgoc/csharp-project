using BookingTour.App.Bus;
using BookingTour.App.Models;
using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;

namespace BookingTour.App.Gui.Statistic;

public partial class StatisticForm : Form
{
    public StatisticForm()
    {
        InitializeComponent();
    }

    private void StatisticForm_Load(object sender, EventArgs e)
    {
        LoadTimeChart();
        LoadItineraryChart();
        LoadTourTable();
    }

    private void LoadTimeChart()
    {
        var currentYear = DateTime.Now.Year;
        for (var year = currentYear - 10; year <= currentYear; year++)
        {
            yearSelect.Items.Add(year);
        }
        yearSelect.SelectedIndex = 10;
        var startDate = GetFirstDayOfYear(currentYear);
        var endDate = GetLastDayOfYear(currentYear);
        var statisticsData = StatisticsBus.Instance.GetStatisticsByTime(startDate, endDate);
        UpdateRevenueChart(statisticsData ?? [new StatisticsByTime
            {
                Period = "",
                TotalRevenue = 0,
                TotalTours = 0,
                TotalTickets = 0
            }
        ]);
    }

    private void LoadItineraryChart()
    {
        var currentYear = DateTime.Now.Year;
        for (var year = currentYear - 10; year <= currentYear; year++)
        {
            yearSelect2.Items.Add(year);
        }
        yearSelect2.SelectedIndex = 10;
        var startDate = GetFirstDayOfYear(currentYear);
        var endDate = GetLastDayOfYear(currentYear);
        var statisticsData = StatisticsBus.Instance.GetStatisticsByItinerary(startDate, endDate);
        UpdateItineraryChart(statisticsData ?? [new StatisticsByItinerary
            {
                ItineraryId = 0,
                ItineraryName = "",
                TotalRevenue = 0,
                TotalTours = 0
            }
        ]);
    }

    public void UpdateRevenueChart(List<StatisticsByTime> data)
    {
        // Cấu hình Labels trục X
        var labels = data.Select(d => d.Period).ToArray();

        // Series 1: Doanh thu
        var revenueSeries = new ColumnSeries<decimal>
        {
            Values = data.Select(d => d.TotalRevenue).ToArray(),
            Name = "Doanh thu (Revenue)"
        };

        // Series 2: Số tour
        var toursSeries = new LineSeries<int>
        {
            Values = data.Select(d => d.TotalTours).ToArray(),
            Name = "Số tour (Tours)"
        };

        // Series 3: Số vé
        var ticketsSeries = new LineSeries<int>
        {
            Values = data.Select(d => d.TotalTickets).ToArray(),
            Name = "Số vé (Tickets)"
        };

        // Cập nhật Chart
        cartesianChart1.Series = new ISeries[] { revenueSeries, toursSeries, ticketsSeries };

        // Gán trục X
        cartesianChart1.XAxes = new[]
        {
            new Axis
            {
                Labels = labels,
                LabelsRotation = 15 // Xoay nhãn nếu cần
            }
        };

        // Gán trục Y
        cartesianChart1.YAxes = new[]
        {
            new Axis
            {
                Name = "Giá trị"
            }
        };

        // Cấu hình Tooltip
        cartesianChart1.TooltipPosition = TooltipPosition.Top; // Hiển thị tooltip ở trên
        cartesianChart1.TooltipTextSize = 14;
    }

    public void UpdateItineraryChart(List<StatisticsByItinerary> data)
    {
        var xLabels = data.Select(item => item.ItineraryName).ToArray();

        var totalRevenueSeries = new ColumnSeries<decimal>
        {
            Name = "Total Revenue",
            Values = data.Select(item => item.TotalRevenue).ToArray(),
        };

        var totalToursSeries = new ColumnSeries<int>
        {
            Name = "Total Tours",
            Values = data.Select(item => item.TotalTours).ToArray(),
        };

        cartesianChart2.XAxes = new Axis[]
        {
            new Axis
            {
                Labels = xLabels,
                Name = "Itineraries",
                LabelsRotation = 15 // Góc xoay nhãn trục X nếu quá dài
            }
        };

        cartesianChart2.YAxes = new Axis[]
        {
            new Axis
            {
                Name = "Values",
                NamePaint = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint
                {
                    Color = SkiaSharp.SKColors.Black
                }
            }
        };
        cartesianChart2.Series = new ISeries[] { totalRevenueSeries, totalToursSeries };
    }

    private void LoadTourTable()
    {
        var currentYear = DateTime.Now.Year;
        for (var year = currentYear - 10; year <= currentYear; year++)
        {
            yearSelect3.Items.Add(year);
        }
        yearSelect3.SelectedIndex = 10;
        var startDate = GetFirstDayOfYear(currentYear);
        var endDate = GetLastDayOfYear(currentYear);
        var statisticsData = StatisticsBus.Instance.GetStatisticsByTour(startDate, endDate);
        UpdateTourStatistic(statisticsData ?? [new StatisticsByTour
            {
                TourId = 0,
                DateStart = default,
                DateEnd = default,
                TotalRevenue = 0,
                Capacity = 0,
                BookedSlots = 0,
                FillRate = 0
            }
        ]);
    }

    private void UpdateTourStatistic(List<StatisticsByTour> data)
    {
        // Xóa tất cả cột và dòng hiện có trong DataGridView
        dataGridView1.Columns.Clear();
        dataGridView1.Rows.Clear();

        // Thêm các cột vào DataGridView
        dataGridView1.Columns.Add("TourId", "Tour ID");
        dataGridView1.Columns.Add("DateStart", "Start Date");
        dataGridView1.Columns.Add("DateEnd", "End Date");
        dataGridView1.Columns.Add("TotalRevenue", "Total Revenue");
        dataGridView1.Columns.Add("Capacity", "Capacity");
        dataGridView1.Columns.Add("BookedSlots", "Booked Slots");
        dataGridView1.Columns.Add("FillRate", "Fill Rate (%)");

        // Định dạng hiển thị cho các cột ngày và tiền tệ
        dataGridView1.Columns["DateStart"].DefaultCellStyle.Format = "dd/MM/yyyy";
        dataGridView1.Columns["DateEnd"].DefaultCellStyle.Format = "dd/MM/yyyy";
        dataGridView1.Columns["TotalRevenue"].DefaultCellStyle.Format = "C"; // Hiển thị theo định dạng tiền tệ
        dataGridView1.Columns["FillRate"].DefaultCellStyle.Format = "P1";   // Hiển thị theo định dạng phần trăm

        // Đổ dữ liệu từ danh sách vào DataGridView
        foreach (var item in data)
        {
            dataGridView1.Rows.Add(
                item.TourId,
                item.DateStart,
                item.DateEnd,
                item.TotalRevenue,
                item.Capacity,
                item.BookedSlots,
                item.FillRate / 100 // Chuyển đổi từ tỷ lệ phần trăm sang định dạng số
            );
        }

        // Tự động điều chỉnh kích thước cột
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    public DateOnly GetFirstDayOfYear(int year)
    {
        // Ngày đầu tiên của năm
        return new DateOnly(year, 1, 1);
    }

    public DateOnly GetLastDayOfYear(int year)
    {
        // Ngày cuối cùng của năm (31 tháng 12)
        return new DateOnly(year, 12, 31);
    }

    private void YearSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (yearSelect.SelectedItem == null) return;
        var selectedYear = (int)yearSelect.SelectedItem;
        LoadStatisticsRevuenueForYear(selectedYear);
    }

    private void LoadStatisticsRevuenueForYear(int year)
    {
        var startDate = GetFirstDayOfYear(year);
        var endDate = GetLastDayOfYear(year);
        var statisticsData = StatisticsBus.Instance.GetStatisticsByTime(startDate, endDate);
        if (statisticsData != null) UpdateRevenueChart(statisticsData);
    }

    private void yearSelect2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (yearSelect2.SelectedItem == null) return;
        var selectedYear = (int)yearSelect2.SelectedItem;
        LoadStatisticsItineraryForYear(selectedYear);
    }

    private void LoadStatisticsItineraryForYear(int year)
    {
        var startDate = GetFirstDayOfYear(year);
        var endDate = GetLastDayOfYear(year);
        var statisticsData = StatisticsBus.Instance.GetStatisticsByItinerary(startDate, endDate);
        if (statisticsData != null) UpdateItineraryChart(statisticsData);
    }

    private void yearSelect3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (yearSelect3.SelectedItem == null) return;
        var selectedYear = (int)yearSelect3.SelectedItem;
        LoadStatisticcTourForYear(selectedYear);
    }

    private void LoadStatisticcTourForYear(int year)
    {
        var startDate = GetFirstDayOfYear(year);
        var endDate = GetLastDayOfYear(year);
        var statisticsData = StatisticsBus.Instance.GetStatisticsByTour(startDate, endDate);
        if (statisticsData != null) UpdateTourStatistic(statisticsData);
    }
}