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
    public class Season_ReferenceController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public Season_ReferenceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetSea_Reference")]
        public string GetRefer_Data()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select ClientCode,Division,Season,SeasonDesc,Booking_StartDate,Booking_CancelDate,Active,Shipping_StartDate,Shipping_CancelDate,Time_Created,Last_Mod,Mod_User from tbl_Season_Reference", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Season_ReferenceModel> transfers = new List<Season_ReferenceModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Season_ReferenceModel model = new Season_ReferenceModel();
                    model.ClientCode = Convert.ToString(dt.Rows[i]["ClientCode"]);
                    model.Division = Convert.ToString(dt.Rows[i]["Division"]);
                    model.Season = Convert.ToString(dt.Rows[i]["Season"]);
                    model.SeasonDesc = Convert.ToString(dt.Rows[i]["SeasonDesc"]);
                    model.Booking_StartDate = Convert.ToDateTime(dt.Rows[i]["Booking_StartDate"]);
                    model.Booking_CancelDate = Convert.ToDateTime(dt.Rows[i]["Booking_CancelDate"]);
                    model.Active = Convert.ToString(dt.Rows[i]["Active"]);
                    model.Shipping_StartDate = Convert.ToDateTime(dt.Rows[i]["Shipping_StartDate"]);
                    model.Shipping_CancelDate = Convert.ToDateTime(dt.Rows[i]["Shipping_CancelDate"]);
                    model.Time_Created = Convert.ToString(dt.Rows[i]["Time_Created"]);
                    model.Last_Mod = Convert.ToString(dt.Rows[i]["Last_Mod"]);
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
