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
    public class Calendar_DataController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public Calendar_DataController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetCalendar")]
        public string GetCalendar_Data()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select Calendar,CalendarDesc from Calendar_Data", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Calendar_DataModel> transfers = new List<Calendar_DataModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Calendar_DataModel model = new Calendar_DataModel();
                    model.Calendar = Convert.ToDateTime(dt.Rows[i]["Calendar"]);
                    model.CalendarDesc = Convert.ToString(dt.Rows[i]["CalendarDesc"]);

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
