using System;
using System.Collections.Generic;

namespace BookingTour.App.Models;

public partial class Guide
{
    public int Id { get; set; }

    public string? Language { get; set; }

    public int? AccountId { get; set; }

    public virtual User? Account { get; set; }
    
    // Thuộc tính để hiển thị
    public string FullName => Account?.Name + " - " + Language;
}
