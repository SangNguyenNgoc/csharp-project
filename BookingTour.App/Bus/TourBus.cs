using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Bus;

public class TourBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<TourBus> _instance = new(() => new TourBus());
    public static TourBus Instance => _instance.Value;
    private Logger _logger = Logger.Instance;
    
    public bool ValidateTour(Tour? tour, out string validateMessage)
    {
        validateMessage = string.Empty;
        if (tour == null)
        {
            validateMessage = "Tour object cannot be null.";
            return false; // Tour không được null
        }

        // Kiểm tra giá phải lớn hơn 0
        if (tour.Price is null or <= 0)
        {
            validateMessage = "Price must be greater than 0.";
            return false;
        }

        // Kiểm tra ngày bắt đầu phải tồn tại và phải ở tương lai
        if (tour.DateStart == null || tour.DateStart <= DateOnly.FromDateTime(DateTime.Today))
        {
            validateMessage = "DateStart must be greater than today.";
            return false; // DateStart phải lớn hơn ngày hiện tại
        }

        // Kiểm tra ngày kết thúc phải tồn tại và phải sau ngày bắt đầu
        if (tour.DateEnd == null || tour.DateEnd <= tour.DateStart)
        {
            validateMessage = "DateEnd must be greater than DateStart.";
            return false;
        }

        // Kiểm tra ItineraryId phải tồn tại (nếu cần)
        if (tour.ItineraryId is null or <= 0)
        {
            validateMessage = "ItineraryId must be a positive integer.";
            return false;
        }

        // Kiểm tra Capacity phải lớn hơn 0
        if (tour.Capacity is null or <= 0)
        {
            validateMessage = "Capacity must be greater than 0.";
            return false;
        }

        // Kiểm tra RemainingSlots phải lớn hơn hoặc bằng 0 và không lớn hơn Capacity
        if (tour.RemainingSlots == null || tour.RemainingSlots < 0 || tour.RemainingSlots > tour.Capacity)
        {
            validateMessage = "RemainingSlots must be greater than or equal to 0 and less than or equal to Capacity.";
            return false;
        }

        return true; // Tất cả kiểm tra đều hợp lệ
    }
    
    public Tour? CreateTour(Tour? tour)
    {  
        if (!ValidateTour(tour, out var validateMessage))
        {
            _logger.Log("Low", $"Failed to create tour: {validateMessage}");
            return null;
        }
        return _unit.Tour.AddTour(tour!) == 0 ? null : tour;
    }
    
    public Tour? UpdateTour(Tour? tour)
    {  
        if (!ValidateTour(tour, out var validateMessage))
        {
            _logger.Log("Low", $"Failed to update tour: {validateMessage}");
            return null;
        }
        if (tour?.Id == null)
        {
            return null;
        }

        var result = 0;
        _unit.ExecuteInTransaction(u =>
        {
            result = _unit.Tour.GetById(tour!.Id) == null ? 0 : _unit.Tour.UpdateTour(tour!);
        });
        
        return result == 0 ? null : tour;
    }
    
    public List<Tour?>? CreateTourForSchedule(Tour? tour, int repeat, int repeatTime)
    {
        if (tour == null || repeat < 0 || repeatTime < 1)
        {
            return null;
        }
        
        if (!ValidateTour(tour, out var validateMessage))
        {
            _logger.Log("Low", $"Failed to create tour for schedule: {validateMessage}");
            return null;
        }

        var result = new List<Tour?>();

        if (repeat == 0 )// lặp lại theo ngày
        {
            for (var i = 0; i < repeatTime*30; i++)
            {
                var newTour = new Tour
                {
                    Price = tour.Price,
                    DateStart = tour.DateStart!.Value.AddDays(i),
                    DateEnd = tour.DateEnd!.Value.AddDays(i),
                    ItineraryId = tour.ItineraryId,
                    Capacity = tour.Capacity,
                    RemainingSlots = tour.Capacity
                };
                result.Add(CreateTour(newTour));
            }
        }
        else if (repeat == 1) // lặp lại theo tuần
        {
            var numberOfWeeks = (repeatTime * 30) / 7;
            for (var i = 0; i < numberOfWeeks; i++)
            {
                var newTour = new Tour
                {
                    Price = tour.Price,
                    DateStart = tour.DateStart!.Value.AddDays(i * 7),
                    DateEnd = tour.DateEnd!.Value.AddDays(i * 7),
                    ItineraryId = tour.ItineraryId,
                    Capacity = tour.Capacity,
                    RemainingSlots = tour.Capacity
                };
                result.Add(CreateTour(newTour));
            }
        }
        else if (repeat == 2) // lặp lại theo tháng
        {
            for (var i = 0; i < repeatTime; i++)
            {
                var newTour = new Tour
                {
                    Price = tour.Price,
                    DateStart = tour.DateStart!.Value.AddMonths(i),
                    DateEnd = tour.DateEnd!.Value.AddMonths(i),
                    ItineraryId = tour.ItineraryId,
                    Capacity = tour.Capacity,
                    RemainingSlots = tour.Capacity
                };
                result.Add(CreateTour(newTour));
            }
        }

        if (result.Count == 0)
        {
            return null;
        }
        
        _unit.ExecuteInTransaction(u =>
        {
            foreach (var addTour in result)
            {
                u.Tour.AddTour(addTour!);
            }
        });
        return result;
    }
    
    public List<Tour> GetPaginatedTours(string keyword, DateOnly? startDate = null,
        DateOnly? endDate = null, int? minPrice = null, int? maxPrice = null)
    {
        return _unit.Tour.GetPaginatedTours(keyword, startDate, endDate, minPrice, maxPrice);
    }
    
    // get tours of guide by guideId
    public List<Tour> GetToursOfGuide(int guideId)
    {
        return _unit.Tour.GetToursOfGuide(guideId);
    }
}