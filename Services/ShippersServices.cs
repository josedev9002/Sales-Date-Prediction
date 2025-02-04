using AutoMapper;
using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;
using Sales_Date_Prediction_.Models;

namespace Sales_Date_Prediction_.Services
{
    public class ShippersServices : IShippersServices
    {
        private readonly IRepository<Shipper> _shippersRepository;
        private IMapper _mapper;
        public ShippersServices(IRepository<Shipper> shippersRepository, IMapper mapper)
        {
            _shippersRepository = shippersRepository;
            _mapper = mapper;
        }
        public IEnumerable<ShippersDTO> GetAllShippers()
        {
            var shippers = _shippersRepository.GetAll();
            if(shippers == null)
            {
                return Enumerable.Empty<ShippersDTO>();
            }
            else
            {
                return _mapper.Map<List<ShippersDTO>>(shippers);    
            }
        }
    }
}
