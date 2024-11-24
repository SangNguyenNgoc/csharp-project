using BookingTour.App.Helper;
using BookingTour.App.Models;
using MySql.Data.MySqlClient;

namespace BookingTour.App.Dao;

public class GuideDao
{
    private static readonly Lazy<GuideDao> _instance = new(() => new GuideDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static GuideDao Instance => _instance.Value;

    public List<Guide> GetGuidesOfTour(int tourId)
    {
        var query =
            @"SELECT g.id as id, g.language as languague, u.name as name, u.email as email, u.phone_number as phone 
            FROM guides g
            JOIN user u on g.account_id = u.id
            JOIN tour_guides tg on tg.guide_id = u.id
            WHERE tg.tour_id = @tourId";

        var parameters = new List<MySqlParameter>
        {
            new("@tourId", tourId)
        };

        return _dbHelper.ExecuteQueryToEntities(query, reader =>
            new Guide
            {
                Id = reader.GetInt32("id"),
                Language = reader.GetString("languague"),
                Account = new User
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Email = reader.GetString("email"),
                    PhoneNumber = reader.GetString("phone")
                }
            }, parameters.ToArray());
    }
}