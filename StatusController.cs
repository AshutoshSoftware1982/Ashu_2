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
    public class StatusController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public StatusController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetStatus")]
        public string GetStatus_Data()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select Status,StyleStatusDesc,Replenish from tbl_Status", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<StatusModel> transfers = new List<StatusModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StatusModel model = new StatusModel();
                    model.Status = Convert.ToString(dt.Rows[i]["Status"]);
                    model.StyleStatusDesc = Convert.ToString(dt.Rows[i]["StyleStatusDesc"]);
                    model.Replenish = Convert.ToString(dt.Rows[i]["Replenish"]);
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
