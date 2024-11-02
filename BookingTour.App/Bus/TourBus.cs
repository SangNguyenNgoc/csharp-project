using BookingTour.App.Helper;

namespace BookingTour.App.Bus;

public class TourBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<TourBus> _instance = new(() => new TourBus());
    public static TourBus Instance => _instance.Value;
}