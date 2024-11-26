using BookingTour.App.Helper;
using BookingTour.App.Models;
using MySql.Data.MySqlClient;

namespace BookingTour.App.Dao;

public class StatisticsDao
{
    private static readonly Lazy<StatisticsDao> _instance = new(() => new StatisticsDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static StatisticsDao Instance => _instance.Value;

    // Thống kê doanh thu và số lượng tour theo khoảng thời gian
    public List<StatisticsByTime> GetStatisticsByTime(DateOnly startDate, DateOnly endDate)
    {
        var query = @"SELECT DATE_FORMAT(t.date_start, '%Y-%m') AS period,
                         SUM(b.total_price) AS total_revenue,
                         COUNT(DISTINCT t.id) AS total_tours,
                         COUNT(ti.id) AS total_tickets
                  FROM tour t
                  LEFT JOIN ticket ti ON ti.tour_id = t.id
                  LEFT JOIN bill b ON b.id = ti.bill_id
                  WHERE t.date_start BETWEEN @startDate AND @endDate
                  GROUP BY period
                  ORDER BY period";

        var parameters = new[]
        {
            new MySqlParameter("@startDate", MySqlDbType.Date) { Value = startDate.ToDateTime(TimeOnly.MinValue) },
            new MySqlParameter("@endDate", MySqlDbType.Date) { Value = endDate.ToDateTime(TimeOnly.MinValue) }
        };

        return _dbHelper.ExecuteQueryToEntities(query, reader =>
            new StatisticsByTime
            {
                Period = reader.GetString("period"),
                TotalRevenue = reader.IsDBNull(reader.GetOrdinal("total_revenue")) ? 0 : reader.GetDecimal("total_revenue"),
                TotalTours = reader.GetInt32("total_tours"),
                TotalTickets = reader.GetInt32("total_tickets") // Thống kê số lượng vé
            }, parameters);
    }

    // Thống kê doanh thu và số lượng tour theo itinerary
    public List<StatisticsByItinerary> GetStatisticsByItinerary(DateOnly? startDate = null, DateOnly? endDate = null)
    {
        var query = @"SELECT i.id AS itinerary_id,
                         i.name AS itinerary_name,
                         SUM(b.total_price) AS total_revenue,
                         COUNT(DISTINCT t.id) AS total_tours
                  FROM itinerary i
                  LEFT JOIN tour t ON i.id = t.itinerary_id
                  LEFT JOIN ticket ti ON t.id = ti.tour_id
                  LEFT JOIN bill b ON b.id = ti.bill_id
                  WHERE 1=1"; // Điều kiện mặc định để thêm các bộ lọc

        var parameters = new List<MySqlParameter>();

        // Thêm điều kiện lọc theo thời gian nếu có
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

        query += " GROUP BY i.id, i.name ORDER BY total_revenue DESC";

        // Thực thi truy vấn và ánh xạ dữ liệu
        return _dbHelper.ExecuteQueryToEntities(query, reader =>
            new StatisticsByItinerary
            {
                ItineraryId = reader.GetInt32("itinerary_id"),
                ItineraryName = reader.GetString("itinerary_name"),
                TotalRevenue = reader.IsDBNull(reader.GetOrdinal("total_revenue")) ? 0 : reader.GetDecimal("total_revenue"),
                TotalTours = reader.GetInt32("total_tours")
            }, parameters.ToArray());
    }


    // Thống kê doanh thu và tỷ lệ lấp đầy của từng tour
    public List<StatisticsByTour> GetStatisticsByTour(DateOnly? startDate = null, DateOnly? endDate = null)
    {
        var query = @"SELECT t.id AS tour_id,
                         t.date_start,
                         t.date_end,
                         SUM(b.total_price) AS total_revenue,
                         t.capacity,
                         (t.capacity - t.remaining_slots) AS booked_slots,
                         ROUND((t.capacity - t.remaining_slots) / t.capacity * 100, 2) AS fill_rate
                  FROM tour t
                  LEFT JOIN ticket ti ON t.id = ti.tour_id
                  LEFT JOIN bill b ON ti.bill_id = b.id
                  WHERE 1=1"; // Luôn đúng để dễ thêm điều kiện

        var parameters = new List<MySqlParameter>();

        // Thêm điều kiện lọc theo khoảng thời gian
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

        // Nhóm và sắp xếp kết quả
        query += @" GROUP BY t.id, t.date_start, t.date_end, t.capacity, t.remaining_slots
                ORDER BY total_revenue DESC";

        return _dbHelper.ExecuteQueryToEntities(query, reader =>
            new StatisticsByTour
            {
                TourId = reader.GetInt32("tour_id"),
                DateStart = reader.GetDateTime("date_start"),
                DateEnd = reader.GetDateTime("date_end"),
                TotalRevenue = reader.IsDBNull(reader.GetOrdinal("total_revenue")) 
                    ? 0 
                    : reader.GetDecimal("total_revenue"),
                Capacity = reader.GetInt32("capacity"),
                BookedSlots = reader.GetInt32("booked_slots"),
                FillRate = reader.GetDouble("fill_rate")
            }, parameters.ToArray());
    }
}