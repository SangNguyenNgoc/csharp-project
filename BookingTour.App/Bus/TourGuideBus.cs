using BookingTour.App.Helper;

namespace BookingTour.App.Bus;

public class TourGuideBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<TourGuideBus> _instance = new(() => new TourGuideBus());
    public static TourGuideBus Instance => _instance.Value;
    
    // Thêm mới quan hệ tour-guide
    public bool AddTourGuide(int tourId, int guideId)
    {
        if (tourId <= 0 || guideId <= 0)
        {
            throw new ArgumentException("Tour ID hoặc Guide ID không hợp lệ.");
        }
        return _unit.TourGuide.AddTourGuide(tourId, guideId);
    }

    // // Lấy danh sách hướng dẫn viên theo tour
    // public List<int> GetGuideIdsByTourId(int tourId)
    // {
    //     if (tourId <= 0)
    //     {
    //         throw new ArgumentException("Tour ID không hợp lệ.");
    //     }
    //     return _unit.TourGuide.GetGuideIdsByTourId(tourId);
    // }

    // Xóa một hướng dẫn viên khỏi tour
    public bool DeleteTourGuide(int tourId, int guideId)
    {
        if (tourId <= 0 || guideId <= 0)
        {
            throw new ArgumentException("Tour ID hoặc Guide ID không hợp lệ.");
        }
        return _unit.TourGuide.DeleteTourGuide(tourId, guideId);
    }

    // Xóa tất cả hướng dẫn viên khỏi tour
    public bool DeleteGuidesByTourId(int tourId)
    {
        if (tourId <= 0)
        {
            throw new ArgumentException("Tour ID không hợp lệ.");
        }
        return _unit.TourGuide.DeleteGuidesByTourId(tourId);
    }
}