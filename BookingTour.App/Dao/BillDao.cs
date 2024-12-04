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



    public int Create(Bill bill)
    {
        const string query = @"
        INSERT INTO bill (total_passenger, total_price, invoice_issuer)
        VALUES (@TotalPassenger, @TotalPrice, @InvoiceIssuer);
        SELECT LAST_INSERT_ID();";  // Trả về ID của bản ghi vừa chèn

        var parameters = new MySql.Data.MySqlClient.MySqlParameter[]
        {
        new("@TotalPassenger", bill.TotalPassenger),
        new("@TotalPrice", bill.TotalPrice),
        new("@InvoiceIssuer", bill.InvoiceIssuer)
        };

        // Thực hiện câu lệnh và lấy ID vừa tạo
        object result = _dbHelper.ExecuteScalar(query, parameters);

        // Trả về ID nếu có, hoặc -1 nếu không thành công
        return result != null ? Convert.ToInt32(result) : -1;
    }

    public int Update(Bill bill)
    {
        const string query = @"
            UPDATE bill
            SET 
                total_passenger = @TotalPassenger, 
                total_price = @TotalPrice, 
                invoice_issuer = @InvoiceIssuer
            WHERE id = @Id;
            ";  // Cập nhật bản ghi dựa trên ID

        var parameters = new MySql.Data.MySqlClient.MySqlParameter[]
        {
        new("@Id", bill.Id),  // Thêm tham số ID
        new("@TotalPassenger", bill.TotalPassenger),
        new("@TotalPrice", bill.TotalPrice),
        new("@InvoiceIssuer", bill.InvoiceIssuer)
        };

        // Thực hiện câu lệnh và trả về số lượng bản ghi bị ảnh hưởng
        int rowsAffected = _dbHelper.ExecuteNonQuery(query, parameters);

        // Trả về số lượng bản ghi bị ảnh hưởng (1 nếu thành công, 0 nếu không có gì thay đổi)
        return rowsAffected;
    }


    public Bill GetBillById(int id)
    {
        const string query = "SELECT * FROM Bill WHERE Id = @Id";

        var parameters = new MySql.Data.MySqlClient.MySqlParameter[]
        {
            new("@Id", id)
        };

        var result = _dbHelper.ExecuteQuery(query, parameters);

        if (result.Rows.Count == 0)
            return null;

        var row = result.Rows[0];
        return new Bill
        {
            Id = Convert.ToInt32(row["id"]),
            TotalPassenger = Convert.ToInt32(row["total_passenger"]),
            TotalPrice = Convert.ToInt32(row["total_price"]),
        };
    }
}