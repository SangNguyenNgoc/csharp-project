using System.Data;
using BookingTour.App.Helper;
using BookingTour.App.Models;
using MySql.Data.MySqlClient;

namespace BookingTour.App.Dao;

public class ItineraryDao
{
    private static readonly Lazy<ItineraryDao> _instance = new(() => new ItineraryDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static ItineraryDao Instance => _instance.Value;
    
    public int AddItinerary(Itinerary itinerary)
    {
        const string query = @"
            INSERT INTO itinerary (name, numberOfDays, vehicle, description, capacity) 
            VALUES (@Name, @NumberOfDays, @Vehicle, @Description, @Capacity)";

        var parameters = new[]
        {
            new MySqlParameter("@Name", itinerary.Name),
            new MySqlParameter("@NumberOfDays", itinerary.NumberOfDays),
            new MySqlParameter("@Vehicle", itinerary.Vehicle ?? (object)DBNull.Value),
            new MySqlParameter("@Description", itinerary.Description ?? (object)DBNull.Value),
            new MySqlParameter("@Capacity", itinerary.Capacity ?? (object)DBNull.Value)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters);
    }

    // Hàm cập nhật Itinerary
    public int UpdateItinerary(Itinerary itinerary)
    {
        const string query = @"
            UPDATE itinerary 
            SET name = @Name, 
                number_of_days = @NumberOfDays, 
                vehicle = @Vehicle, 
                description = @Description, 
                capacity = @Capacity 
            WHERE id = @Id";

        var parameters = new[]
        {
            new MySqlParameter("@Id", itinerary.Id),
            new MySqlParameter("@Name", itinerary.Name),
            new MySqlParameter("@NumberOfDays", itinerary.NumberOfDays),
            new MySqlParameter("@Vehicle", itinerary.Vehicle ?? (object)DBNull.Value),
            new MySqlParameter("@Description", itinerary.Description ?? (object)DBNull.Value),
            new MySqlParameter("@Capacity", itinerary.Capacity ?? (object)DBNull.Value)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters);
    }
    
    // Hàm lấy tất cả Itineraries
    public List<Itinerary> GetAllItineraries()
    {
        const string query = @"
            SELECT id, name, number_of_days, vehicle, description, capacity 
            FROM itinerary";

        return _dbHelper.ExecuteQueryToEntities(query, reader =>
        {
            return new Itinerary
            {
                Id = reader.GetInt32("id"),
                Name = reader.GetString("name"),
                NumberOfDays = reader.GetInt32("number_of_days"),
                Vehicle = reader.IsDBNull("vehicle") ? null : reader.GetString("vehicle"),
                Description = reader.IsDBNull("description") ? null : reader.GetString("description"),
                Capacity = reader.IsDBNull("capacity") ? null : reader.GetInt32("capacity")
            };
        });
    }

    // Hàm lấy Itinerary theo Id
    public Itinerary? GetItineraryById(int id)
    {
        const string query = @"
            SELECT id, name, number_of_days, vehicle, description, capacity 
            FROM itinerary
            WHERE id = @Id";

        var parameters = new[]
        {
            new MySqlParameter("@Id", id)
        };

        var results = _dbHelper.ExecuteQueryToEntities(query, reader =>
        {
            return new Itinerary
            {
                Id = reader.GetInt32("id"),
                Name = reader.GetString("name"),
                NumberOfDays = reader.GetInt32("number_of_days"),
                Vehicle = reader.IsDBNull("vehicle") ? null : reader.GetString("vehicle"),
                Description = reader.IsDBNull("description") ? null : reader.GetString("description"),
                Capacity = reader.IsDBNull("capacity") ? null : reader.GetInt32("capacity")
            };
        }, parameters);

        return results.FirstOrDefault();
    }
    
    public int Count()
    {
        var query = "SELECT COUNT(*) FROM itinerary";

        return Convert.ToInt32(_dbHelper.ExecuteScalar(query));
    }
}