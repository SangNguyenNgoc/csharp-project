using BookingTour.App.Helper;

namespace BookingTour.App.Bus;

public class ExampleBus
{
    private readonly UnitOfWork _unit = UnitOfWork.Instance;

    public string Example(string id)
    {
        _unit.ExecuteInTransaction(u =>
        {
            //Truy vấn trong cùng 1 transaction ở đây
        });
        _unit.Activity.GetAll(); //Truy vấn thông thường
        return "";
    }
}