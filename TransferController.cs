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
    public class TransferController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public TransferController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllTransfer")]
        public string GetTransfer()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from Transfer", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<TransferModel> transfers = new List<TransferModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TransferModel model = new TransferModel();
                    model.TransferID = Convert.ToInt32(dt.Rows[i]["TransferID"]);
                    model.ProductID = Convert.ToInt32(dt.Rows[i]["ProductID"]);
                    model.TransferQuantity = Convert.ToInt32(dt.Rows[i]["TransferQuantity"]);
                    model.SentDate = Convert.ToDateTime(dt.Rows[i]["SentDate"]);
                    model.ReclreadDate = Convert.ToDateTime(dt.Rows[i]["ReclreadDate"]);

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
