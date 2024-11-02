using BookingTour.App.Helper;

namespace BookingTour.App.Dao;

public class PassengerDao
{
    private static readonly Lazy<PassengerDao> _instance = new(() => new PassengerDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static PassengerDao Instance => _instance.Value;
}