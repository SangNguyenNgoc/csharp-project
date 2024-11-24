using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Bus;

public class GuideBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<GuideBus> _instance = new(() => new GuideBus());
    public static GuideBus Instance => _instance.Value;
    
    // use this method to get guides of a tour
    public List<Guide> GetGuidesOfTour(int tourId)
    {
        return _unit.Guide.GetGuidesOfTour(tourId);
    }
}