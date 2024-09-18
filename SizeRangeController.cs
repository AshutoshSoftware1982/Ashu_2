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
    public class SizeRangeController : ControllerBase
    {
        string msg;
        public readonly IConfiguration _configuration;
        public SizeRangeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("Get_SizeRange")]
        public string Get_SizeRangeData()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_size_range", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<SizeRangeModel> transfers = new List<SizeRangeModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SizeRangeModel model = new SizeRangeModel();
                    model.ClientID = Convert.ToString(dt.Rows[i]["ClientID"]);
                    model.Division = Convert.ToString(dt.Rows[i]["Division"]);
                    model.SizeRange = Convert.ToString(dt.Rows[i]["SizeRange"]);
                    model.SizeR = Convert.ToString(dt.Rows[i]["SizeR"]);
                    model.SizeRangeGroup = Convert.ToString(dt.Rows[i]["SizeRangeGroup"]);
                    model.SIzeUDF01 = Convert.ToString(dt.Rows[i]["SIzeUDF01"]);
                    model.SIzeUDF02 = Convert.ToString(dt.Rows[i]["SIzeUDF02"]);
                    model.SIzeUDF03 = Convert.ToString(dt.Rows[i]["SIzeUDF03"]);
                    model.Active = Convert.ToString(dt.Rows[i]["Active"]);
                    model.LastMod= Convert.ToDateTime(dt.Rows[i]["LastMod"]);
                    model.TimeCreated= Convert.ToDateTime(dt.Rows[i]["TimeCreated"]);
                    model.ModUser= Convert.ToString(dt.Rows[i]["ModUser"]);
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
        [HttpPost]
        public string CreateSizeRange(SizeRangeModel sizenrangemodel)
        {
            
            try
            {
            
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
                SqlCommand cmd = new SqlCommand("sp_SizeRangeInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", sizenrangemodel.ClientID);
                cmd.Parameters.AddWithValue("@Division", sizenrangemodel.Division);
                cmd.Parameters.AddWithValue("@SizeRange", sizenrangemodel.SizeRange);
                cmd.Parameters.AddWithValue("@SizeR", sizenrangemodel.SizeR);
                cmd.Parameters.AddWithValue("@SizeRangeGroup", sizenrangemodel.SizeRangeGroup);
                cmd.Parameters.AddWithValue("@SIzeUDF01", sizenrangemodel.SIzeUDF01);
                cmd.Parameters.AddWithValue("@SIzeUDF02", sizenrangemodel.SIzeUDF02);
                cmd.Parameters.AddWithValue("@SIzeUDF03", sizenrangemodel.SIzeUDF03);
                cmd.Parameters.AddWithValue("@Active", sizenrangemodel.Active);
                cmd.Parameters.AddWithValue("@ModUser", sizenrangemodel.ModUser);
                cmd.Parameters.AddWithValue("@StatementType", "Insert");
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0)

                {
                    msg = "Size Range created successfully";
                }
                else
                {
                    msg = "Size Range not created";
                }
                con.Close();

            }
            catch (Exception)
            {
            }
            return msg;
        }
    }
}
