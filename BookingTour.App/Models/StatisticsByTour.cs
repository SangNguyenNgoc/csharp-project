namespace BookingTour.App.Models;

public class StatisticsByTour
{
    public int TourId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public decimal TotalRevenue { get; set; }
    public int Capacity { get; set; }
    public int BookedSlots { get; set; }
    public double FillRate { get; set; } // Tỷ lệ lấp đầy (%)
}