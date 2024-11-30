using BookingTour.App.Helper;
using MySql.Data.MySqlClient;

namespace BookingTour.App.Dao;

public class TourGuideDao
{
    private static readonly Lazy<TourGuideDao> _instance = new(() => new TourGuideDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static TourGuideDao Instance => _instance.Value;
    
    // Hàm thêm mới quan hệ tour-guide
    public bool AddTourGuide(int tourId, int guideId)
    {
        var query = @"INSERT INTO tour_guides (tour_id, guide_id) VALUES (@tourId, @guideId)";
        var parameters = new List<MySqlParameter>
        {
            new("@tourId", tourId),
            new("@guideId", guideId)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters.ToArray()) > 0;
    }

    // // Hàm lấy tất cả hướng dẫn viên theo tour
    // public List<int> GetGuideIdsByTourId(int tourId)
    // {
    //     var query = @"SELECT guide_id FROM tour_guides WHERE tour_id = @tourId";
    //     var parameters = new List<MySqlParameter>
    //     {
    //         new("@tourId", tourId)
    //     };
    //
    //     return _dbHelper.ExecuteQueryToList(query, reader => reader.GetInt32("guide_id"), parameters.ToArray());
    // }

    // Hàm xóa một hướng dẫn viên khỏi tour
    public bool DeleteTourGuide(int tourId, int guideId)
    {
        var query = @"DELETE FROM tour_guides WHERE tour_id = @tourId AND guide_id = @guideId";
        var parameters = new List<MySqlParameter>
        {
            new("@tourId", tourId),
            new("@guideId", guideId)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters.ToArray()) > 0;
    }

    // Hàm xóa tất cả hướng dẫn viên khỏi tour
    public bool DeleteGuidesByTourId(int tourId)
    {
        var query = @"DELETE FROM tour_guides WHERE tour_id = @tourId";
        var parameters = new List<MySqlParameter>
        {
            new("@tourId", tourId)
        };

        return _dbHelper.ExecuteNonQuery(query, parameters.ToArray()) > 0;
    }
}