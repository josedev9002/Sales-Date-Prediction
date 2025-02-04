namespace Sales_Date_Prediction_.DTO_s
{
    public class NewOrderDTO
    {
        public int EmpId { get; set; }  
        public int Custid { get; set; }
        public int ShipperId { get; set; }  
        public string ShipName { get; set; } = null!;  
        public string ShipAddress { get; set; } = null!;  
        public string ShipCity { get; set; } = null!;  
        public DateTime OrderDate { get; set; }  
        public DateTime RequiredDate { get; set; }  
        public DateTime? ShippedDate { get; set; }  
        public decimal Freight { get; set; }  
        public string ShipCountry { get; set; } = null!;
        public int Productid { get; set; }
        public decimal UnitPrice { get; set; }
        public short Qty { get; set; }   
        public decimal Discount { get; set; } 
        public int NewOrderID { get; set; }


    }
}
