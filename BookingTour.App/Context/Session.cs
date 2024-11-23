namespace BookingTour.App.Context;

using System.Collections.Generic;

public static class Session
{
    // Dictionary lưu trữ dữ liệu session
    private static readonly Dictionary<string, object> Data = new();

    /// <summary>
    /// Lưu giá trị vào session với key
    /// </summary>
    /// <param name="key">Tên key</param>
    /// <param name="value">Giá trị</param>
    public static void Set(string key, object value)
    {
        lock (Data) // Đảm bảo thread-safe
        {
            if (!Data.TryAdd(key, value))
            {
                Data[key] = value; // Ghi đè nếu key đã tồn tại
            }
        }
    }

    /// <summary>
    /// Lấy giá trị từ session với key
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu mong muốn</typeparam>
    /// <param name="key">Tên key</param>
    /// <returns>Giá trị nếu tồn tại, ngược lại trả về default(T)</returns>
    public static T? Get<T>(string key)
    {
        lock (Data)
        {
            if (Data.TryGetValue(key, out var value))
            {
                return (T)value; // Ép kiểu và trả về giá trị
            }
            return default;
        }
    }

    /// <summary>
    /// Kiểm tra key có tồn tại trong session không
    /// </summary>
    /// <param name="key">Tên key</param>
    /// <returns>True nếu tồn tại, False nếu không</returns>
    public static bool Exists(string key)
    {
        lock (Data)
        {
            return Data.ContainsKey(key);
        }
    }

    /// <summary>
    /// Xóa giá trị khỏi session với key
    /// </summary>
    /// <param name="key">Tên key</param>
    public static void Remove(string key)
    {
        lock (Data)
        {
            Data.Remove(key);
        }
    }

    /// <summary>
    /// Xóa toàn bộ dữ liệu trong session
    /// </summary>
    public static void Clear()
    {
        lock (Data)
        {
            Data.Clear();
        }
    }
}
