using System.Drawing;
namespace WebApplication1.Model
{
    
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string BarCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public int ProductQuantity { get; set; }
        public float PackedHeight { get; set; }
        public float PackedWidth { get; set; }
        public float PackedWeight { get; set; }
        public float PackedDepth { get; set; }
        public string Refrigrated { get; set; }
        public int CategoryId { get; set; }
        public object Product_Image { get; set; }
        //public Byte[] Product_Image1 { get; set; }
    }
}
