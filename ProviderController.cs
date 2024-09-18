using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Model;
using Newtonsoft.Json;
using System.Net;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        // public readonly IEmployeeRepository employeeRepository;
        private static readonly List<ProviderModel> Products = new List<ProviderModel>();
        public ProviderController(IConfiguration configuration) 
        {
            _configuration = configuration;
          
        }
        [HttpGet]
        [Route("GetAllProvider")]
        public  string GetProvider()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString()); 
            SqlDataAdapter da = new SqlDataAdapter ("select * from Provider", con);
            DataTable dt = new DataTable ();
            da.Fill (dt);
            List<ProviderModel> providers = new List<ProviderModel> ();
            Response response = new Response(); 
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProviderModel model = new ProviderModel();
                    model.ProviderID = Convert.ToInt32(dt.Rows[i]["ProviderId"]);
                    model.ProviderName = Convert.ToString(dt.Rows[i]["ProviderName"]);
                    model.ProviderAddress = Convert.ToString(dt.Rows[i]["ProviderAddress"]);
                    model.Gender = Convert.ToString(dt.Rows[i]["Gender"]);
                    model.EmailID = Convert.ToString(dt.Rows[i]["EmailID"]);
                    model.Phone_Number = Convert.ToString(dt.Rows[i]["Phone_Number"]);
                    model.Country = Convert.ToString(dt.Rows[i]["Country"]);
                    model.State = Convert.ToString(dt.Rows[i]["State"]);
                    model.City = Convert.ToString(dt.Rows[i]["City"]);
                    providers.Add(model);
                }
            }
            if (providers.Count > 0)
                return JsonConvert.SerializeObject(providers);
                
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data Found";
                return JsonConvert.SerializeObject(response);
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteProvider(int id)
        {
            
            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("PostAllProvider")]
        public ProviderModel Post_Provider(ProviderModel providerModel)
        {
            providerModel.ProviderName = providerModel.ProviderName;
            providerModel.ProviderAddress = providerModel.ProviderAddress;
            providerModel.Gender = providerModel.Gender;
            providerModel.EmailID = providerModel.EmailID;
            providerModel.Phone_Number = providerModel.Phone_Number;
            providerModel.Country = providerModel.State;
            providerModel.City = providerModel.City;

            return providerModel;
        }
    }
    
}
