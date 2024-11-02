using System;
using System.Collections.Generic;

namespace BookingTour.App.Models;

public partial class Bill
{
    public int Id { get; set; }

    public int TotalPassenger { get; set; }

    public double TotalPrice { get; set; }

    /// <summary>
    /// người xuất hóa đơn
    /// </summary>
    public int InvoiceIssuer { get; set; }

    public virtual User InvoiceIssuerNavigation { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
