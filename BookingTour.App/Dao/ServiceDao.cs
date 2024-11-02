using BookingTour.App.Helper;

namespace BookingTour.App.Dao;

public class ServiceDao
{
    private static readonly Lazy<ServiceDao> _instance = new(() => new ServiceDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static ServiceDao Instance => _instance.Value;
}