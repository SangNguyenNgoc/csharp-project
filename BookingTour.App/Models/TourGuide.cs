using System;
using System.Collections.Generic;

namespace BookingTour.App.Models;

public partial class TourGuide
{
    public int? TourId { get; set; }

    public int? GuideId { get; set; }

    public virtual User? Guide { get; set; }

    public virtual Tour? Tour { get; set; }
}
