using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Bus;

public class StatisticsBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<StatisticsBus> _instance = new(() => new StatisticsBus());
    public static StatisticsBus Instance => _instance.Value;

    // Thống kê doanh thu và số lượng tour theo khoảng thời gian
    public List<StatisticsByTime>? GetStatisticsByTime(DateOnly startDate, DateOnly endDate)
    {
        try
        {
            return _unit.Statistics.GetStatisticsByTime(startDate, endDate);
        }
        catch (System.Exception ex)
        {
            Logger.Instance.Log("High", $"Failed to get statistics by time: {ex.Message}");
            return null;
        }
    }

    // Thống kê doanh thu và số lượng tour theo itinerary
    public List<StatisticsByItinerary>? GetStatisticsByItinerary(DateOnly? startDate, DateOnly? endDate)
    {
        try
        {
            return _unit.Statistics.GetStatisticsByItinerary(startDate, endDate);
        }
        catch (System.Exception ex)
        {
            Logger.Instance.Log("High", $"Failed to get statistics by itinerary: {ex.Message}");
            return null;
        }
    }

    // Thống kê doanh thu và tỷ lệ lấp đầy của từng tour
    public List<StatisticsByTour>? GetStatisticsByTour(DateOnly? startDate, DateOnly? endDate)
    {
        try
        {
            return _unit.Statistics.GetStatisticsByTour(startDate, endDate);
        }
        catch (System.Exception ex)
        {
            Logger.Instance.Log("High", $"Failed to get statistics by tour: {ex.Message}");
            return null;
        }
    }
}