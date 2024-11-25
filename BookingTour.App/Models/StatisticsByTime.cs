namespace BookingTour.App.Models;

public class StatisticsByTime
{
    public string Period { get; set; }
    public decimal TotalRevenue { get; set; }
    public int TotalTours { get; set; }
    public int TotalTickets { get; set; } // Thống kê số vé
}