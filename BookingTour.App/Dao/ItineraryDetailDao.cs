using BookingTour.App.Helper;

namespace BookingTour.App.Dao;

public class ItineraryDetailDao
{
    private static readonly Lazy<ItineraryDetailDao> _instance = new(() => new ItineraryDetailDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static ItineraryDetailDao Instance => _instance.Value;
}