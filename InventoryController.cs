using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public InventoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllInventory")]
        public string GetInventory()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from Inventory", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<InventoryModel> inventory = new List<InventoryModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    InventoryModel model = new InventoryModel();
                    model.InventoryID = Convert.ToInt32(dt.Rows[i]["InventoryID"]);
                    model.ProdcutID = Convert.ToInt32(dt.Rows[i]["ProductID"]);
                    model.WarehouseID = Convert.ToInt32(dt.Rows[i]["WarehouseID"]);
                    model.QuantityAvailable = Convert.ToInt32(dt.Rows[i]["QuantityAvailable"]);
                    model.MinimumSttockLevel = Convert.ToInt32(dt.Rows[i]["MinimumSttockLevel"]);
                    model.MaximumStockLevel = Convert.ToInt32(dt.Rows[i]["MaximumStockLevel"]);
                    model.ReOrderPoint = Convert.ToInt32(dt.Rows[i]["ReOrderPoint"]);
                    inventory.Add(model);
                }
            }
            if (inventory.Count > 0)
                return JsonConvert.SerializeObject(inventory);

            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data Found";
                return JsonConvert.SerializeObject(response);
            }
        }

    }
}
