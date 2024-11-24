using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Tests;

public class Test
{
    public void Run()
    {
        // Seed data
        DatabaseSeeder.Seed();
        
        // test functions
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Get itineraty details of tour");
        List<ItineraryDetail> itineraryDetails = UnitOfWork.Instance.ItineraryDetail.GetItineraryDetailsOfTour(1);
        foreach (var detail in itineraryDetails)
        {
            Console.WriteLine($"Itinerary Detail ID: {detail.TourInterfaceId}");
            Console.WriteLine($"Activity: {detail.Activity?.Name ?? "No Activity"}");
            Console.WriteLine($"Place: {detail.Activity.Place?.Name ?? "No Place"}");
            Console.WriteLine($"Service: {detail.Service?.Name ?? "No Service"}");
            Console.WriteLine($"Start Time: {detail.StartTime}");
            Console.WriteLine($"End Time: {detail.EndTime}");
            Console.WriteLine($"Day Number: {detail.DayNumber}");
        }
    }
}