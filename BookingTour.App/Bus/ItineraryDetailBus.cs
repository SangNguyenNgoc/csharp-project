using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Bus;

public class ItineraryDetailBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<ItineraryDetailBus> _instance = new(() => new ItineraryDetailBus());
    public static ItineraryDetailBus Instance => _instance.Value;
    private Logger logger = new Logger();

    public bool ValidateItineraryDetail(ItineraryDetail? detail, out string validationMessage)
    {
        validationMessage = string.Empty;

        if (detail == null)
        {
            validationMessage = "ItineraryDetail cannot be null.";
            return false;
        }

        if (detail.TourInterfaceId <= 0)
        {
            validationMessage = "TourInterfaceId must be a positive number.";
            return false;
        }

        if (detail.ActivityId <= 0)
        {
            validationMessage = "ActivityId must be a positive number.";
            return false;
        }

        if (detail.DayNumber.HasValue && detail.DayNumber <= 0)
        {
            validationMessage = "DayNumber must be a positive number if provided.";
            return false;
        }

        if (detail.ServiceId.HasValue && detail.ServiceId <= 0)
        {
            validationMessage = "ServiceId must be a positive number if provided.";
            return false;
        }

        if (detail is { StartTime: not null, EndTime: not null })
        {
            if (detail.EndTime <= detail.StartTime)
            {
                validationMessage = "EndTime must be greater than StartTime.";
                return false;
            }
        }
        
        var foreignKey = true;
        var checkTime = true;
        
        _unit.ExecuteInTransaction(u=>
        {
            var activity = u.Activity.GetById(detail.ActivityId);
            var service = u.Service.GetServiceById((int)detail.ServiceId!);
            var itinerary = u.Itinerary.GetItineraryById(detail.TourInterfaceId);
            if (activity != null && service == null && itinerary != null)
            {
                foreignKey = false;
            }

            if (u.ItineraryDetail.IsTimeSlotConflict(detail))
            {
                checkTime = false;
            }
        });
        if (!foreignKey)
        {
            validationMessage = "ActivityId or ServiceId or TourInterfaceId is invalid.";
            return false;
        }

        if (!checkTime)
        {
            validationMessage = "Time slot is conflicted.";
            return false;
        }

        return true;
    }
    
    public ItineraryDetail? CreateItineraryDetail(ItineraryDetail? detail)
    {
        if (!ValidateItineraryDetail(detail, out var validationMessage))
        {
            logger.Log("Low", $"Failed to create itinerary detail: {validationMessage}");
            return null;
        }

        return _unit.ItineraryDetail.AddItineraryDetail(detail!) == 0 ? null : detail;
    }
    
    public String DeleteItineraryDetail(int tourInterfaceId, int activityId, int dayNumber)
    {
        var result = 0;
        _unit.ExecuteInTransaction(u =>
        {
            result = u.ItineraryDetail.DeleteItineraryDetail(tourInterfaceId, activityId, dayNumber);
        });
        
        return result == 0 ? "Failed to delete itinerary detail." : "Delete itinerary detail successfully.";
    }

}