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
    public class Size_RangeController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public Size_RangeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetSize_Range")]
        public string GetSizeRange()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select Size_Range_Group,Size_Range_Group_Desc from tbl_Size_RangeGroup ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Size_RangeModel> transfers = new List<Size_RangeModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Size_RangeModel model = new Size_RangeModel();
                    model.Size_Range_Group = Convert.ToString(dt.Rows[i]["Size_Range_Group"]);
                    model.Size_Range_Group_Desc = Convert.ToString(dt.Rows[i]["Size_range_Group_Desc"]);
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
