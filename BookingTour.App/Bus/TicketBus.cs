using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Bus;

public class TicketBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<TicketBus> _instance = new(() => new TicketBus());
    public static TicketBus Instance => _instance.Value;

    public int CreateTicket(Ticket ticket)
    {
        return _unit.Ticket.Create(ticket);
    }

    public int DeleteTicketByBillId(int billId) {
        return _unit.Ticket.DeleteByBillId(billId);
    }
}