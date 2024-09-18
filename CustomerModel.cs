namespace WebApplication1.Model
{
    public class CustomerModel
    {
        public int CustomerId  { get; set; }
        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }
       
        public string EmailID { get; set; }

        public string Mobile_Number   { get; set; }

        public string Gender { get; set; }
        public string CustomerAddress2 { get; set; }
        public string CustomerAddress3 { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ClientCode { get; set; }
    }

    public class ClientModel
    {
        public string ClientCode { get; set; }
        public string CustomerName { get; set; }

    }
}
