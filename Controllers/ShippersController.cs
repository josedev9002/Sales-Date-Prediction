using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Sales_Date_Prediction_.Interfaces;
using Sales_Date_Prediction_.Models;

namespace Sales_Date_Prediction_.Controllers
{
    [Route("api/shippers")]
    [ApiController]
    public class ShippersController : Controller
    {
        private readonly IShippersServices _shippersServices;
        public ShippersController(IShippersServices shippersServices)
        {
            _shippersServices = shippersServices;
        }

        [HttpGet("GetAllShippers")]
        [OutputCache]
        public ActionResult<IEnumerable<Shipper>> GetAllShippers()
        {
            var shippers = _shippersServices.GetAllShippers();
            if(shippers != null)
            {
                return Ok(shippers);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
