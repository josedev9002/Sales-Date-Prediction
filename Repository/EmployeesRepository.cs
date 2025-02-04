using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;
using Sales_Date_Prediction_.Models;

namespace Sales_Date_Prediction_.Repository
{
    public class EmployeesRepository : IRepository<EmployeesDTO>
    {
        private string queryGetAllEmployees;
        private readonly string _connectionString;
        public EmployeesRepository(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("StoreSampleConnection");
        }
        public IEnumerable<EmployeesDTO> GetAll()
        {
            var getAllEmployees = new List<EmployeesDTO>();
            queryGetAllEmployees = "select * from vwEmpleados";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(queryGetAllEmployees, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmployeesDTO employee = new EmployeesDTO
                            {
                                Empid = reader["Empid"].ToString(),
                                FullName = reader["FullName"].ToString()

                            };
                            getAllEmployees.Add(employee);
                        }
                        
                    }
                }
            }
            return getAllEmployees;
            
        }
    }
}
