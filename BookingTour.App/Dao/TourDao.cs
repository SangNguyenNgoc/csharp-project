using System.Data;
using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Dao;

public class TourDao
{
    private static readonly Lazy<TourDao> _instance = new(() => new TourDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static TourDao Instance => _instance.Value;
    
    
    // get all tours
    public List<Tour> GetAllTours()
    {
        var query = "SELECT id, date_start, date_end, itinerary_id, price, capacity, remaining_slots FROM tour";

        return _dbHelper.ExecuteQueryToEntities(query, reader =>
        {
            return new Tour
            {
                Id = reader.GetInt32("id"),
                DateStart = reader.IsDBNull("date_start") ? null : DateOnly.FromDateTime(reader.GetDateTime("date_start")),
                DateEnd = reader.IsDBNull("date_end") ? null : DateOnly.FromDateTime(reader.GetDateTime("date_end")),
                ItineraryId = reader.IsDBNull("itinerary_id") ? null : reader.GetInt32("itinerary_id"),
                Price = reader.IsDBNull("price") ? null : reader.GetDouble("price"),
                Capacity = reader.IsDBNull("capacity") ? null : reader.GetInt32("capacity"),
                RemainingSlots = reader.IsDBNull("remaining_slots") ? null : reader.GetInt32("remaining_slots")
            };
        });
    }
}