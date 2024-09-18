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
    public class DeliveryController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public DeliveryController(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        [HttpGet]
        [Route("AllGetDelivery")]
        public string GetDeliverys()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from Delivery", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<DeliveryModel> transfers = new List<DeliveryModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DeliveryModel model = new DeliveryModel();
                    model.DeliveryId = Convert.ToInt32(dt.Rows[i]["DeliveryId"]);
                    model.SalesDate = Convert.ToDateTime(dt.Rows[i]["SalesDate"]);
                    model.CustomerID = Convert.ToInt32(dt.Rows[i]["CustomerID"]);
                    model.OrderID = Convert.ToInt32(dt.Rows[i]["OrderID"]);


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
