using System.Data;
using MySql.Data.MySqlClient;

namespace BookingTour.App.Helper;

using System;
using System.Data;
using MySql.Data.MySqlClient;

public sealed class DatabaseHelper : IDisposable
{
    // ReSharper disable once InconsistentNaming
    private static readonly Lazy<DatabaseHelper> _instance = new(() => new DatabaseHelper());
    private readonly MySqlConnection _connection;
    private MySqlTransaction? _transaction;
    private readonly Logger _logger;

    private DatabaseHelper()
    {
        const string connectionString = "Server=localhost;Database=tour;User ID=root;Password=;Pooling=false";
        _connection = new MySqlConnection(connectionString);
        _logger = Logger.Instance;
    }

    public static DatabaseHelper Instance => _instance.Value;

    public void OpenConnection()
    {
        if (_connection.State != ConnectionState.Closed) return;
        _connection.Open();
        _logger.Log("INFO", "Database connection opened.");
    }

    public void CloseConnection()
    {
        if (_connection.State != ConnectionState.Open) return;
        _connection.Close();
        _logger.Log("INFO", "Database connection closed.");
    }

    public void BeginTransaction()
    {
        OpenConnection();
        _transaction = _connection.BeginTransaction();
        _logger.Log("INFO", "Transaction started.");
    }

    public void CommitTransaction()
    {
        try
        {
            _transaction?.Commit();
            _logger.Log("INFO", "Transaction committed.");
        }
        catch (Exception ex)
        {
            _logger.Log("ERROR", $"Transaction commit failed: {ex.Message}");
            throw;
        }
        finally
        {
            CloseConnection();
        }
    }

    public void RollbackTransaction()
    {
        try
        {
            _transaction?.Rollback();
            _logger.Log("INFO", "Transaction rolled back.");
        }
        catch (Exception ex)
        {
            _logger.Log("ERROR", $"Transaction rollback failed: {ex.Message}");
            throw;
        }
        finally
        {
            CloseConnection();
        }
    }

    // Thực thi truy vấn (không trả về dữ liệu)
    public int ExecuteNonQuery(string query, params MySqlParameter[]? parameters)
    {
        using var command = new MySqlCommand(query, _connection, _transaction);
        if (parameters != null)
        {
            command.Parameters.AddRange(parameters);
        }

        OpenConnection();
        var rowsAffected = command.ExecuteNonQuery();
        _logger.Log("INFO", $"Executed non-query. Rows affected: {rowsAffected}");
        return rowsAffected;
    }

    // Thực thi truy vấn và trả về giá trị đơn (ExecuteScalar)
    public object? ExecuteScalar(string query, params MySqlParameter[]? parameters)
    {
        using var command = new MySqlCommand(query, _connection, _transaction);
        if (parameters != null)
        {
            command.Parameters.AddRange(parameters);
        }

        OpenConnection();
        var result = command.ExecuteScalar();
        _logger.Log("INFO", "Executed scalar query.");
        return result;
    }

    // Thực thi truy vấn và trả về DataTable (ExecuteReader)
    public DataTable ExecuteQuery(string query, params MySqlParameter[]? parameters)
    {
        using var command = new MySqlCommand(query, _connection, _transaction);
        if (parameters != null)
        {
            command.Parameters.AddRange(parameters);
        }

        OpenConnection();
        using var reader = command.ExecuteReader();
        var dataTable = new DataTable();
        dataTable.Load(reader);
        _logger.Log("INFO", "Executed query and loaded DataTable.");
        return dataTable;
    }

    // Giải phóng tài nguyên
    public void Dispose()
    {
        CloseConnection();
        _connection.Dispose();
        _logger.Log("INFO", "DatabaseHelper disposed.");
    }
}
