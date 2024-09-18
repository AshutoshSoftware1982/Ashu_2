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
    public class VProduct_Transfer_BalanceController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public VProduct_Transfer_BalanceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetBalance")]
        public string GetTransfer()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from VProduct_Transfer_Balance", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<VProduct_Transfer_BalanceModel> transfers = new List<VProduct_Transfer_BalanceModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    VProduct_Transfer_BalanceModel model = new VProduct_Transfer_BalanceModel();
                    model.ProductID = Convert.ToInt32(dt.Rows[i]["ProductID"]);
                    model.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                    model.BarCode = Convert.ToString(dt.Rows[i]["BarCode"]);
                    model.Balance = Convert.ToInt32(dt.Rows[i]["Balance"]);
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
