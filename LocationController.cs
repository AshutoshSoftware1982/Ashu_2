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
    public class LocationController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public LocationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllLocation")]
        public string GetOrders()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from Location", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<LocationModel> location = new List<LocationModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LocationModel model = new LocationModel();
                    model.LocationID = Convert.ToInt32(dt.Rows[i]["LocationID"]);
                    model.LocationName = Convert.ToString(dt.Rows[i]["LocationName"]);
                    model.LocationAddress = Convert.ToString(dt.Rows[i]["LocationAddress"]);
                    location.Add(model);
                }
            }
            if (location.Count > 0)
                return JsonConvert.SerializeObject(location);

            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data Found";
                return JsonConvert.SerializeObject(response);
            }
        }
       
       
    }
}
