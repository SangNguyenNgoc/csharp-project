using System;
using System.Collections.Generic;

namespace BookingTour.App.Models;

public partial class Tour
{
    public int Id { get; set; }

    public DateOnly? DateStart { get; set; }

    public DateOnly? DateEnd { get; set; }

    public int? ItineraryId { get; set; }

    public double? Price { get; set; }

    public int? Capacity { get; set; }

    public int? RemainingSlots { get; set; }

    public virtual Itinerary? Itinerary { get; set; }

    public virtual ICollection<Ticket>? Tickets { get; set; } = new List<Ticket>();
}
