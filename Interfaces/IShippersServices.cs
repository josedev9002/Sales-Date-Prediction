using Sales_Date_Prediction_.DTO_s;

namespace Sales_Date_Prediction_.Interfaces
{
    public interface IShippersServices
    {
        IEnumerable<ShippersDTO> GetAllShippers();
    }
}
