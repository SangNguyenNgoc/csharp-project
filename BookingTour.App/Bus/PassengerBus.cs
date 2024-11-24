using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Bus;

public class PassengerBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<PassengerBus> _instance = new(() => new PassengerBus());
    public static PassengerBus Instance => _instance.Value;
    
    
    // use this method to get passengers of a tour
    public List<Passenger> GetPassengersOfTour(int tourId)
    {
        return _unit.Passenger.GetPassengersOfTour(tourId);
    }
}