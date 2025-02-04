using AutoMapper;
using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Models;

namespace Sales_Date_Prediction_.AutoMappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            
            CreateMap<Order, OrdersDTO>().ForMember(o => o.Custid, oDTO => oDTO.MapFrom(o => o.Custid));
            CreateMap<Employee, EmployeesDTO>();
            CreateMap<Shipper, ShippersDTO>();
            CreateMap<Product, ProductsDTO>();
        }
    }
}
