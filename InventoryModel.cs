namespace WebApplication1.Model
{
    public class InventoryModel
    {
        public int InventoryID { get; set; }
        public int ProdcutID { get; set; }
        public int WarehouseID { get; set; }
        public int QuantityAvailable { get; set; }
        public int MinimumSttockLevel { get; set; }
        public int MaximumStockLevel { get; set; }
        public int ReOrderPoint { get; set; }
    }
}
