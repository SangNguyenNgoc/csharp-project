using System.Data;
using BookingTour.App.Helper;
using BookingTour.App.Models;
using MySql.Data.MySqlClient;

namespace BookingTour.App.Dao;

public class ServiceDao
{
    private static readonly Lazy<ServiceDao> _instance = new(() => new ServiceDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static ServiceDao Instance => _instance.Value;
    
    // Hàm thêm mới Service
    public int AddService(Service service)
    {
        const string query = @"
            INSERT INTO service (name, type, description) 
            VALUES (@Name, @Type, @Description)";

        var parameters = new[]
        {
            new MySqlParameter("@Name", service.Name ?? (object)DBNull.Value),
            new MySqlParameter("@Type", service.Type ?? (object)DBNull.Value),
            new MySqlParameter("@Description", service.Description ?? (object)DBNull.Value)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters);
    }

    // Hàm cập nhật Service
    public int UpdateService(Service service)
    {
        const string query = @"
            UPDATE service 
            SET name = @Name, 
                type = @Type, 
                description = @Description 
            WHERE id = @Id";

        var parameters = new[]
        {
            new MySqlParameter("@Id", service.Id),
            new MySqlParameter("@Name", service.Name ?? (object)DBNull.Value),
            new MySqlParameter("@Type", service.Type ?? (object)DBNull.Value),
            new MySqlParameter("@Description", service.Description ?? (object)DBNull.Value)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters);
    }

    // Hàm lấy tất cả Services
    public List<Service> GetAllServices()
    {
        const string query = @"
            SELECT id, name, type, description 
            FROM service";

        return _dbHelper.ExecuteQueryToEntities(query, reader =>
        {
            return new Service
            {
                Id = reader.GetInt32("id"),
                Name = reader.IsDBNull("name") ? null : reader.GetString("name"),
                Type = reader.IsDBNull("type") ? null : reader.GetString("type"),
                Description = reader.IsDBNull("description") ? null : reader.GetString("description")
            };
        });
    }

    // Hàm lấy Service theo Id
    public Service? GetServiceById(int id)
    {
        const string query = @"
            SELECT id, name, type, description 
            FROM service
            WHERE id = @Id";

        var parameters = new[]
        {
            new MySqlParameter("@Id", id)
        };

        var results = _dbHelper.ExecuteQueryToEntities(query, reader =>
        {
            return new Service
            {
                Id = reader.GetInt32("id"),
                Name = reader.IsDBNull("name") ? null : reader.GetString("name"),
                Type = reader.IsDBNull("type") ? null : reader.GetString("type"),
                Description = reader.IsDBNull("description") ? null : reader.GetString("description")
            };
        }, parameters);

        return results.FirstOrDefault();
    }
    
    public int Count()
    {
        const string query = "SELECT COUNT(*) FROM service";
        return Convert.ToInt32(_dbHelper.ExecuteScalar(query));
    }
}