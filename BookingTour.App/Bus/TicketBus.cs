using BookingTour.App.Helper;

namespace BookingTour.App.Bus;

public class TicketBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<TicketBus> _instance = new(() => new TicketBus());
    public static TicketBus Instance => _instance.Value;
}