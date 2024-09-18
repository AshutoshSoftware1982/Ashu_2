namespace WebApplication1.Model
{
    public class TransferModel
    {
        public int TransferID { get; set; }
        public int ProductID { get; set; }
        public int TransferQuantity { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime ReclreadDate { get; set; }
    }
}
