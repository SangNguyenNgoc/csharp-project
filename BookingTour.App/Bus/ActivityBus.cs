
using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Bus;

public class ActivityBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<ActivityBus> _instance = new(() => new ActivityBus());
    public static ActivityBus Instance => _instance.Value;

    public bool ValidateActivity(Activity? activity, out string validationErrors)
    {
        validationErrors = String.Empty;

        if (activity == null)
        {
            validationErrors = "Activity object cannot be null.";
            return false;
        }

        // Validate Name
        if (string.IsNullOrWhiteSpace(activity.Name))
        {
            validationErrors = "Name is required.";
            return false;
        }

        // Validate Description
        if (string.IsNullOrWhiteSpace(activity.Description))
        {
            validationErrors = "Description is required.";
            return false;
        }

        // Validate PlaceId
        if (activity.PlaceId is <= 0)
        {
            validationErrors = "PlaceId must be a positive integer.";
            return false;
        }

        return true;
    }
    
    public Activity? CreateActivity(Activity? activity)
    {
        if (!ValidateActivity(activity, out var validationErrors))
        {
            Logger.Instance.Log("Low", $"Failed to create activity: {validationErrors}");
            return null;
        }
        
        return _unit.Activity.AddActivity(activity) == 0 ? null : activity;

    }
    
    public bool UpdateActivity(Activity? activity)
    {
        if (!ValidateActivity(activity, out var validationErrors))
        {
            Logger.Instance.Log("Low", $"Failed to update activity: {validationErrors}");
            return false;
        }

        var result = 0;

        _unit.ExecuteInTransaction(u =>
        {
            result = u.Activity.UpdateActivity(activity);
        });

        if (result != 0) return true;
        Logger.Instance.Log("Low", "Failed to update activity.");
        return false;
    }

}