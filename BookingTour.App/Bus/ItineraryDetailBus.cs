using BookingTour.App.Helper;

namespace BookingTour.App.Bus;

public class ItineraryDetailBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<ItineraryDetailBus> _instance = new(() => new ItineraryDetailBus());
    public static ItineraryDetailBus Instance => _instance.Value;
}