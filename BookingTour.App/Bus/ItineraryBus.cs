using BookingTour.App.Helper;

namespace BookingTour.App.Bus;

public class ItineraryBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<ItineraryBus> _instance = new(() => new ItineraryBus());
    public static ItineraryBus Instance => _instance.Value;
}