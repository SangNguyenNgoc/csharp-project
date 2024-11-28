using BookingTour.App.Dao;
using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Bus;

public class ServiceBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<ServiceBus> _instance = new(() => new ServiceBus());
    public static ServiceBus Instance => _instance.Value;
    
    public bool ValidateService(Service? service, out string validationErrors)
    {
        validationErrors = String.Empty;

        if (service == null)
        {
            validationErrors = "Service object cannot be null.";
            return false;
        }

        // Validate Name
        if (string.IsNullOrWhiteSpace(service.Name))
        {
            validationErrors = "Name is required.";
            return false;
        }
        
        if (service.Name.Length > 100)
        {
            validationErrors = "Name cannot exceed 100 characters.";
            return false;
        }

        // Validate Description
        if (string.IsNullOrWhiteSpace(service.Description))
        {
            validationErrors = "Description cannot exceed 500 characters.";
            return false;
        }

        return true;
    }
    
    public Service? CreateService(Service? service)
    {
        if (!ValidateService(service, out var validationErrors))
        {
            Logger.Instance.Log("Low", $"Failed to create service: {validationErrors}");
            return null;
        }

        var result = 0;
        _unit.ExecuteInTransaction(u =>
        {
            service!.Id = AppUtil.GetCurrentDateIntWithNumber(u.Service.Count());
            result = u.Service.AddService(service);
        });

        return result == 0 ? null : service;
    }
    
    public Service? UpdateService(Service? service)
    {
        if (!ValidateService(service, out var validationErrors))
        {
            Logger.Instance.Log("Low", $"Failed to update service: {validationErrors}");
            return null;
        }
        if (service?.Id == null)
        {
            Logger.Instance.Log("Low", $"Failed to update service: Id is required.");
            return null;
        }

        var result = 0;
        _unit.ExecuteInTransaction(u =>
        {
            result = _unit.Service.GetServiceById(service!.Id) == null ? 0 : _unit.Service.UpdateService(service);
        });

        return result == 0 ? null : service;
    }

    public List<Service> GetAllServices()
    {
        try
        {
            return _unit.Service.GetAllServices();
        }
        catch (System.Exception ex)
        {
            // Log lỗi (nếu có) hoặc xử lý lỗi tại đây
            Console.WriteLine(@"Error while retrieving services: " + ex.Message);
            return [];
        }
    }
    
    public Service? GetServiceById(int id)
    {
        var service = _unit.Service.GetServiceById(id);

        if (service == null)
        {
            Console.WriteLine($@"Không tìm thấy Service với ID: {id}");
        }

        return service; 
    }

}