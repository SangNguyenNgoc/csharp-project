using BookingTour.App.Helper;

namespace BookingTour.App.Bus;

public class PassengerBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<PassengerBus> _instance = new(() => new PassengerBus());
    public static PassengerBus Instance => _instance.Value;
}