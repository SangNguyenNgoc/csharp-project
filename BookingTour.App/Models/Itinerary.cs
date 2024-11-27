using System;
using System.Collections.Generic;

namespace BookingTour.App.Models;

public partial class Itinerary
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    
    public int NumberOfDays { get; set; }

    public string? Vehicle { get; set; }

    public string? Description { get; set; }

    public int? Capacity { get; set; }

    public virtual ICollection<ItineraryDetail>? ItineraryDetails { get; set; } = new List<ItineraryDetail>();

    public virtual ICollection<Tour>? Tours { get; set; } = new List<Tour>();
}
