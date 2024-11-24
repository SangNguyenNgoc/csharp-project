using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Bus;

public class PlaceBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<PlaceBus> _instance = new(() => new PlaceBus());
    public static PlaceBus Instance => _instance.Value;

    public bool ValidateActivity(Place? place, out string validationErrors)
    {
        validationErrors = String.Empty;

        if (place == null)
        {
            validationErrors = "Activity object cannot be null.";
            return false;
        }

        // Validate Name
        if (string.IsNullOrWhiteSpace(place.Name))
        {
            validationErrors = "Name is required.";
            return false;
        }

        return true;
    }
    
    public Place? CreatePlace(Place? place)
    {
        if (!ValidateActivity(place, out var validationErrors))
        {
            Logger.Instance.Log("Low", $"Failed to create place: {validationErrors}");
            return null;
        }
        
        var result = 0;
        _unit.ExecuteInTransaction(u =>
        {
            place!.Id = u.Place.Count() + 1;
            result = u.Place.AddPlace(place);
        });
        
        return result == 0 ? null : place;

    }
    
    public bool UpdatePlace(Place? place)
    {
        if (!ValidateActivity(place, out var validationErrors))
        {
            Logger.Instance.Log("Low", $"Failed to update place: {validationErrors}");
            return false;
        }
        
        return _unit.Place.UpdatePlace(place) == 0;
    }
    
    public List<Place> GetAllPlaces()
    {
        try
        {
            return _unit.Place.GetAll();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($@"Error fetching all places: {ex.Message}");
            throw;
        }
    }
    
    
    public Place? GetPlaceById(int id)
    {
        try
        {
            return _unit.Place.GetById(id);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($@"Error fetching place by ID: {ex.Message}");
            throw;
        }
    }
}