using AutoMapper;
using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;
using Sales_Date_Prediction_.Models;

namespace Sales_Date_Prediction_.Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly IRepository<Product> _productsRepository;
        private IMapper _mapper;
        public ProductsServices(IRepository<Product> repository, IMapper mapper) 
        { 
            _productsRepository = repository;
            _mapper = mapper;
        }
        public IEnumerable<ProductsDTO> GetAllProducts()
        {
            var products = _productsRepository.GetAll();
            if(products != null)
            {
                return _mapper.Map<List<ProductsDTO>>(products);
            }
            else
            {
                return null;
            }
        }
    }
}
