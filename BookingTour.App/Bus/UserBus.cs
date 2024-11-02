using BookingTour.App.Helper;

namespace BookingTour.App.Bus;

public class UserBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<UserBus> _instance = new(() => new UserBus());
    public static UserBus Instance => _instance.Value;
}