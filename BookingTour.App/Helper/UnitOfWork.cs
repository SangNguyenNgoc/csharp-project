using BookingTour.App.Dao;

namespace BookingTour.App.Helper;

public class UnitOfWork : IDisposable
{
    
    private static readonly Lazy<UnitOfWork> _instance = new Lazy<UnitOfWork>(() => new UnitOfWork());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public ActivityDao Activity { get; } = ActivityDao.Instance;
    public BillDao Bill { get; } = BillDao.Instance;
    public GuideDao Guide { get; } = GuideDao.Instance;
    public ItineraryDao Itinerary { get; } = ItineraryDao.Instance;
    public ItineraryDetailDao ItineraryDetail { get; } = ItineraryDetailDao.Instance;
    public PassengerDao Passenger { get; } = PassengerDao.Instance;
    public PlaceDao Place { get; } = PlaceDao.Instance;
    public ServiceDao Service { get; } = ServiceDao.Instance;
    public TicketDao Ticket { get; } = TicketDao.Instance;
    public TourDao Tour { get; } = TourDao.Instance;
    public TourGuideDao TourGuide { get; } = TourGuideDao.Instance;
    public UserDao User { get; } = UserDao.Instance;
    
    public static UnitOfWork Instance => _instance.Value;

    public void ExecuteInTransaction(Action<UnitOfWork> action)
    {
        try
        {
            _dbHelper.BeginTransaction();
            action(this);
            _dbHelper.CommitTransaction();
        }
        catch (Exception)
        {
            _dbHelper.RollbackTransaction();
            throw;
        }
    }

    public void Dispose()
    {
        _dbHelper.Dispose();
    }
}