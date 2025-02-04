using AutoMapper;
using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;

namespace Sales_Date_Prediction_.Services
{
    public class OrdersServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private IMapper _Mapper;
        //se inyecta la dependencia por parametro
        public OrdersServices(IOrderRepository orderRepository, IMapper mapper) 
        {
            _orderRepository = orderRepository;
            _Mapper = mapper;
        }

        public NewOrderDTO CreateNewOrder(NewOrderDTO ordersDTO)
        {
            var result = _orderRepository.CreateNewOrder(ordersDTO);
            if(result.NewOrderID != null)
            {
                return result;
            }else
            {
                return null;
            }
        }

        public IEnumerable<OrdersDTO> GetOrdersByCustId(int custId)
        {
            var order = _orderRepository.GetOrdersByCustId(custId);
            if(order == null)
            {
                return Enumerable.Empty<OrdersDTO>();
            }
            else
            {
                var orderDto = _Mapper.Map<List<OrdersDTO>>(order);
                return orderDto;
            }
        }
    }
}
