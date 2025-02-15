using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;

namespace Sales_Date_Prediction_.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesServices _employeesServices;
        public EmployeesController(IEmployeesServices employeesServices)
        {
            _employeesServices = employeesServices;
        }

        [HttpGet("GetAllEmployees")]
        [OutputCache]
        public ActionResult<IEnumerable<EmployeesDTO>> GetAllEmployees()
        {
            var employes = _employeesServices.GetAllEmployees();
            if(employes != null)
            {
                return Ok(employes);
            }
            else
            {
                return NotFound();            }
            }


    }
}
