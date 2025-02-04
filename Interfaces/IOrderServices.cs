using Sales_Date_Prediction_.DTO_s;

namespace Sales_Date_Prediction_.Interfaces
{
    public interface IOrderServices
    {
        IEnumerable<OrdersDTO> GetOrdersByCustId(int custId);
        NewOrderDTO CreateNewOrder(NewOrderDTO ordersDTO);
    }
}
