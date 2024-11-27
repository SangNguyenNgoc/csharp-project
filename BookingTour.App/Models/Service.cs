namespace BookingTour.App.Models;

public class Service
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ItineraryDetail>? ItineraryDetails { get; set; } = new List<ItineraryDetail>();
}
