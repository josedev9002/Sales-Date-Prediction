namespace Sales_Date_Prediction_.DTO_s
{
    public class OrdersDTO
    {
        public int Orderid { get; set; }

        public int? Custid { get; set; }

        public int Empid { get; set; }

        public DateTime Orderdate { get; set; }

        public DateTime Requireddate { get; set; }

        public DateTime? Shippeddate { get; set; }

        public int Shipperid { get; set; }

        public decimal Freight { get; set; }

        public string Shipname { get; set; } = null!;

        public string Shipaddress { get; set; } = null!;

        public string Shipcity { get; set; } = null!;

        public string? Shipregion { get; set; }

        public string? Shippostalcode { get; set; }

        public string Shipcountry { get; set; } = null!;
    }
}
