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
    public class OrdersController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public OrdersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllOrders")]
        public string GetOrders()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from orders", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<OrdersModel> orderss = new List<OrdersModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    OrdersModel model = new OrdersModel();
                    model.OrderID = Convert.ToInt32(dt.Rows[i]["OrderID"]);
                    model.ProviderID = Convert.ToInt32(dt.Rows[i]["ProviderID"]);
                    model.OrderDate = Convert.ToString(dt.Rows[i]["OrderDate"]);
                    orderss.Add(model);
                }
            }
            if (orderss.Count > 0)
                return JsonConvert.SerializeObject(orderss);

            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data Found";
                return JsonConvert.SerializeObject(response);
            }
        }
        
    }
}
