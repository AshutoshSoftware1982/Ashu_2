namespace WebApplication1.Model
{
    public class VInventory_OrderDetailsModel
    {
        public int InventoryID { get; set; }
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }

        public int QuantityAvailable { get; set; }
        public int MinimumSttockLevel { get; set; }
        public int MaximumStockLevel { get; set; }
        public int ReOrderPoint { get; set; }
        public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }
        public int OrderQuantity { get; set; }
        public DateTime ExprectedDate { get; set; }
        public DateTime ActualDate { get; set; }


    }
}
