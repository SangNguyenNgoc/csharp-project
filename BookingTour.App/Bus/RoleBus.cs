using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Bus;

public class RoleBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<RoleBus> _instance = new(() => new RoleBus());
    public static RoleBus Instance => _instance.Value;
    
    public ICollection<Role> GetAllRoles()
    {
        return _unit.Role.GetAll(); 
    }

    public Role? GetRoleById(int roleId)
    {
        return _unit.Role.GetById(roleId);
    }

    public bool CreateRole(Role role)
    {
        if (string.IsNullOrEmpty(role.Name))
        {
            return false;
        }

        int result = _unit.Role.Create(role); 

        return result > 0; 
    }
}