using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;

namespace Sales_Date_Prediction_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductsServices _productsServices;
        public ProductsController(IProductsServices productsServices)
        {
            _productsServices = productsServices;   
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductsDTO>> GetProducts()
        {
            var products = _productsServices.GetAllProducts();
            if(products != null)
            {
                return Ok(products);
            }else
            {
                return NotFound();
            }
        }
    }
}
