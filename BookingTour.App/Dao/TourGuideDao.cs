using BookingTour.App.Helper;

namespace BookingTour.App.Dao;

public class TourGuideDao
{
    private static readonly Lazy<TourGuideDao> _instance = new(() => new TourGuideDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static TourGuideDao Instance => _instance.Value;
}