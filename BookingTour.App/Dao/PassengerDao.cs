using BookingTour.App.Helper;
using BookingTour.App.Models;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System.Data;

namespace BookingTour.App.Dao;

public class PassengerDao
{
    private static readonly Lazy<PassengerDao> _instance = new(() => new PassengerDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static PassengerDao Instance => _instance.Value;

    public List<Passenger> GetPassengersOfTour(int tourId)
    {
        var query = @"SELECT p.id, p.name, p.email, p.phone_number, p.age  FROM passenger p
            JOIN ticket ON ticket.passenger_id = p.id
            WHERE ticket.tour_id = @tourId";

        var parameters = new List<MySqlParameter>
        {
            new("@tourId", tourId)
        };

        return _dbHelper.ExecuteQueryToEntities(query, reader =>
            new Passenger
            {
                Id = reader.GetInt32("id"),
                Name = reader.GetString("name"),
                Email = reader.GetString("email"),
                PhoneNumber = reader.GetString("phone_number"),
                Age = reader.GetInt32("age")
            }, parameters.ToArray());
    }

    public ICollection<Passenger> GetAll()
    {
        const string query = "SELECT * FROM Passenger";

        var result = _dbHelper.ExecuteQuery(query);
        return (from DataRow row in result.Rows
                select new Passenger
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString(),
                    Email = row["email"].ToString(),
                    PhoneNumber = row["phone_number"].ToString(),
                    Age = Convert.ToInt32(row["age"])
                }).ToList();
        
    }
    public int Create(Passenger passenger)
    {
        const string query
            = $"""
               INSERT INTO passenger ( name, email, phone_number, age)
               VALUES (@Name, @Email, @PhoneNumber, @Age)
               """;

        var parameters = new MySqlParameter[]
        {
            new("@Name", passenger.Name),
            new("@Email", passenger.Email),
            new("@PhoneNumber", passenger.PhoneNumber),
            new("@Age", passenger.Age),
        };

        return _dbHelper.ExecuteNonQuery(query, parameters);
    }
}