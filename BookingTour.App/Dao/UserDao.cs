using BookingTour.App.Helper;

namespace BookingTour.App.Dao;

public class UserDao
{
    private static readonly Lazy<UserDao> _instance = new(() => new UserDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static UserDao Instance => _instance.Value;
}