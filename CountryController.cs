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
    public class CountryController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public CountryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllCountry")]
        public string GetCountry()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select Country_Name from Country", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<CountryModel> transfers = new List<CountryModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CountryModel model = new CountryModel();
                    model.Country_Name = Convert.ToString(dt.Rows[i]["Country_Name"]);
                    
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

        [HttpGet]
        [Route("GetCountry")]
        public string GetCountry_Details()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from Country", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<CountyAllModel> transfers = new List<CountyAllModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CountyAllModel model = new CountyAllModel();
                    model.CountryCode = Convert.ToString(dt.Rows[i]["CountryCode"]);
                    model.Country_Name = Convert.ToString(dt.Rows[i]["Country_Name"]);
                    model.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    model.Abbreviation = Convert.ToString(dt.Rows[i]["Abbreviation"]);
                    model.Time_Name = Convert.ToString(dt.Rows[i]["Time_Name"]);

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
        [HttpGet]
        [Route("GetCountryCode")]
        public string GetCountry_Code()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select CountryCode from Country", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<CountryCodeModel> transfers = new List<CountryCodeModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CountryCodeModel model = new CountryCodeModel();
                    model.CountryCode = Convert.ToString(dt.Rows[i]["CountryCode"]);

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
