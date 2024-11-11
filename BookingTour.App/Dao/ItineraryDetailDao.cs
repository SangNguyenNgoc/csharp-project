using System.Data;
using BookingTour.App.Helper;
using BookingTour.App.Models;
using MySql.Data.MySqlClient;

namespace BookingTour.App.Dao;

public class ItineraryDetailDao
{
    private static readonly Lazy<ItineraryDetailDao> _instance = new(() => new ItineraryDetailDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static ItineraryDetailDao Instance => _instance.Value;
    
    public ICollection<ItineraryDetail> GetByTourInterfaceId(int tourInterfaceId)
    {
        const string query = "SELECT * FROM itinerary_detail WHERE tour_interface_id = @TourInterfaceId";

        var parameters = new[]
        {
            new MySqlParameter("@TourInterfaceId", tourInterfaceId)
        };

        var result = _dbHelper.ExecuteQuery(query, parameters);

        return (from DataRow row in result.Rows
            select new ItineraryDetail
            {
                TourInterfaceId = Convert.ToInt32(row["tour_interface_id"]),
                ActivityId = Convert.ToInt32(row["activity_id"]),
                DayNumber = row["day_number"] as int?,
                ServiceId = row["service_id"] as int?,
                StartTime = row.IsNull("start_time") ? null : TimeOnly.FromDateTime(Convert.ToDateTime(row["start_time"])),
                EndTime = row.IsNull("end_time") ? null : TimeOnly.FromDateTime(Convert.ToDateTime(row["end_time"]))
            }).ToList();
    }

    // Thêm mới ItineraryDetail
    public int AddItineraryDetail(ItineraryDetail detail)
    {
        const string query = @"
            INSERT INTO itinerary_detail (tour_interface_id, activity_id, day_number, service_id, start_time, end_time) 
            VALUES (@TourInterfaceId, @ActivityId, @DayNumber, @ServiceId, @StartTime, @EndTime)";

        var parameters = new[]
        {
            new MySqlParameter("@TourInterfaceId", detail.TourInterfaceId),
            new MySqlParameter("@ActivityId", detail.ActivityId),
            new MySqlParameter("@DayNumber", detail.DayNumber ?? (object)DBNull.Value),
            new MySqlParameter("@ServiceId", detail.ServiceId ?? (object)DBNull.Value),
            new MySqlParameter("@StartTime", detail.StartTime?.ToString("HH:mm:ss") ?? (object)DBNull.Value),
            new MySqlParameter("@EndTime", detail.EndTime?.ToString("HH:mm:ss") ?? (object)DBNull.Value)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters);
    }

    // Xóa ItineraryDetail
    public int DeleteItineraryDetail(int tourInterfaceId, int activityId, int dayNumber)
    {
        const string query = @"DELETE FROM itinerary_detail 
                                WHERE tour_interface_id = @TourInterfaceId 
                                  AND activity_id = @ActivityId
                                  AND day_number = @DayNumber";

        var parameters = new[]
        {
            new MySqlParameter("@TourInterfaceId", tourInterfaceId),
            new MySqlParameter("@ActivityId", activityId),
            new MySqlParameter("@DayNumber", dayNumber),
        };

        return _dbHelper.ExecuteNonQuery(query, parameters);
    }
    
    public bool IsTimeSlotConflict(ItineraryDetail detail)
    {
        const string query = @"
        SELECT COUNT(*) 
        FROM itinerary_detail 
        WHERE tour_interface_id = @TourInterfaceId 
          AND day_number != @DayNumber
          AND (
              (start_time <= @EndTime AND end_time >= @StartTime)
          )";

        var parameters = new[]
        {
            new MySqlParameter("@TourInterfaceId", detail.TourInterfaceId),
            new MySqlParameter("@DayNumber", detail.DayNumber ?? (object)DBNull.Value),
            new MySqlParameter("@StartTime", detail.StartTime?.ToString("HH:mm:ss") ?? (object)DBNull.Value),
            new MySqlParameter("@EndTime", detail.EndTime?.ToString("HH:mm:ss") ?? (object)DBNull.Value)
        };

        var conflictCount = Convert.ToInt32(_dbHelper.ExecuteScalar(query, parameters));
        return conflictCount > 0;
    }
}