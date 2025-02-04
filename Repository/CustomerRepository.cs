using Microsoft.Data.SqlClient;
using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;
using Sales_Date_Prediction_.Services;

namespace Sales_Date_Prediction_.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;
        public CustomerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("StoreSampleConnection");
        }
        public IEnumerable<CustomerDatePredictionDTO> GetAll()
        {
            var predictedOrders = new List<CustomerDatePredictionDTO>();
            //Query que consume la función que consulta fecha de posible orden
            string query = "SELECT * FROM Sales.GetNextOrderDate();";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader =  cmd.ExecuteReader())
                    {
                        while ( reader.Read())
                        {
                            var predictedOrder = new CustomerDatePredictionDTO
                            {
                                CustomerName = reader["CustomerName"].ToString(),
                                LastOrderDate = Convert.ToDateTime(reader["LastOrderDate"] != DBNull.Value ? Convert.ToDateTime(reader["LastOrderDate"]) : (DateTime?)null),
                                NextPredictedOrder = Convert.ToDateTime(reader["NextPredictedOrder"] != DBNull.Value ? Convert.ToDateTime(reader["NextPredictedOrder"]) : (DateTime?)null)
                            };

                            predictedOrders.Add(predictedOrder);
                        }
                    }
                }
            }
            return predictedOrders;

        }
    }
}
