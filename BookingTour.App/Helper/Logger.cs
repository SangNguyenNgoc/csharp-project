namespace BookingTour.App.Helper;

public class Logger
{
    // ReSharper disable once InconsistentNaming
    private static readonly Lazy<Logger> _instance = new(() => new Logger());

    public Logger()
    {
        
    }

    public static Logger Instance => _instance.Value;
    
    // Logger đơn giản, ghi log ra console
    public void Log(string level, string message)
    {
        Console.WriteLine($@"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}");
    }
}