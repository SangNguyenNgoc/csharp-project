using BookingTour.App.Helper;

namespace BookingTour.App.Dao;

public class ItineraryDao
{
    private static readonly Lazy<ItineraryDao> _instance = new(() => new ItineraryDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static ItineraryDao Instance => _instance.Value;
}