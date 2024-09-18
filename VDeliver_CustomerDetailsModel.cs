namespace WebApplication1.Model
{
    public class VDeliver_CustomerDetailsModel
    {
        public int DeliveryID { get; set; }
        public DateTime SalesDate { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string EmailID { get; set; }
        public string Mobile_Number { get; set; }
        public string Gender { get; set; }
        public int DeliveryDetailsID { get; set; }
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }
        public int DeliveryQuantity { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime ActualDate { get; set; }
        //public string Status_Approved { get; set; }
    }
}
