using BookingTour.App.Helper;

namespace BookingTour.App.Dao;

public class GuideDao
{
    private static readonly Lazy<GuideDao> _instance = new(() => new GuideDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static GuideDao Instance => _instance.Value;
}