
using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Tests;

public class Test
{
    public void Run()
    {
        List<Tour> tours = UnitOfWork.Instance.Tour.GetAllTours();

        foreach (var tour in tours)
        {
            Console.WriteLine($"Tour ID: {tour.Id}");
            Console.WriteLine($"Start Date: {tour.DateStart}");
            Console.WriteLine($"End Date: {tour.DateEnd}");
            Console.WriteLine($"Itinerary ID: {tour.ItineraryId}");
            Console.WriteLine($"Price: {tour.Price}");
            Console.WriteLine($"Capacity: {tour.Capacity}");
            Console.WriteLine($"Remaining Slots: {tour.RemainingSlots}");
            Console.WriteLine(new string('-', 30)); 
        }
    }
}