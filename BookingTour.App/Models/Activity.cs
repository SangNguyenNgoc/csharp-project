using System;
using System.Collections.Generic;

namespace BookingTour.App.Models;

public partial class Activity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? PlaceId { get; set; }

    public virtual ICollection<ItineraryDetail>? ItineraryDetails { get; set; } = new List<ItineraryDetail>();

    public virtual Place? Place { get; set; }
}
