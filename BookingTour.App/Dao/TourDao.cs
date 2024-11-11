using System.Data;
using BookingTour.App.Helper;
using BookingTour.App.Models;
using MySql.Data.MySqlClient;

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
    
    public int UpdateTour(Tour tour)
    {
        var query = @"UPDATE tour SET 
                        date_start = @DateStart,
                        date_end = @DateEnd,
                        itinerary_id = @ItineraryId,
                        price = @Price,
                        capacity = @Capacity,
                        remaining_slots = @RemainingSlots
                      WHERE id = @Id";
        
        var parameters = new[]
        {
            new MySqlParameter("@Id", tour.Id),
            new MySqlParameter("@DateStart", tour.DateStart.HasValue ? tour.DateStart.Value.ToDateTime(TimeOnly.MinValue) : (object)DBNull.Value),
            new MySqlParameter("@DateEnd", tour.DateEnd.HasValue ? tour.DateEnd.Value.ToDateTime(TimeOnly.MinValue) : (object)DBNull.Value),
            new MySqlParameter("@ItineraryId", tour.ItineraryId ?? (object)DBNull.Value),
            new MySqlParameter("@Price", tour.Price ?? (object)DBNull.Value),
            new MySqlParameter("@Capacity", tour.Capacity ?? (object)DBNull.Value),
            new MySqlParameter("@RemainingSlots", tour.RemainingSlots ?? (object)DBNull.Value)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters);
    }
    
    // Hàm thêm tour mới
    public int AddTour(Tour tour)
    {
        var query = @"INSERT INTO tour (date_start, date_end, itinerary_id, price, capacity, remaining_slots) 
                      VALUES (@DateStart, @DateEnd, @ItineraryId, @Price, @Capacity, @RemainingSlots)";
        
        var parameters = new[]
        {
            new MySqlParameter("@DateStart", tour.DateStart.HasValue ? tour.DateStart.Value.ToDateTime(TimeOnly.MinValue) : (object)DBNull.Value),
            new MySqlParameter("@DateEnd", tour.DateEnd.HasValue ? tour.DateEnd.Value.ToDateTime(TimeOnly.MinValue) : (object)DBNull.Value),
            new MySqlParameter("@ItineraryId", tour.ItineraryId ?? (object)DBNull.Value),
            new MySqlParameter("@Price", tour.Price ?? (object)DBNull.Value),
            new MySqlParameter("@Capacity", tour.Capacity ?? (object)DBNull.Value),
            new MySqlParameter("@RemainingSlots", tour.RemainingSlots ?? (object)DBNull.Value)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters);
    }
    
    public Tour? GetById(int id)
    {
        var query = "SELECT id, date_start, date_end, itinerary_id, price, capacity, remaining_slots FROM tour WHERE id = @id";

        var parameters = new[]
        {
            new MySqlParameter("@id", MySqlDbType.Int32) { Value = id }
        };

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
        }, parameters).FirstOrDefault(); // Trả về phần tử đầu tiên hoặc null nếu không tìm thấy
    }
    
    public int Count()
    {
        var query = "SELECT COUNT(*) FROM tour";

        return Convert.ToInt32(_dbHelper.ExecuteScalar(query));
    }
}