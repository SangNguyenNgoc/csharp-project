namespace BookingTour.App.Exception;

public class InvalidLoginException : System.Exception
{
    public InvalidLoginException(string message) : base(message)
    {
    }
}
