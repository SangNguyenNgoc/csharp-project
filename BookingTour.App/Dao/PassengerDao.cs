using BookingTour.App.Helper;
using BookingTour.App.Models;
using MySql.Data.MySqlClient;

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
}