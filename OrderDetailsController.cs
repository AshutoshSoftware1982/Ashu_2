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
    public class OrderDetailsController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public OrderDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllOrderDetails")]
        public string GetOrderDetails()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from OrderDetails", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<OrderDetailsModel> orderdetails = new List<OrderDetailsModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    OrderDetailsModel model = new OrderDetailsModel();
                    model.OrderDetailsID = Convert.ToInt32(dt.Rows[i]["OrderDetailsID"]);
                    model.OrderID = Convert.ToInt32(dt.Rows[i]["OrderID"]);
                    model.ProductID = Convert.ToInt32(dt.Rows[i]["ProductID"]);
                    model.WarehouseID = Convert.ToInt32(dt.Rows[i]["WarehouseID"]);
                    model.OrderQuantity = Convert.ToInt32(dt.Rows[i]["OrderQuantity"]);
                    model.ExprectedDate = Convert.ToString(dt.Rows[i]["ExprectedDate"]);
                    model.ActualDate = Convert.ToString(dt.Rows[i]["ActualDate"]);
                    orderdetails.Add(model);
                }
            }
            if (orderdetails.Count > 0)
                return JsonConvert.SerializeObject(orderdetails);

            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data Found";
                return JsonConvert.SerializeObject(response);
            }
        }
    }
}
