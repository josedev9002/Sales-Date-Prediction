using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;
using Sales_Date_Prediction_.Models;

namespace Sales_Date_Prediction_.Repository
{
    public class ShippersRepository : IRepository<Shipper>
    {
        private readonly StoreSampleContext _sampleContext;
        public ShippersRepository(StoreSampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }
        public IEnumerable<Shipper> GetAll()
        {
            try
            {
                // Intenta obtener todos los shippers.
                var shippers = _sampleContext.Shippers.ToList();
                return shippers;
            }
            catch(Exception ex)
            {
                return Enumerable.Empty<Shipper>();
            }
        }
    }
}
