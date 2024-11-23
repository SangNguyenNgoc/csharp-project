namespace BookingTour.App.Exception;

public class AccountBlockedException : System.Exception
{
    public AccountBlockedException(string message) : base(message)
    {
    }
}
