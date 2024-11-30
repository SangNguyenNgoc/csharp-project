using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Bus;

public class GuideBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<GuideBus> _instance = new(() => new GuideBus());
    public static GuideBus Instance => _instance.Value;
    
    // use this method to get guides of a tour
    public List<Guide> GetGuidesOfTour(int tourId)
    {
        return _unit.Guide.GetGuidesOfTour(tourId);
    }
    
    // Hàm lấy tất cả hướng dẫn viên
    public List<Guide> GetAllGuides()
    {
        return _unit.Guide.GetAllGuides();
    }
    
    public List<Guide> GetAllGuidesByAccount(int accountId)
    {
        return _unit.Guide.GetGuideByAccountId(accountId);
    }

    // Hàm tìm hướng dẫn viên theo ID
    public Guide? GetGuideById(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("ID không hợp lệ.");
        }
        return _unit.Guide.GetGuideById(id);
    }

    // Hàm thêm mới hướng dẫn viên
    public bool AddGuide(Guide guide)
    {
        if (string.IsNullOrWhiteSpace(guide.Language))
        {
            throw new ArgumentException("Thông tin hướng dẫn viên không hợp lệ.");
        }
        return _unit.Guide.AddGuide(guide);
    }
}