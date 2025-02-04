using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;

namespace Sales_Date_Prediction_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerServices _customerServices;

        public CustomersController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDatePredictionDTO>> GetCustomerDatePredictions()
        {
            IEnumerable<CustomerDatePredictionDTO> customerDatePredictions = _customerServices.GetCustomerDatePrediction();
            if(customerDatePredictions == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customerDatePredictions);
            }
        }

    }
}
