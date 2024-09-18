namespace WebApplication1.Model
{
    public class VendorModel
    {
        public string VendorCode { get; set; }
        public int CustomerID { get; set; }
        public string VendorName { get; set; }
        public string VendorType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string City  { get; set; }
        public string Shipvia { get; set; }
        public string PaymentTerms { get; set; }
        public string AccountNo { get; set; }
       
        public string VendorCost { get; set; }
        public DateTime TimeCreated { get; set; }

    }
}
