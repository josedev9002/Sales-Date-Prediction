using System.Globalization;

namespace Sales_Date_Prediction_.DTO_s
{
    public class CustomerDatePredictionDTO
    {
        public string CustomerName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder {  get; set; }
    }
}
