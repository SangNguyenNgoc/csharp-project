using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Bus;

public class BillBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<BillBus> _instance = new(() => new BillBus());
    public static BillBus Instance => _instance.Value;

    public ICollection<Bill> GetAllBills()
    {
        return _unit.Bill.GetAll();
    }
    public Bill GetBillById(int id)
    {
        return _unit.Bill.GetBillById(id);
    }
    public int CreateBill(Bill bill)
    {
        return _unit.Bill.Create(bill);
    }
}