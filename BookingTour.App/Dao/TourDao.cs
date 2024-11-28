using System.Data;
using BookingTour.App.Helper;
using BookingTour.App.Models;
using MySql.Data.MySqlClient;

namespace BookingTour.App.Dao;

public class TourDao
{
    private static readonly Lazy<TourDao> _instance = new(() => new TourDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static TourDao Instance => _instance.Value;

    public List<Tour> GetPaginatedTours(string keyword, DateOnly? startDate = null,
        DateOnly? endDate = null, int? minPrice = null, int? maxPrice = null)
    {
        var query = @"SELECT t.id, t.date_start, t.date_end, t.itinerary_id, t.price, t.capacity, t.remaining_slots,
                         i.id AS itinerary_id, i.name AS itinerary_name, i.description AS itinerary_description
                  FROM tour t
                  LEFT JOIN itinerary i ON t.itinerary_id = i.id
                  WHERE 1=1";

        var parameters = new List<MySqlParameter>();

        if (!string.IsNullOrEmpty(keyword))
        {
            query +=
                " AND (i.name LIKE @keyword OR t.id LIKE @keyword OR t.capacity LIKE @keyword OR t.remaining_slots LIKE @keyword)";
            parameters.Add(new MySqlParameter("@keyword", MySqlDbType.VarChar) { Value = $"%{keyword}%" });
        }

        if (startDate.HasValue)
        {
            query += " AND t.date_start >= @startDate";
            parameters.Add(new MySqlParameter("@startDate", MySqlDbType.Date)
                { Value = startDate.Value.ToDateTime(TimeOnly.MinValue) });
        }

        if (endDate.HasValue)
        {
            query += " AND t.date_end <= @endDate";
            parameters.Add(new MySqlParameter("@endDate", MySqlDbType.Date)
                { Value = endDate.Value.ToDateTime(TimeOnly.MinValue) });
        }

        if (minPrice.HasValue)
        {
            query += " AND t.price >= @minPrice";
            parameters.Add(new MySqlParameter("@minPrice", MySqlDbType.Int32) { Value = minPrice.Value });
        }

        if (maxPrice.HasValue)
        {
            query += " AND t.price <= @maxPrice";
            parameters.Add(new MySqlParameter("@maxPrice", MySqlDbType.Int32) { Value = maxPrice.Value });
        }

        return _dbHelper.ExecuteQueryToEntities(query, reader =>
        {
            return new Tour
            {
                Id = reader.GetInt32("id"),
                DateStart = reader.IsDBNull("date_start")
                    ? null
                    : DateOnly.FromDateTime(reader.GetDateTime("date_start")),
                DateEnd = reader.IsDBNull("date_end") ? null : DateOnly.FromDateTime(reader.GetDateTime("date_end")),
                ItineraryId = reader.IsDBNull("itinerary_id") ? null : reader.GetInt32("itinerary_id"),
                Price = reader.IsDBNull("price") ? null : reader.GetDouble("price"),
                Capacity = reader.IsDBNull("capacity") ? null : reader.GetInt32("capacity"),
                RemainingSlots = reader.IsDBNull("remaining_slots") ? null : reader.GetInt32("remaining_slots"),
                Itinerary = reader.IsDBNull("itinerary_id")
                    ? null
                    : new Itinerary
                    {
                        Id = reader.GetInt32("itinerary_id"),
                        Name = reader.IsDBNull("itinerary_name") ? "" : reader.GetString("itinerary_name"),
                        Description = reader.IsDBNull("itinerary_description")
                            ? ""
                            : reader.GetString("itinerary_description")
                    }
            };
        }, parameters.ToArray());
    }

    public List<Tour> GetToursOfGuide(int guideId)
    {
        
        var query = @"SELECT t.id, t.date_start, t.date_end, t.itinerary_id, t.price, t.capacity, t.remaining_slots,
                         i.id AS itinerary_id, i.name AS itinerary_name, i.description AS itinerary_description
                  FROM tour t
                  LEFT JOIN itinerary i ON t.itinerary_id = i.id
                  JOIN tour_guides tg ON t.id = tg.tour_id
                  WHERE tg.guide_id = @guideId";

        var parameters = new[]
        {
            new MySqlParameter("@guideId", MySqlDbType.Int32) { Value = guideId }
        };

        return _dbHelper.ExecuteQueryToEntities(query, reader =>
            new Tour
            {
                Id = reader.GetInt32("id"),
                DateStart = reader.IsDBNull("date_start")
                    ? null
                    : DateOnly.FromDateTime(reader.GetDateTime("date_start")),
                DateEnd = reader.IsDBNull("date_end") ? null : DateOnly.FromDateTime(reader.GetDateTime("date_end")),
                ItineraryId = reader.IsDBNull("itinerary_id") ? null : reader.GetInt32("itinerary_id"),
                Price = reader.IsDBNull("price") ? null : reader.GetDouble("price"),
                Capacity = reader.IsDBNull("capacity") ? null : reader.GetInt32("capacity"),
                RemainingSlots = reader.IsDBNull("remaining_slots") ? null : reader.GetInt32("remaining_slots"),
                Itinerary = reader.IsDBNull("itinerary_id")
                    ? null
                    : new Itinerary
                    {
                        Id = reader.GetInt32("itinerary_id"),
                        Name = reader.IsDBNull("itinerary_name") ? "" : reader.GetString("itinerary_name"),
                        Description = reader.IsDBNull("itinerary_description")
                            ? ""
                            : reader.GetString("itinerary_description")
                    }
            }, parameters);
    }

    public int UpdateTour(Tour tour)
    {
        var query = @"UPDATE tour SET 
                        date_start = @DateStart,
                        date_end = @DateEnd,
                        itinerary_id = @ItineraryId,
                        price = @Price,
                        capacity = @Capacity,
                        remaining_slots = @RemainingSlots
                      WHERE id = @Id";

        var parameters = new[]
        {
            new MySqlParameter("@Id", tour.Id),
            new MySqlParameter("@DateStart",
                tour.DateStart.HasValue ? tour.DateStart.Value.ToDateTime(TimeOnly.MinValue) : (object)DBNull.Value),
            new MySqlParameter("@DateEnd",
                tour.DateEnd.HasValue ? tour.DateEnd.Value.ToDateTime(TimeOnly.MinValue) : (object)DBNull.Value),
            new MySqlParameter("@ItineraryId", tour.ItineraryId ?? (object)DBNull.Value),
            new MySqlParameter("@Price", tour.Price ?? (object)DBNull.Value),
            new MySqlParameter("@Capacity", tour.Capacity ?? (object)DBNull.Value),
            new MySqlParameter("@RemainingSlots", tour.RemainingSlots ?? (object)DBNull.Value)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters);
    }

    // Hàm thêm tour mới
    public int AddTour(Tour tour)
    {
        var query = @"INSERT INTO tour (date_start, date_end, itinerary_id, price, capacity, remaining_slots) 
                      VALUES (@DateStart, @DateEnd, @ItineraryId, @Price, @Capacity, @RemainingSlots)";

        var parameters = new[]
        {
            new MySqlParameter("@DateStart",
                tour.DateStart.HasValue ? tour.DateStart.Value.ToDateTime(TimeOnly.MinValue) : (object)DBNull.Value),
            new MySqlParameter("@DateEnd",
                tour.DateEnd.HasValue ? tour.DateEnd.Value.ToDateTime(TimeOnly.MinValue) : (object)DBNull.Value),
            new MySqlParameter("@ItineraryId", tour.ItineraryId ?? (object)DBNull.Value),
            new MySqlParameter("@Price", tour.Price ?? (object)DBNull.Value),
            new MySqlParameter("@Capacity", tour.Capacity ?? (object)DBNull.Value),
            new MySqlParameter("@RemainingSlots", tour.RemainingSlots ?? (object)DBNull.Value)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters);
    }

    public Tour? GetById(int id)
    {
        var query =
            "SELECT id, date_start, date_end, itinerary_id, price, capacity, remaining_slots FROM tour WHERE id = @id";

        var parameters = new[]
        {
            new MySqlParameter("@id", MySqlDbType.Int32) { Value = id }
        };

        return _dbHelper.ExecuteQueryToEntities(query, reader =>
            new Tour
            {
                Id = reader.GetInt32("id"),
                DateStart = reader.IsDBNull("date_start")
                    ? null
                    : DateOnly.FromDateTime(reader.GetDateTime("date_start")),
                DateEnd = reader.IsDBNull("date_end") ? null : DateOnly.FromDateTime(reader.GetDateTime("date_end")),
                ItineraryId = reader.IsDBNull("itinerary_id") ? null : reader.GetInt32("itinerary_id"),
                Price = reader.IsDBNull("price") ? null : reader.GetDouble("price"),
                Capacity = reader.IsDBNull("capacity") ? null : reader.GetInt32("capacity"),
                RemainingSlots = reader.IsDBNull("remaining_slots") ? null : reader.GetInt32("remaining_slots")
            }, parameters).FirstOrDefault(); // Trả về phần tử đầu tiên hoặc null nếu không tìm thấy
    }

    public int Count()
    {
        var query = "SELECT COUNT(*) FROM tour";

        return Convert.ToInt32(_dbHelper.ExecuteScalar(query));
    }

    public ICollection<Tour> GetAllForBill()
    {

        const string query = @"
            SELECT t.id, t.date_start, t.date_end, t.price, t.capacity, t.remaining_slots,t.itinerary_id, i.name
            FROM tour t
            JOIN itinerary i ON t.itinerary_id = i.id
            where t.remaining_slots>0";
        var result = _dbHelper.ExecuteQuery(query);
        return (from DataRow row in result.Rows
                select new Tour
                {
                    Id = Convert.ToInt32(row["id"]),
                    Price = row["price"] != DBNull.Value ? Convert.ToInt32(row["price"]) : 0,
                    Capacity = row["capacity"] != DBNull.Value ? Convert.ToInt32(row["capacity"]) : 0,
                    RemainingSlots = row["remaining_slots"] != DBNull.Value ? Convert.ToInt32(row["remaining_slots"]) : 0,
                    DateStart = row["date_start"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(row["date_start"])) : (DateOnly?)null,
                    DateEnd = row["date_end"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(row["date_end"])) : (DateOnly?)null,
                    Itinerary = ItineraryDao.Instance.GetItineraryById(Convert.ToInt32(row["itinerary_id"]))
                }
                ).ToList();

    }

    public Tour GetToursOfBill(int billId)
    {

        const string query = @"SELECT * FROM bill b join ticket ti on b.id=ti.bill_id join tour t on t.id=ti.tour_id
                               WHERE b.id =@billId";

        var parameters = new[]
        {
            new MySqlParameter("@billId", MySqlDbType.Int32) { Value = billId }
        };
        var result = _dbHelper.ExecuteQuery(query, parameters);

        if (result.Rows.Count == 0)
            return null;

        var row = result.Rows[0];
        return new Tour
        {
            Id = Convert.ToInt32(row["tour_id"]),
            DateStart = row["date_start"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(row["date_start"])) : (DateOnly?)null,
            DateEnd = row["date_end"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(row["date_end"])) : (DateOnly?)null,
        };

    }
}