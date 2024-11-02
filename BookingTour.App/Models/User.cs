using System;
using System.Collections.Generic;

namespace BookingTour.App.Models;

public partial class User
{
    public int Id { get; set; }

    public int? Password { get; set; }

    public int? Role { get; set; }

    public string? Username { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public int? Email { get; set; }

    public int? PhoneNumber { get; set; }

    public int? Description { get; set; }

    public bool? IsBlock { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<Guide> Guides { get; set; } = new List<Guide>();
}
