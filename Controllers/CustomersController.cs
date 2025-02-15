using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;
using Sales_Date_Prediction_.Utilidades;

namespace Sales_Date_Prediction_.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomersController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet("GetCustomerDatePrediction")]
        [OutputCache]
        public async Task<ActionResult<IEnumerable<CustomerDatePredictionDTO>>> GetCustomerDatePredictions([FromQuery] PaginacionDTO paginacionDTO)
        {
            IEnumerable<CustomerDatePredictionDTO> customerDatePredictions = _customerServices.GetCustomerDatePrediction();
            var resul = customerDatePredictions.Paginar(paginacionDTO).OrderByDescending(opc => opc.NextPredictedOrder);
            await HttpContext.InsertarParametrosPaginacionCabecera(customerDatePredictions);
            if (customerDatePredictions == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resul);
            }
        }

    }
}
