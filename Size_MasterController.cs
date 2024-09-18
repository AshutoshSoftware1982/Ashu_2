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
    public class Size_MasterController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public Size_MasterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetSize_MasterResult")]
        public string GetResult()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select Client_Code,Division,SizeRange,AllSizes,SizeRangeDesc,TimeCreated,LastMod,ModUser,Active from tbl_Size_MasterResult", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Size_MasterResultModel> transfers = new List<Size_MasterResultModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Size_MasterResultModel model = new Size_MasterResultModel();
                    model.Client_Code = Convert.ToString(dt.Rows[i]["Client_Code"]);
                    model.Division = Convert.ToString(dt.Rows[i]["Division"]);
                    model.SizeRange = Convert.ToString(dt.Rows[i]["SizeRange"]);
                    model.AllSizes = Convert.ToString(dt.Rows[i]["AllSizes"]);
                    model.SizeRangeDesc = Convert.ToString(dt.Rows[i]["SizeRangeDesc"]);
                    model.TimeCreated = Convert.ToString(dt.Rows[i]["TimeCreated"]);
                    model.LastMod = Convert.ToString(dt.Rows[i]["LastMod"]);
                    model.ModUser = Convert.ToString(dt.Rows[i]["ModUser"]);
                    model.Active = Convert.ToString(dt.Rows[i]["Active"]);
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
