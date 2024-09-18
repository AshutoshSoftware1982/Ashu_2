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
    public class Dim_RangeController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public Dim_RangeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetDimRange")]
        public string GetRange()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select DimRange,DimRangeDesc,DivisionCode from tbl_DimRange ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Dim_RangeModel> transfers = new List<Dim_RangeModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Dim_RangeModel model = new Dim_RangeModel();
                    model.DimRange = Convert.ToString(dt.Rows[i]["DimRange"]);
                    model.DimRangeDesc = Convert.ToString(dt.Rows[i]["DimRangeDesc"]);
                    model.DivisionCode = Convert.ToString(dt.Rows[i]["DivisionCode"]);
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
