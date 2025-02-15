using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;

namespace Sales_Date_Prediction_.Controllers
{
    [Route("api/oders")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderServices _ordersServices;
        private readonly IOutputCacheStore _outputCache;
        private const string tag = "orders";

        public OrdersController(IOrderServices orderServices, IOutputCacheStore outputCache)
        {
            this._ordersServices = orderServices;
            this._outputCache = outputCache;
        }

        //Endpoint que se encarga de consultar las ordenes mediante el Id de cliente
        [HttpGet("{custid}")]
        [HttpGet("GetOrderByCustId")]
        [OutputCache(Tags = [tag])]
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
        [HttpPost("CreateNeworder")]
        public async Task<ActionResult> CreateNewOrder([FromBody] NewOrderDTO orders)
        {
            var result = _ordersServices.CreateNewOrder(orders);
            if(result != null)
            {
                await _outputCache.EvictByTagAsync(tag, default);
                return CreatedAtRoute("GetOrderByCustId", new { CustId = result.Custid }, result);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
