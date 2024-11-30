using BookingTour.App.Dao;
using BookingTour.App.Exception;
using BookingTour.App.Helper;
using BookingTour.App.Models;

namespace BookingTour.App.Bus;

public class UserBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;
    private static readonly Lazy<UserBus> _instance = new(() => new UserBus());
    public static UserBus Instance => _instance.Value;
    
    public ICollection<User> GetAllUsers()
    {
        return _unit.User.GetAll();
    }
    
    public ICollection<User> GetAllUsersByRole(int roleId)
    {
        return _unit.User.GetUsersByRoleId(roleId);
    }

    public int CreateUser(User user)
    {
        var role = _unit.Role.GetById(user.RoleId);
        if (role == null)
        {
            throw new ArgumentException("Role not found.");
        }
        return _unit.User.Create(user);
    }
    
    public int Disable(int userId)
    {
        var user = _unit.User.GetById(userId);
        if (user == null)
        {
            throw new ArgumentException("User not found.");
        }
        return _unit.User.DisableUser(userId);
    }

    public int EnableUser(int userId)
    {
        var user = _unit.User.GetById(userId);
        if (user == null)
        {
            throw new ArgumentException("User not found.");
        }
        return _unit.User.EnableUser(userId);
    }
    
    public int UpdateUser(User user)
    {
        var role = _unit.Role.GetById(user.RoleId);
        if (role == null)
        {
            throw new ArgumentException("Role not found.");
        }
        return _unit.User.Update(user);
    }
    
    public User? Login(string username, string password)
    {
        var user = _unit.User.GetByUsernameAndPassword(username, password) ?? throw new InvalidLoginException("Tên đăng nhập hoặc mật khẩu không đúng.");
        if (user.IsBlock == true)
        {
            throw new AccountBlockedException("Tài khoản đã bị khóa.");
        }
        return user;
    }

    public User GetUserById(int userId)
    {
        var user = UserDao.Instance.GetById(userId);
        if (user == null)
        {
            throw new ArgumentException("User not found.");
        }
        return user;
    }
    
    
}