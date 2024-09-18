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
    public class Package_CategoryController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public Package_CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllPackage")]
        public string GetPackage()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from Package_Category", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Package_CategoryModel> transfers = new List<Package_CategoryModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Package_CategoryModel model = new Package_CategoryModel();
                    model.Package_id = Convert.ToInt32(dt.Rows[i]["Package_ID"]);
                    model.Clientid = Convert.ToInt32(dt.Rows[i]["ClientID"]);
                    model.Packet_Code = Convert.ToString(dt.Rows[i]["Packet_Code"]);
                    model.Packcat_Desc = Convert.ToString(dt.Rows[i]["Packcat_Desc"]);
                    model.Time_Created = Convert.ToDateTime(dt.Rows[i]["Time_Created"]);
                    model.Last_Mod = Convert.ToDateTime(dt.Rows[i]["Last_Mod"]);
                    model.Mod_User = Convert.ToString(dt.Rows[i]["Mod_User"]);

                    transfers.Add(model);
                }
            }
            if (transfers.Count > 0)
                return JsonConvert.SerializeObject(transfers);

            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data Found";
                return JsonConvert.SerializeObject(response);
            }
        }
    }
}
