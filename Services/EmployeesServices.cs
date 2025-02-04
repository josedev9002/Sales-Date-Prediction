using AutoMapper;
using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;
using Sales_Date_Prediction_.Models;

namespace Sales_Date_Prediction_.Services
{
    public class EmployeesServices : IEmployeesServices
    {
        private readonly IRepository<EmployeesDTO> _repository;
        private IMapper _mapper;
        public EmployeesServices(IRepository<EmployeesDTO> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<EmployeesDTO> GetAllEmployees()
        {
            return _repository.GetAll();
        }
    }
}
