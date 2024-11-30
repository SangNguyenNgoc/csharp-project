using System.Data;
using BookingTour.App.Helper;
using BookingTour.App.Models;
using MySql.Data.MySqlClient;

namespace BookingTour.App.Dao;

public class UserDao
{
    // ReSharper disable once InconsistentNaming
    private static readonly Lazy<UserDao> _instance = new(() => new UserDao());
    private readonly DatabaseHelper _dbHelper = DatabaseHelper.Instance;

    public static UserDao Instance => _instance.Value;
    
    public ICollection<User> GetAll()
    {
        const string query = "SELECT * FROM User";

        var result = _dbHelper.ExecuteQuery(query);

        return (from DataRow row in result.Rows
            select new User
            {
                Id = Convert.ToInt32(row["id"]),
                Username = row["username"].ToString(),
                Password = row["password"].ToString(),
                Name = row["name"].ToString(),
                // Age = row["age"] != DBNull.Value ? Convert.ToInt32(row["age"]) : null,
                Email = row["email"].ToString(),
                PhoneNumber = row["phone_number"].ToString(),
                IsBlock = row["is_block"] != DBNull.Value ? Convert.ToBoolean(row["is_block"]) : null,
                Role = RoleDao.Instance.GetById(Convert.ToInt32(row["role_id"])) // lấy Role tương ứng
            }).ToList();
    }
    
    public ICollection<User> GetUsersByRoleId(int roleId)
    {
        const string query = "SELECT * FROM User WHERE role_id = @roleId";

        var parameters = new List<MySqlParameter>
        {
            new("@roleId", roleId)
        };

        var result = _dbHelper.ExecuteQuery(query, parameters.ToArray());

        return (from DataRow row in result.Rows
            select new User
            {
                Id = Convert.ToInt32(row["id"]),
                Username = row["username"].ToString(),
                Password = row["password"].ToString(),
                Name = row["name"].ToString(),
                Email = row["email"].ToString(),
                PhoneNumber = row["phone_number"].ToString(),
                IsBlock = row["is_block"] != DBNull.Value ? Convert.ToBoolean(row["is_block"]) : null,
                Role = RoleDao.Instance.GetById(Convert.ToInt32(row["role_id"])) // Lấy Role tương ứng
            }).ToList();
    }


    public User? GetById(int id)
    {
        const string query = "SELECT * FROM User WHERE Id = @Id";
        
        var parameters = new MySqlParameter[]
        {
            new("@Id", id)
        };

        var result = _dbHelper.ExecuteQuery(query, parameters);

        if (result.Rows.Count == 0)
            return null;

        var row = result.Rows[0];
        return new User
        {
            Id = Convert.ToInt32(row["id"]),
            Username = row["username"].ToString(),
            Password = row["password"].ToString(),
            Name = row["name"].ToString(),
            // Age = row["Age"] != DBNull.Value ? Convert.ToInt32(row["Age"]) : null,
            Email = row["email"].ToString(),
            PhoneNumber = row["phone_number"].ToString(),
            IsBlock = row["is_block"] != DBNull.Value ? Convert.ToBoolean(row["is_block"]) : null,
            RoleId = Convert.ToInt32(row["role_id"]),
            Role = RoleDao.Instance.GetById(Convert.ToInt32(row["role_id"]))
        };
    }
    
    public User? GetByUsernameAndPassword(string username, string password)
    {
        const string query = "SELECT * FROM User WHERE username = @Username AND password = @Password";
    
        var parameters = new MySqlParameter[]
        {
            new("@Username", username),
            new("@Password", password)
        };

        var result = _dbHelper.ExecuteQuery(query, parameters);

        if (result.Rows.Count == 0)
            return null;

        var row = result.Rows[0];
        return new User
        {
            Id = Convert.ToInt32(row["id"]),
            Username = row["username"].ToString(),
            Password = row["password"].ToString(),
            Name = row["name"].ToString(),
            // Age = row["age"] != DBNull.Value ? Convert.ToInt32(row["age"]) : null,
            Email = row["email"].ToString(),
            PhoneNumber = row["phone_number"].ToString(),
            IsBlock = row["is_block"] != DBNull.Value ? Convert.ToBoolean(row["is_block"]) : null,
            Role = RoleDao.Instance.GetById(Convert.ToInt32(row["role_id"]))
        };
    }


    public int Create(User user)
    {
        const string query 
            = $"""
               INSERT INTO user (id, username, password, name, email, phone_number, is_block, role_id)
               VALUES (@Id ,@Username, @Password, @Name, @Email, @PhoneNumber, @IsBlock, @RoleId)
               """;
        
        var parameters = new MySqlParameter[]
        {
            new("@Id", user.Id),
            new("@Username", user.Username),
            new("@Password", user.Password),
            new("@Name", user.Name),
            // new("@Age", user.Age ?? (object)DBNull.Value),
            new("@Email", user.Email),
            new("@PhoneNumber", user.PhoneNumber),
            new("@IsBlock", user.IsBlock ?? (object)DBNull.Value),
            new("@RoleId", user.RoleId)
        };
        
        return _dbHelper.ExecuteNonQuery(query, parameters);
    }

    public int Update(User user)
    {
        const string query = @"
            UPDATE User
            SET username = @Username, 
                phone_number = @Password, 
                name = @Name, 
                email = @Email, 
                phone_number = @PhoneNumber, 
                is_block = @IsBlock, 
                role_id = @RoleId
            WHERE Id = @Id";
        
        var parameters = new MySqlParameter[]
        {
            new("@Username", user.Username),
            new("@Password", user.Password),
            new("@Name", user.Name),
            // new("@Age", user.Age ?? (object)DBNull.Value),
            new("@Email", user.Email),
            new("@PhoneNumber", user.PhoneNumber),
            new("@IsBlock", user.IsBlock ?? (object)DBNull.Value),
            new("@RoleId", user.RoleId),
            new("@Id", user.Id)
        };
        
        return _dbHelper.ExecuteNonQuery(query, parameters);
    }

    public int Delete(int id)
    {
        const string query = "DELETE FROM User WHERE Id = @Id";
        
        var parameters = new MySqlParameter[]
        {
            new("@Id", id)
        };
        
        return _dbHelper.ExecuteNonQuery(query, parameters);
    }
    
    public int DisableUser(int userId)
    {
        const string query = "UPDATE User SET is_block = TRUE WHERE Id = @Id";
    
        var parameters = new MySqlParameter[]
        {
            new("@Id", userId)
        };
    
        return _dbHelper.ExecuteNonQuery(query, parameters);
    }
    
    public int EnableUser(int userId)
    {
        const string query = "UPDATE User SET is_block = FALSE WHERE Id = @Id";
    
        var parameters = new MySqlParameter[]
        {
            new("@Id", userId)
        };
    
        return _dbHelper.ExecuteNonQuery(query, parameters);
    }
    
}