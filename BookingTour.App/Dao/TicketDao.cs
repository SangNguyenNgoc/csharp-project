using BookingTour.App.Helper;

namespace BookingTour.App.Dao;

public class TicketDao
{
    private static readonly Lazy<TicketDao> _instance = new(() => new TicketDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static TicketDao Instance => _instance.Value;
}