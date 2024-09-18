namespace WebApplication1.Model
{
    public class OrderDetailsModel
    {
        public int OrderDetailsID{ get; set; }
        public int OrderID {  get; set; }
        public int ProductID { get; set; }

        public int WarehouseID { get;set; }

        public int OrderQuantity { get; set; }

        public string ExprectedDate { get; set; }

        public string ActualDate { get;set; }
    }
}
