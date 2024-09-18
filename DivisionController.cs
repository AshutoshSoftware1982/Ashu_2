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
    public class DivisionController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public DivisionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetDivisonCode")]
        public string GetDivision_Code()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select DivisionCode,DivisionName from Division", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<DivisionModel> transfers = new List<DivisionModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DivisionModel model = new DivisionModel();
                    model.DivisionCode = Convert.ToString(dt.Rows[i]["DivisionCode"]);
                    model.DivisionName = Convert.ToString(dt.Rows[i]["DivisionName"]);
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
