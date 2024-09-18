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
    public class PricingController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public PricingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllPricing")]
        public string GetPricing()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from Pricing", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<PricingModel> pricings = new List<PricingModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PricingModel model = new PricingModel();
                    model.PricingCode = Convert.ToString(dt.Rows[i]["PricingCode"]);
                    model.CustomerID = Convert.ToInt32(dt.Rows[i]["CustomerID"]);
                    model.Label = Convert.ToString(dt.Rows[i]["Label"]);
                    model.Color = Convert.ToString(dt.Rows[i]["Color"]);
                    model.Dim = Convert.ToString(dt.Rows[i]["Dim"]);
                    model.PPK = Convert.ToString(dt.Rows[i]["PPK"]);
                    model.EffectiveDate = Convert.ToDateTime(dt.Rows[i]["EffectiveDate"]);
                    model.SellingDivision = Convert.ToString(dt.Rows[i]["SellingDivision"]);
                    model.BaseCurrency = Convert.ToString(dt.Rows[i]["BaseCurrency"]);
                    model.PriceA = Convert.ToInt32(dt.Rows[i]["PriceA"]);
                    model.PriceB = Convert.ToInt32(dt.Rows[i]["PriceB"]);
                    model.PriceC = Convert.ToInt32(dt.Rows[i]["PriceC"]);
                    model.PriceD = Convert.ToInt32(dt.Rows[i]["PriceD"]);
                    model.PriceE = Convert.ToInt32(dt.Rows[i]["PriceE"]);
                    model.PriceF = Convert.ToInt32(dt.Rows[i]["PriceF"]);

                    pricings.Add(model);
                }
            }
            if (pricings.Count > 0)
                return JsonConvert.SerializeObject(pricings);

            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data Found";
                return JsonConvert.SerializeObject(response);
            }
        }
    }
}
