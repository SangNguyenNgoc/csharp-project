using BookingTour.App.Helper;

namespace BookingTour.App.Bus;

public class GuideBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<GuideBus> _instance = new(() => new GuideBus());
    public static GuideBus Instance => _instance.Value;
}