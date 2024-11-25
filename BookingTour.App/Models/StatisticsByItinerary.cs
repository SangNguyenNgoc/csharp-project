namespace BookingTour.App.Models;

public class StatisticsByItinerary
{
    public int ItineraryId { get; set; }
    public string ItineraryName { get; set; }
    public decimal TotalRevenue { get; set; }
    public int TotalTours { get; set; }
}