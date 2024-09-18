using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VInventory_OrderDetailsController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public VInventory_OrderDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllInventory_OrderDetails")]
        public string GetInventory_OrderDetails()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from VInventory_OrderDetails", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<VInventory_OrderDetailsModel> vInventory_Orders = new List<VInventory_OrderDetailsModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    VInventory_OrderDetailsModel model = new VInventory_OrderDetailsModel();
                    model.InventoryID = Convert.ToInt32(dt.Rows[i]["InventoryID"]);
                    model.ProductID = Convert.ToInt32(dt.Rows[i]["ProductID"]);
                    model.WarehouseID = Convert.ToInt32(dt.Rows[i]["WarehouseID"]);
                    model.QuantityAvailable = Convert.ToInt32(dt.Rows[i]["QuantityAvailable"]);
                    model.MinimumSttockLevel = Convert.ToInt32(dt.Rows[i]["MinimumSttockLevel"]);
                    model.MaximumStockLevel = Convert.ToInt32(dt.Rows[i]["MaximumStockLevel"]);
                    model.ReOrderPoint  = Convert.ToInt32(dt.Rows[i]["ReOrderPoint"]);
                    model.OrderDetailsID  = Convert.ToInt32(dt.Rows[i]["OrderDetailsID"]);
                    model.OrderID  = Convert.ToInt32(dt.Rows[i]["OrderID"]);
                    model.OrderQuantity= Convert.ToInt32(dt.Rows[i]["OrderQuantity"]);
                    model.ExprectedDate  = Convert.ToDateTime(dt.Rows[i]["ExprectedDate"]);
                    model.ActualDate  = Convert.ToDateTime(dt.Rows[i]["ActualDate"]);
                    vInventory_Orders.Add(model);
                }
            }
            if (vInventory_Orders.Count > 0)
                return JsonConvert.SerializeObject(vInventory_Orders);

            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data Found";
                return JsonConvert.SerializeObject(response);
            }
        }
    }
}
