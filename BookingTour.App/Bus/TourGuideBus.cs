using BookingTour.App.Helper;

namespace BookingTour.App.Bus;

public class TourGuideBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<TourGuideBus> _instance = new(() => new TourGuideBus());
    public static TourGuideBus Instance => _instance.Value;
}