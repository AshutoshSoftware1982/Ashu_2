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
    public class ContentController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public ContentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetContent")]
        public string Get_Content()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select ContentCode,ContentDesc from tbl_Content", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<ContentModel> transfers = new List<ContentModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ContentModel model = new ContentModel();
                    model.ContentCode = Convert.ToString(dt.Rows[i]["ContentCode"]);
                    model.ContentDesc = Convert.ToString(dt.Rows[i]["ContentDesc"]);
                    
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
