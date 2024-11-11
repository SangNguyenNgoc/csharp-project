namespace BookingTour.App.Helper;

public class AppUtil
{
    public static int GetCurrentDateIntWithNumber(int number)
    {
        string currentDate = DateTime.Now.ToString("yyyyMMdd");
        return int.Parse(currentDate) + number;
    }
}