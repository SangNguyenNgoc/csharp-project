using BookingTour.App.Helper;

namespace BookingTour.App.Bus;

public class PlaceBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<PlaceBus> _instance = new(() => new PlaceBus());
    public static PlaceBus Instance => _instance.Value;
}