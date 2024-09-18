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
    public class VDeliver_CustomerDetailsController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public VDeliver_CustomerDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllDelivery")]
        public string GetDelivery()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from VDeliver_CustomerDetails", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<VDeliver_CustomerDetailsModel> delivery_Details = new List<VDeliver_CustomerDetailsModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    VDeliver_CustomerDetailsModel model = new VDeliver_CustomerDetailsModel();
                    model.DeliveryID = Convert.ToInt32(dt.Rows[i]["DeliveryID"]);
                    model.SalesDate = Convert.ToDateTime(dt.Rows[i]["SalesDate"]);
                    model.CustomerID = Convert.ToInt32(dt.Rows[i]["CustomerID"]);
                    model.CustomerName = Convert.ToString(dt.Rows[i]["CustomerName"]);
                    model.EmailID = Convert.ToString(dt.Rows[i]["EmailID"]);
                    model.Mobile_Number = Convert.ToString(dt.Rows[i]["Mobile_Number"]);
                    model.Gender = Convert.ToString(dt.Rows[i]["Gender"]);
                    model.DeliveryDetailsID = Convert.ToInt32(dt.Rows[i]["DeliveryDetailsID"]);
                    model.ProductID = Convert.ToInt32(dt.Rows[i]["ProductID"]);
                    model.WarehouseID = Convert.ToInt32(dt.Rows[i]["WarehouseID"]);
                    model.DeliveryQuantity = Convert.ToInt32(dt.Rows[i]["DeliveryQuantity"]);
                    model.ExpectedDate = Convert.ToDateTime(dt.Rows[i]["ExpectedDate"]);
                    model.ActualDate = Convert.ToDateTime(dt.Rows[i]["ActualDate"]);
                    //model.Status_Approved = Convert.ToString(dt.Rows[i]["Status_Approved"]);
                    
                    delivery_Details.Add(model);
                }
            }
            if (delivery_Details.Count > 0)
                return JsonConvert.SerializeObject(delivery_Details);

            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data Found";
                return JsonConvert.SerializeObject(response);
            }
        }

    }
}
