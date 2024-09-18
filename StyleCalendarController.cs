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
    public class StyleCalendarController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public StyleCalendarController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetCalendar")]
        public string GetStyle_Calendar()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select Calendar,TaskCode,Seq,Duration,EstimateComDate,EarliestProjectedDate,Comment,ActualComDate,CompleteBy,TaskDueDate,ResponsiblePerson from tbl_StyleCalendar", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<StyleCalendarModel> transfers = new List<StyleCalendarModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StyleCalendarModel model = new StyleCalendarModel();
                    model.Calendar = Convert.ToDateTime(dt.Rows[i]["Calendar"]);
                    model.TaskCode = Convert.ToString(dt.Rows[i]["TaskCode"]);
                    model.Seq = Convert.ToString(dt.Rows[i]["Seq"]);
                    model.Duration = Convert.ToString(dt.Rows[i]["Duration"]);
                    model.EstimateComDate = Convert.ToDateTime(dt.Rows[i]["EstimateComDate"]);
                    model.EarliestProjectedDate = Convert.ToDateTime(dt.Rows[i]["EarliestProjectedDate"]);
                    model.Comment = Convert.ToString(dt.Rows[i]["Comment"]);
                    model.ActualComDate = Convert.ToDateTime(dt.Rows[i]["ActualComDate"]);
                    model.CompleteBy = Convert.ToString(dt.Rows[i]["CompleteBy"]);
                    model.TaskDueDate = Convert.ToDateTime(dt.Rows[i]["TaskDueDate"]);
                    model.ResponsiblePerson = Convert.ToString(dt.Rows[i]["ResponsiblePerson"]);

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
