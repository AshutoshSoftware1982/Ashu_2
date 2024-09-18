using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using WebApplication1.Model;
using System.Drawing;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllProduct")]
        public string GetProduct()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from Product", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<ProductModel> product = new List<ProductModel>();
            Response response = new Response();
            /*if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProductModel model = new ProductModel();
                    model.ProductID = Convert.ToInt32(dt.Rows[i]["ProductID"]);
                    model.ProductCode = Convert.ToString(dt.Rows[i]["ProductCode"]);
                    model.BarCode = Convert.ToString(dt.Rows[i]["BarCode"]);
                    model.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                    model.ProductDescription = Convert.ToString(dt.Rows[i]["ProductDescription"]);
                    model.ProductCategory = Convert.ToString(dt.Rows[i]["ProductCategory"]);
                    model.ProductQuantity = Convert.ToInt32(dt.Rows[i]["ProductQuantity"]);
                    model.PackedHeight = Convert.ToInt32(dt.Rows[i]["PackedHeight"]);
                    model.PackedWidth = Convert.ToInt32(dt.Rows[i]["PackedWidth"]);
                    model.PackedWeight = Convert.ToInt32(dt.Rows[i]["PackedWeight"]);
                    model.PackedDepth = Convert.ToInt32(dt.Rows[i]["PackedDepth"]);
                    model.Refrigrated = Convert.ToString(dt.Rows[i]["Refrigrated"]);
                    model.CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]);
                    Byte[] byteBLOBData = new Byte[0];
                    //byteBLOBData = (Byte[])(dt.Rows[i]["Product_Image"]);
                    
                    MemoryStream stmBLOBData = new MemoryStream((Byte[])dt.Rows[i]["Product_Image"]);
#pragma warning disable CA1416 // Validate platform compatibility
                    Image sd = Image.FromStream(stmBLOBData);
#pragma warning restore CA1416 // Validate platform compatibility
                    MemoryStream ms = new MemoryStream();

                    sd.Save(ms, sd.RawFormat);
                    model.Product_Image = dt.Rows[i]["Product_Image"];
                    
                    //Byte[] dd = Convert.FromBase64String(dt.Rows[i]["Product_Image1"].ToString());
                    //model.Product_Image1 = dd;
                    product.Add(model);
                }
            }*/
            //if (product.Count > 0)
                return JsonConvert.SerializeObject(dt);

            /*else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data Found";
                return JsonConvert.SerializeObject(response);
            }*/
        }
    }
}
