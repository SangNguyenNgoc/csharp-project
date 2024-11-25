using System.Data;
using BookingTour.App.Helper;
using BookingTour.App.Models;
using MySql.Data.MySqlClient;

namespace BookingTour.App.Dao;

public class ActivityDao
{
    private static readonly Lazy<ActivityDao> _instance = new(() => new ActivityDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static ActivityDao Instance => _instance.Value;

    //Example
    public ICollection<Activity> GetAll()
    {
        const string query = "SELECT * FROM activity";

        var parameters = Array.Empty<MySqlParameter>();
        var result = _dbHelper.ExecuteQuery(query, parameters);

        return (from DataRow row in result.Rows
            select new Activity
            {
                Id = Convert.ToInt32(row["id"]), 
                Name = row["name"].ToString(),
                Description = row["description"].ToString()
            }).ToList();
    }
    
    // Lấy Activity theo Id
    public Activity? GetById(int id)
    {
        const string query = "SELECT * FROM activity WHERE id = @Id";
        var parameters = new[]
        {
            new MySqlParameter("@Id", id)
        };

        var result = _dbHelper.ExecuteQuery(query, parameters);
        var row = result.Rows.Cast<DataRow>().FirstOrDefault();

        return row == null ? null : new Activity
        {
            Id = Convert.ToInt32(row["id"]),
            Name = row["name"].ToString()!,
            Description = row["description"].ToString()!,
            PlaceId = row.IsNull("place_id") ? null : (int?)Convert.ToInt32(row["place_id"])
        };
    }
    
    public List<Activity> GetByPlaceId(int placeId)
    {
        const string query = "SELECT * FROM activity WHERE place_id = @PlaceId";
        var parameters = new[]
        {
            new MySqlParameter("@PlaceId", placeId)
        };

        var result = _dbHelper.ExecuteQuery(query, parameters);

        return (from DataRow row in result.Rows
            select new Activity
            {
                Id = Convert.ToInt32(row["id"]),
                Name = row["name"].ToString()!,
                Description = row["description"].ToString()!,
                PlaceId = row.IsNull("place_id") ? null : (int?)Convert.ToInt32(row["place_id"])
            }).ToList();
    }
    
    // Thêm mới Activity
    public int AddActivity(Activity activity)
    {
        const string query = @"
            INSERT INTO activity (name, description, place_id) 
            VALUES (@Name, @Description, @PlaceId)";

        var parameters = new[]
        {
            new MySqlParameter("@Name", activity.Name),
            new MySqlParameter("@Description", activity.Description),
            new MySqlParameter("@PlaceId", activity.PlaceId ?? (object)DBNull.Value)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters);
    }

    // Cập nhật Activity
    public int UpdateActivity(Activity activity)
    {
        const string query = @"
            UPDATE activity 
            SET name = @Name, 
                description = @Description, 
                place_id = @PlaceId 
            WHERE id = @Id";

        var parameters = new[]
        {
            new MySqlParameter("@Id", activity.Id),
            new MySqlParameter("@Name", activity.Name),
            new MySqlParameter("@Description", activity.Description),
            new MySqlParameter("@PlaceId", activity.PlaceId ?? (object)DBNull.Value)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters);
    }
    
    public int Count()
    {
        const string query = "SELECT COUNT(*) FROM activity";

        return Convert.ToInt32(_dbHelper.ExecuteScalar(query));
    }
}