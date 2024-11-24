using System;
using System.Collections.Generic;

namespace BookingTour.App.Models;

public partial class Place
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Activity>? Activities { get; set; } = new List<Activity>();
}
