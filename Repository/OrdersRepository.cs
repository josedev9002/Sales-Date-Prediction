using Microsoft.EntityFrameworkCore;
using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;
using Sales_Date_Prediction_.Models;
using System.Net;

namespace Sales_Date_Prediction_.Repository
{
    public class OrdersRepository : IOrderRepository
    {
        private readonly StoreSampleContext _sampleContext;
        public OrdersRepository(StoreSampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }

        public NewOrderDTO CreateNewOrder(NewOrderDTO ordersDTO)
        {
            using (var transaction = _sampleContext.Database.BeginTransaction()) // Para asegurar la atomicidad
            {
                try
                {
                    var newOrder = new Order
                    {
                        Custid = ordersDTO.Custid,
                        Empid = ordersDTO.EmpId,
                        Orderdate = DateTime.Now, 
                        Requireddate = ordersDTO.RequiredDate,
                        Shippeddate = ordersDTO.ShippedDate,
                        Shipname = ordersDTO.ShipName,
                        Shipaddress = ordersDTO.ShipAddress,
                        Shipcity = ordersDTO.ShipCity,
                        Freight = ordersDTO.Freight,
                        Shipcountry = ordersDTO.ShipCountry,
                        Shipperid = ordersDTO.ShipperId
                    };

                    _sampleContext.Orders.Add(newOrder);
                    _sampleContext.SaveChanges(); // se almacena la orden para obtener el OrderID

                    ordersDTO.NewOrderID = newOrder.Orderid; 


                    var orderDetail = new OrderDetail
                    {
                        Orderid = ordersDTO.NewOrderID,
                        Productid = ordersDTO.Productid,
                        Unitprice = ordersDTO.UnitPrice,
                        Qty = ordersDTO.Qty,
                        Discount = ordersDTO.Discount
                    };

                    _sampleContext.OrderDetails.Add(orderDetail);
                    _sampleContext.SaveChanges();

                    transaction.Commit(); // Confirma la transacción
                    return ordersDTO; // Devuelve el nuevo OrderID
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); 
                    throw; 
                }
            }
        }

        public IEnumerable<Order> GetOrdersByCustId(int custId)
        {
            var orders = _sampleContext.Orders.Where(o => o.Custid == custId).ToList();
            if(orders != null)
            {
                 return orders;
            }
            else
            {
                 return null;
            }
        }
    }
}
