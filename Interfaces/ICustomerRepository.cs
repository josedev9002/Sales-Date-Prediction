using Sales_Date_Prediction_.DTO_s;

namespace Sales_Date_Prediction_.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDatePredictionDTO> GetAll();
    }
}
