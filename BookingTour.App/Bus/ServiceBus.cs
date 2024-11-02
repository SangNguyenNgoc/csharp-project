using BookingTour.App.Helper;

namespace BookingTour.App.Bus;

public class ServiceBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<ServiceBus> _instance = new(() => new ServiceBus());
    public static ServiceBus Instance => _instance.Value;
}