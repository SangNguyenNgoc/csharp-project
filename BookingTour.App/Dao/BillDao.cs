using BookingTour.App.Helper;

namespace BookingTour.App.Dao;

public class BillDao
{
    private static readonly Lazy<BillDao> _instance = new(() => new BillDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static BillDao Instance => _instance.Value;
}