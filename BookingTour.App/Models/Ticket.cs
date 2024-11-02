using System;
using System.Collections.Generic;

namespace BookingTour.App.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public double Price { get; set; }

    public int PassengerId { get; set; }

    public int? BillId { get; set; }

    public int? TourId { get; set; }

    public string? Type { get; set; }

    public virtual Bill? Bill { get; set; }

    public virtual Passenger Passenger { get; set; } = null!;

    public virtual Tour? Tour { get; set; }
}
