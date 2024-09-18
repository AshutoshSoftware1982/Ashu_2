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
    public class VendorController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public VendorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllVendors")]
        public string GetVendor()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from View_Vendor", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<VendorModel> pricings = new List<VendorModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    VendorModel model = new VendorModel();
                    model.VendorCode = Convert.ToString(dt.Rows[i]["VendorCode"]);
                    model.CustomerID = Convert.ToInt32(dt.Rows[i]["CustomerID"]);
                    model.VendorName = Convert.ToString(dt.Rows[i]["VendorName"]);
                    model.VendorType = Convert.ToString(dt.Rows[i]["VendorType"]);
                    model.Address1 = Convert.ToString(dt.Rows[i]["Address1"]);
                    model.Address2 = Convert.ToString(dt.Rows[i]["Address2"]);
                    model.Address3 = Convert.ToString(dt.Rows[i]["Address3"]);
                    model.Address4 = Convert.ToString(dt.Rows[i]["Address4"]);
                    model.Country = Convert.ToString(dt.Rows[i]["Country"]);
                    model.State = Convert.ToString(dt.Rows[i]["State"]);
                    model.Zip = Convert.ToString(dt.Rows[i]["Zip"]);
                    model.City = Convert.ToString(dt.Rows[i]["City"]);
                    model.Shipvia = Convert.ToString(dt.Rows[i]["Shipvia"]);
                    model.PaymentTerms = Convert.ToString(dt.Rows[i]["PaymentTerms"]);
                    model.AccountNo = Convert.ToString(dt.Rows[i]["AccountNo"]);
                    model.VendorCost = Convert.ToString(dt.Rows[i]["VendorCost"]);
                    model.TimeCreated = Convert.ToDateTime(dt.Rows[i]["TimeCreated"]);
                    

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
        [HttpGet]
        [Route("GetCustomerID")]
        public string GetCustomer()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select CustomerID from Customer", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<CustomerModel> customerid = new List<CustomerModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CustomerModel model = new CustomerModel();
                    model.CustomerId = Convert.ToInt32(dt.Rows[i]["CustomerId"]);
                    customerid.Add(model);
                }
            }
            if (customerid.Count > 0)
                return JsonConvert.SerializeObject(customerid);

            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data Found";
                return JsonConvert.SerializeObject(response);
            }
        }
    }
}
