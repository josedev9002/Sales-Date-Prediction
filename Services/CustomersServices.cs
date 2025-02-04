using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;

namespace Sales_Date_Prediction_.Services
{
    public class CustomersServices : ICustomerServices
    {

        private readonly ICustomerRepository _customerRepository;
        public CustomersServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<CustomerDatePredictionDTO> GetCustomerDatePrediction()
        {
            var getAllCusDatePrediction = _customerRepository.GetAll();
            if(getAllCusDatePrediction == null)
            {
                return Enumerable.Empty<CustomerDatePredictionDTO>();
            }
            else
            {
                return getAllCusDatePrediction;
            }
        }
    }
}
