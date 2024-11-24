using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingTour.App.Models;

public partial class User
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string? Password { get; set; }

    public int RoleId { get; set; }

    public virtual Role? Role { get; set; } 

    public string? Username { get; set; }

    public string? Name { get; set; }

    // public int? Age { get; set; }

    [MaxLength(30)]
    public string? Email { get; set; }

    [MaxLength(20)]
    public string? PhoneNumber { get; set; }

    public bool? IsBlock { get; set; }

    public virtual ICollection<Bill>? Bills { get; set; } = new List<Bill>();

    public virtual ICollection<Guide>? Guides { get; set; } = new List<Guide>();
}
