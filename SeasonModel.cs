namespace WebApplication1.Model
{
    public class SeasonModel
    {
        public string ClientID { get; set; }
        public string Division { get; set; }
        public string Season { get; set; }
        public string SeasonDesc { get; set; }
        public string Active { get; set; }
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingCancelDate { get; set; }
        public DateTime ShippingStartDate { get; set; }
        public DateTime ShippingCancelDate { get; set; }
        public DateTime CostEffectiveDateStart { get; set; }
        public DateTime CostEffectiveDateEnd { get; set; }
        public string CostSheetCode { get; set; }
        public DateTime InvoiceDueDate { get; set; }
        public string AllowedSalesFlag { get; set; }
        public string Sort { get; set; }
        public string ModUser { get; set; }
    }
    public class SeasonsModel
    {
        public string ClientID { get; set; }
        public string Division { get; set; }
        public string Season { get; set; }
        public string SeasonDesc { get; set; }
        public string Active { get; set; }
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingCancelDate { get; set; }
        public DateTime ShippingStartDate { get; set; }
        public DateTime ShippingCancelDate { get; set; }
        public DateTime CostEffectiveDateStart { get; set; }
        public DateTime CostEffectiveDateEnd { get; set; }
        public string CostSheetCode { get; set; }
        public DateTime InvoiceDueDate { get; set; }
        public string AllowedSalesFlag { get; set; }
        public string Sort { get; set; }
        public string ModUser { get; set; }
        public DateTime LastMod{ get; set; }
        public DateTime TimeCreated{ get; set; }

    }
}
