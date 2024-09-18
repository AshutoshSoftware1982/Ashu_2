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
    public class WarehouseController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public WarehouseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllWarehouse")]
        public string GetWarehouse()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from Warehouse", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<WarehouseModel> ware = new List<WarehouseModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    WarehouseModel model = new WarehouseModel();
                    model.WarehouseID = Convert.ToInt32(dt.Rows[i]["WarehouseID"]);
                    model.WarehouseName = Convert.ToString(dt.Rows[i]["WarehouseName"]);
                    model.Address1 = Convert.ToString(dt.Rows[i]["Address1"]);
                    model.Address2 = Convert.ToString(dt.Rows[i]["Address1"]);
                    model.Country = Convert.ToString(dt.Rows[i]["Country"]);
                    model.State = Convert.ToString(dt.Rows[i]["State"]);
                    model.Zip = Convert.ToString(dt.Rows[i]["Zip"]);
                    model.Contact = Convert.ToString(dt.Rows[i]["Contact"]);
                    model.Contact_Email = Convert.ToString(dt.Rows[i]["Contact_Email"]);
                    model.Pick_Type = Convert.ToString(dt.Rows[i]["Pick_Type"]);
                    model.Divison = Convert.ToString(dt.Rows[i]["Divison"]);
                    model.Not_Alloc_Inv = Convert.ToString(dt.Rows[i]["Not_Alloc_Inv"]);
                    model.Close_Mainfest = Convert.ToString(dt.Rows[i]["Close_Mainfest"]);
                    model.Whs_Group = Convert.ToString(dt.Rows[i]["Whs_Group"]);
                    ware.Add(model);
                }
            }
            if (ware.Count > 0)
                return JsonConvert.SerializeObject(ware);

            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data Found";
                return JsonConvert.SerializeObject(response);
            }
        }
    }
}
