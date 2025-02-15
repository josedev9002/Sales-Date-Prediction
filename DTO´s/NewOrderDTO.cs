using System.ComponentModel.DataAnnotations;


namespace Sales_Date_Prediction_.DTO_s
{
    public class NewOrderDTO
    {
        [Required(ErrorMessage = "El campo del {0}} es obligatorio")]
        public required int EmpId { get; set; }
        [Required(ErrorMessage = "El campo del {0} es obligatorio")]
        public required int Custid { get; set; }
        [Required(ErrorMessage = "El campo del {0} es obligatorio")]
        public required int ShipperId { get; set; }
        [Required(ErrorMessage = "El campo del {0} es obligatorio")]
        [StringLength(10,ErrorMessage ="El campo {0} no debe superar los {1} caracteres")]
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
