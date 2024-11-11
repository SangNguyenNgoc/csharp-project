using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Bus;

public class ItineraryBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<ItineraryBus> _instance = new(() => new ItineraryBus());
    public static ItineraryBus Instance => _instance.Value;
    private Logger logger = new Logger();
    
    public bool ValidateItinerary(Itinerary? itinerary, out string validationMessage)
    {
        validationMessage = string.Empty;

        if (itinerary == null)
        {
            validationMessage = "Itinerary cannot be null.";
            return false;
        }

        if (string.IsNullOrEmpty(itinerary.Name))
        {
            validationMessage = "Name is required.";
            return false;
        }

        if (itinerary.NumberOfDays <= 0)
        {
            validationMessage = "Number of days must be greater than 0.";
            return false;
        }

        if (!string.IsNullOrEmpty(itinerary.Vehicle) && itinerary.Vehicle.Length > 50)
        {
            validationMessage = "Vehicle description cannot exceed 50 characters.";
            return false;
        }

        if (!string.IsNullOrEmpty(itinerary.Description) && itinerary.Description.Length > 500)
        {
            validationMessage = "Description cannot exceed 500 characters.";
            return false;
        }

        if (itinerary.Capacity is <= 0)
        {
            validationMessage = "Capacity must be greater than 0 if provided.";
            return false;
        }

        return true;
    }
    
    public Itinerary? CreateItinerary(Itinerary itinerary)
    {
        if (!ValidateItinerary(itinerary, out var validationMessage))
        {
            logger.Log("Low" ,$"Failed to create itinerary: {validationMessage}");
            return null;
        }
        
        var result = 0;
        _unit.ExecuteInTransaction(u =>
        {
            itinerary.Id = AppUtil.GetCurrentDateIntWithNumber(u.Itinerary.Count());
            result = u.Itinerary.AddItinerary(itinerary);
        });
        return result == 0 ? null : itinerary;
    }
    
    public Itinerary? UpdateItinerary(Itinerary? itinerary)
    {
        if (!ValidateItinerary(itinerary, out var validationMessage))
        {
            logger.Log("Low" ,$"Failed to update itinerary: {validationMessage}");
            return null;
        }

        var result = 0;
        _unit.ExecuteInTransaction(u =>
        {
            result = _unit.Itinerary.GetItineraryById(itinerary.Id) == null ? 0 : _unit.Itinerary.UpdateItinerary(itinerary);
        });
        
        return result == 0 ? null : itinerary;
    }
}