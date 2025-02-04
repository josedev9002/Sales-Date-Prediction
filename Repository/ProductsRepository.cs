using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;
using Sales_Date_Prediction_.Models;

namespace Sales_Date_Prediction_.Repository
{
    public class ProductsRepository : IRepository<Product>
    {
        private readonly StoreSampleContext _storeSampleContext;
        public ProductsRepository(StoreSampleContext storeSampleContext) 
        {
            _storeSampleContext = storeSampleContext;
        }
        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();
             products = _storeSampleContext.Products.ToList();
            return products;
        }
    }
}
