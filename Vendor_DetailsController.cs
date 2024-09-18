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
    public class Vendor_DetailsController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public Vendor_DetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllVendor")]
        public string GetVendor()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from Vendor_Details", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Vendor_DetailsModel> transfers = new List<Vendor_DetailsModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Vendor_DetailsModel model = new Vendor_DetailsModel();
                    model.Vendor_ID = Convert.ToInt32(dt.Rows[i]["Vendor_Id"]);
                    model.Vendor_Code = Convert.ToString(dt.Rows[i]["VendorCode"]);
                    model.Vendor_Name = Convert.ToString(dt.Rows[i]["Vendor_Name"]);
                    model.Vendor_EmaiID = Convert.ToString(dt.Rows[i]["Vendor_EmaiID"]);
                    model.Vendor_Address = Convert.ToString(dt.Rows[i]["Vendor_Address"]);
                    model.Vendor_Phone = Convert.ToString(dt.Rows[i]["Vendor_Phone"]);

                    transfers.Add(model);
                }
            }
            if (transfers.Count > 0)
                return JsonConvert.SerializeObject(transfers);

            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "Data Not Found";
                return JsonConvert.SerializeObject(response);
            }
        }

        // Bind Only Vendor_ID and Vendor Code

        [HttpGet]
        [Route("GetVendor_IDCODE")]
        public string GetVendor_ID()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select Vendor_ID,VendorCode from Vendor_Details", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Vendor_DetailsModel1> transfers = new List<Vendor_DetailsModel1>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Vendor_DetailsModel1 model = new Vendor_DetailsModel1();
                    model.Vendor_ID = Convert.ToInt32(dt.Rows[i]["Vendor_Id"]);
                    model.Vendor_Code = Convert.ToString(dt.Rows[i]["VendorCode"]);
                    

                    transfers.Add(model);
                }
            }
            if (transfers.Count > 0)
                return JsonConvert.SerializeObject(transfers);

            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "Data Not Found";
                return JsonConvert.SerializeObject(response);
            }
        }
    }
}
