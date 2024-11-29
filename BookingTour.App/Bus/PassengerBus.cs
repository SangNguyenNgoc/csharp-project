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

    public List<Passenger> GetPassengersOfBill(int billId)
    {
        return _unit.Passenger.GetPassengersOfBill(billId);
    }

    public ICollection<Passenger> GetAllPassengers()
    {
        return _unit.Passenger.GetAll();
    }

    public int CreatePassenger(Passenger passenger)
    {
        return _unit.Passenger.Create(passenger);
    }

    public int CreatePassengerLastId(Passenger passenger)
    {
        return _unit.Passenger.CreateLastId(passenger);
    }
}