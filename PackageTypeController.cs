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
    public class PackageTypeController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public PackageTypeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetPackageType")]
        public string GetPackage()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from PKs_Type", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<PackageType_Model> transfers = new List<PackageType_Model>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   
                    PackageType_Model model = new PackageType_Model();
                    model.PKID = Convert.ToInt32(dt.Rows[i]["PKID"]);
                    model.CustomerID = Convert.ToInt32(dt.Rows[i]["CustomerID"]);
                    model.CS_Pack = Convert.ToString(dt.Rows[i]["CS_Pack"]);
                    model.Pack_Desc = Convert.ToString(dt.Rows[i]["Pack_Desc"]);
                    model.Pack_Qty = Convert.ToInt32(dt.Rows[i]["Pack_Qty"]);
                    model.Pack_Cat = Convert.ToString(dt.Rows[i]["Pack_Cat"]);
                    model.UOM = Convert.ToString(dt.Rows[i]["UOM"]);
                    model.EDI_UOM = Convert.ToString(dt.Rows[i]["EDI_UOM"]);

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
