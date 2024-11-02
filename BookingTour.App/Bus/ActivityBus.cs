using BookingTour.App.Helper;

namespace BookingTour.App.Bus;

public class ActivityBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<ActivityBus> _instance = new(() => new ActivityBus());
    public static ActivityBus Instance => _instance.Value;


}