using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;

namespace Sales_Date_Prediction_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderServices _ordersServices;
        public OrdersController(IOrderServices orderServices)
        {
            _ordersServices = orderServices;
        }

        //Endpoint que se encarga de consultar las ordenes mediante el Id de cliente
        [HttpGet("{custid}")]
        public ActionResult<IEnumerable<OrdersDTO>> GetOrderByCustId(int custid)
        {
            var orders = _ordersServices.GetOrdersByCustId(custid);
            if(orders == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(orders);
            }
        }

        //Endpoint que se encarga de crear una nueva orden
        [HttpPost]
        public ActionResult CreateNewOrder(NewOrderDTO orders)
        {
            var result = _ordersServices.CreateNewOrder(orders);
            if(result != null)
            {
                return CreatedAtRoute("GetOrderByCustId", new { CustId = result.Custid }, result);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
