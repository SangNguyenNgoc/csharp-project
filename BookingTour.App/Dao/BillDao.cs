using BookingTour.App.Helper;
using BookingTour.App.Models;
using System.Data;

namespace BookingTour.App.Dao;

public class BillDao
{
    private static readonly Lazy<BillDao> _instance = new(() => new BillDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static BillDao Instance => _instance.Value;

    public ICollection<Bill> GetAll()
    {
        const string query = "SELECT * FROM Bill";

        var result = _dbHelper.ExecuteQuery(query);

        return (from DataRow row in result.Rows
                select new Bill
                {
                    Id = Convert.ToInt32(row["id"]),
                    TotalPassenger = Convert.ToInt32(row["total_passenger"]),
                    TotalPrice = Convert.ToDouble(row["total_price"]),
                    InvoiceIssuerNavigation = UserDao.Instance.GetById(Convert.ToInt32(row["invoice_issuer"])) // lấy User tương ứng
                }).ToList();
    }
}