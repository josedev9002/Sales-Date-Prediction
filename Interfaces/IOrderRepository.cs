using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Models;

namespace Sales_Date_Prediction_.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrdersByCustId(int custId);
        NewOrderDTO CreateNewOrder(NewOrderDTO ordersDTO);
    }
}
