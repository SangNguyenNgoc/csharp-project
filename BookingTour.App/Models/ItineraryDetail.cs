using System;
using System.Collections.Generic;

namespace BookingTour.App.Models;

public partial class ItineraryDetail
{
    public int TourInterfaceId { get; set; }

    public int ActivityId { get; set; }

    /// <summary>
    /// ngày thứ mấy trong tour
    /// </summary>
    public int? DayNumber { get; set; }

    public int? ServiceId { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public virtual Activity Activity { get; set; } = null!;

    public virtual Service? Service { get; set; }

    public virtual Itinerary TourInterface { get; set; } = null!;
}
