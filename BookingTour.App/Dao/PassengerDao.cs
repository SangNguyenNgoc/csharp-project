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

    public int CreateLastId(Passenger passenger)
    {
        const string query = @"
        INSERT INTO passenger ( name, email, phone_number, age)
        VALUES (@Name, @Email, @PhoneNumber, @Age);
        SELECT LAST_INSERT_ID();";  // Trả về ID của bản ghi vừa chèn

        var parameters = new MySql.Data.MySqlClient.MySqlParameter[]
        {
            new("@Name", passenger.Name),
            new("@Email", passenger.Email),
            new("@PhoneNumber", passenger.PhoneNumber),
            new("@Age", passenger.Age),
        };

        // Thực hiện câu lệnh và lấy ID vừa tạo
        object result = _dbHelper.ExecuteScalar(query, parameters);

        // Trả về ID nếu có, hoặc -1 nếu không thành công
        return result != null ? Convert.ToInt32(result) : -1;
    }

    public List<Passenger> GetPassengersOfBill(int billId)
    {

        const string query = @"SELECT p.id,p.name,p.email,p.phone_number,age FROM bill b join ticket ti on b.id=ti.bill_id join passenger p on p.id=ti.passenger_id
                               WHERE b.id =@billId";

        var parameters = new[]
        {
            new MySqlParameter("@billId", MySqlDbType.Int32) { Value = billId }
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