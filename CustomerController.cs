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
    public class CustomerController : ControllerBase
    {
       
        public readonly IConfiguration _configuration;
        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllCustomer")]
        public string GetCustomer()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from Customer", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<CustomerModel> transfers = new List<CustomerModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CustomerModel model = new CustomerModel();
                    model.CustomerId = Convert.ToInt32(dt.Rows[i]["CustomerId"]);
                    model.CustomerName = Convert.ToString(dt.Rows[i]["CustomerName"]);
                    model.CustomerAddress = Convert.ToString(dt.Rows[i]["CustomerAddress"]);
                    model.EmailID = Convert.ToString(dt.Rows[i]["EmailID"]);
                    model.Mobile_Number = Convert.ToString(dt.Rows[i]["Mobile_Number"]);
                    model.Gender = Convert.ToString(dt.Rows[i]["Gender"]);
                    model.CustomerAddress2 = Convert.ToString(dt.Rows[i]["CustomerAddress2"]);
                    model.CustomerAddress3 = Convert.ToString(dt.Rows[i]["CustomerAddress3"]);
                    model.Country = Convert.ToString(dt.Rows[i]["Country"]);
                    model.State = Convert.ToString(dt.Rows[i]["State"]);
                    model.City = Convert.ToString(dt.Rows[i]["City"]);
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
        [Route("GetClientID")]
        public string GetCustomer_ID(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from Customer where CustomerID="+id, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<CustomerModel> transfers = new List<CustomerModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CustomerModel model = new CustomerModel();
                    model.CustomerId = Convert.ToInt32(dt.Rows[i]["CustomerID"]);
                    model.CustomerName = Convert.ToString(dt.Rows[i]["CustomerName"]);
                    model.CustomerAddress = Convert.ToString(dt.Rows[i]["CustomerAddress"]);
                    model.EmailID = Convert.ToString(dt.Rows[i]["EmailID"]);
                    model.Mobile_Number = Convert.ToString(dt.Rows[i]["Mobile_Number"]);
                    model.Gender = Convert.ToString(dt.Rows[i]["Gender"]);
                    model.CustomerAddress2 = Convert.ToString(dt.Rows[i]["CustomerAddress2"]);
                    model.CustomerAddress3 = Convert.ToString(dt.Rows[i]["CustomerAddress3"]);
                    model.Country = Convert.ToString(dt.Rows[i]["Country"]);
                    model.State = Convert.ToString(dt.Rows[i]["State"]);
                    model.City = Convert.ToString(dt.Rows[i]["City"]);
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
        [Route("GetClientCode")]
        public string GetCustomer_Code()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select ClientCode,CustomerName from Customer", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<ClientModel> transfers = new List<ClientModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ClientModel model = new ClientModel();
                    model.ClientCode = Convert.ToString(dt.Rows[i]["ClientCode"]);
                    model.CustomerName = Convert.ToString(dt.Rows[i]["CustomerName"]);
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
