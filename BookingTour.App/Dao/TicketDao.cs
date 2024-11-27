using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Dao;

public class TicketDao
{
    private static readonly Lazy<TicketDao> _instance = new(() => new TicketDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static TicketDao Instance => _instance.Value;

    public int Create(Ticket ticket)
    {
        const string query
            = $"""
               INSERT INTO Ticket ( price, passenger_id, bill_id, tour_id)
               VALUES (@Price, @PassengerId, @BillId,@TourId)
               """;

        var parameters = new MySql.Data.MySqlClient.MySqlParameter[]
        {
            new("@Price", ticket.Price),
            new("@PassengerId", ticket.PassengerId),
            new("@BillId", ticket.BillId),
            new("@TourId", ticket.TourId)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters);
    }
}