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
    public class StyleContentController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public StyleContentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("Get_Content")]
        public string Get_StyleContent()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_StyleContent", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<StyleContentModel> transfers = new List<StyleContentModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StyleContentModel model = new StyleContentModel();
                    model.ClientID = Convert.ToString(dt.Rows[i]["ClientID"]);
                    model.ContentCode = Convert.ToString(dt.Rows[i]["ContentCode"]);
                    model.ContentDesc = Convert.ToString(dt.Rows[i]["ContentDesc"]);
                    model.LastMod = Convert.ToDateTime(dt.Rows[i]["LastMod"]);
                    model.TimeCreated = Convert.ToDateTime(dt.Rows[i]["TimeCreated"]);
                    model.ModUser = Convert.ToString(dt.Rows[i]["ModUser"]);
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
