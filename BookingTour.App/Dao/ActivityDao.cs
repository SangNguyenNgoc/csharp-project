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
                Name = row["name"].ToString() 
            }).ToList();
    }
}