namespace WebApplication1.Model
{
    public class Season_ReferenceModel
    {
        public string ClientCode { get; set; }
        public string Division { get; set; }
        public string Season { get; set; }
        public string SeasonDesc { get; set;}

        public DateTime Booking_StartDate { get; set; }
        public DateTime Booking_CancelDate { get; set; }
        public string Active { get; set; }
        public DateTime Shipping_StartDate { get; set; }
        public DateTime Shipping_CancelDate { get;set; }
        public string Time_Created { get; set; }
        public string Last_Mod { get; set; }
        public string Mod_User { get; set; }

    }
}
