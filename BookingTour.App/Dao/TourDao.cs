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

    public List<Tour> GetPaginatedTours(string keyword, int page, int pageSize, DateOnly? startDate = null,
        DateOnly? endDate = null, int? minCapacity = null, int? maxCapacity = null, int? minRemainingSlots = null, int? maxRamainingSlots = null)
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

        if (minCapacity.HasValue)
        {
            query += " AND t.capacity >= @minCapacity";
            parameters.Add(new MySqlParameter("@minCapacity", MySqlDbType.Int32) { Value = minCapacity.Value });
        }

        if (maxCapacity.HasValue)
        {
            query += " AND t.capacity <= @maxCapacity";
            parameters.Add(new MySqlParameter("@maxCapacity", MySqlDbType.Int32) { Value = maxCapacity.Value });
        }
        
        if(minRemainingSlots.HasValue)
        {
            query += " AND t.remaining_slots >= @minRemainingSlots";
            parameters.Add(new MySqlParameter("@minRemainingSlots", MySqlDbType.Int32) { Value = minRemainingSlots.Value });
        }
        
        if(maxRamainingSlots.HasValue)
        {
            query += " AND t.remaining_slots <= @maxRamainingSlots";
            parameters.Add(new MySqlParameter("@maxRamainingSlots", MySqlDbType.Int32) { Value = maxRamainingSlots.Value });
        }

        query += " LIMIT @offset, @pageSize";
        parameters.Add(new MySqlParameter("@offset", MySqlDbType.Int32) { Value = (page - 1) * pageSize });
        parameters.Add(new MySqlParameter("@pageSize", MySqlDbType.Int32) { Value = pageSize });

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
}