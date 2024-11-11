using System.Data;
using BookingTour.App.Helper;
using BookingTour.App.Models;
using MySql.Data.MySqlClient;

namespace BookingTour.App.Dao;

public class PlaceDao
{
    private static readonly Lazy<PlaceDao> _instance = new(() => new PlaceDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static PlaceDao Instance => _instance.Value;
    
    public List<Place> GetAll()
    {
        const string query = "SELECT * FROM place";
        var result = _dbHelper.ExecuteQuery(query);

        return (from DataRow row in result.Rows
            select new Place
            {
                Id = Convert.ToInt32(row["id"]),
                Name = row["name"].ToString()!
            }).ToList();
    }

    // Lấy Place theo Id
    public Place? GetById(int id)
    {
        const string query = "SELECT * FROM place WHERE id = @Id";
        var parameters = new[]
        {
            new MySqlParameter("@Id", id)
        };

        var result = _dbHelper.ExecuteQuery(query, parameters);
        var row = result.Rows.Cast<DataRow>().FirstOrDefault();

        return row == null ? null : new Place
        {
            Id = Convert.ToInt32(row["id"]),
            Name = row["name"].ToString()!
        };
    }

    // Thêm mới Place
    public int AddPlace(Place place)
    {
        const string query = @"
            INSERT INTO place (name) 
            VALUES (@Name)";

        var parameters = new[]
        {
            new MySqlParameter("@Name", place.Name)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters);
    }

    // Cập nhật Place
    public int UpdatePlace(Place place)
    {
        const string query = @"
            UPDATE place 
            SET name = @Name 
            WHERE id = @Id";

        var parameters = new[]
        {
            new MySqlParameter("@Id", place.Id),
            new MySqlParameter("@Name", place.Name)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters);
    }
    
    public int Count()
    {
        const string query = "SELECT COUNT(*) FROM place";
        var result = _dbHelper.ExecuteScalar(query);

        return Convert.ToInt32(result);
    }
}