using BookingTour.App.Helper;

namespace BookingTour.App.Dao;

public class PlaceDao
{
    private static readonly Lazy<PlaceDao> _instance = new(() => new PlaceDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static PlaceDao Instance => _instance.Value;
}