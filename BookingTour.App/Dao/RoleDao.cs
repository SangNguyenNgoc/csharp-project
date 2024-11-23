using System.Data;
using BookingTour.App.Helper;
using BookingTour.App.Models;
using MySql.Data.MySqlClient;

namespace BookingTour.App.Dao;

public class RoleDao
{
    private static readonly Lazy<RoleDao> _instance = new(() => new RoleDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;
    public static RoleDao Instance => _instance.Value;
    
    public ICollection<Role> GetAll()
    {
        const string query = "SELECT * FROM role";
        
        var result = _dbHelper.ExecuteQuery(query);

        return (from DataRow row in result.Rows 
            select new Role
        {
            Id = Convert.ToInt32(row["id"]), 
            Name = row["name"].ToString() ?? ""
        }).ToList();
    }

    // Lấy vai trò theo ID
    public Role? GetById(int roleId)
    {
        const string query = "SELECT * FROM Role WHERE id = @RoleId";
        
        var parameters = new MySqlParameter[]
        {
            new("@RoleId", roleId)
        };
        
        var result = _dbHelper.ExecuteQuery(query, parameters);

        if (result.Rows.Count == 0)
            return null;

        var row = result.Rows[0];
        return new Role
        {
            Id = Convert.ToInt32(row["id"]),
            Name = row["name"].ToString() ?? ""
        };
    }

    // Tạo vai trò mới
    public int Create(Role role)
    {
        const string query = "INSERT INTO Role (name) VALUES (@Name)";
        
        var parameters = new MySqlParameter[]
        {
            new("@RoleName", role.Name)
        };
        
        return _dbHelper.ExecuteNonQuery(query, parameters);
    }
}