using BookingTour.App.Helper;

namespace BookingTour.App.Bus;

public class BillBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<BillBus> _instance = new(() => new BillBus());
    public static BillBus Instance => _instance.Value;
}