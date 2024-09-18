using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using WebApplication1.Model;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        string msg;
        public readonly IConfiguration _configuration;
        public SizeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("Get_Size")]
        public string Get_SizeData()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_Size", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<SizeModel> transfers = new List<SizeModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SizeModel model = new SizeModel();
                    model.ClientID = Convert.ToString(dt.Rows[i]["ClientID"]);
                    model.Size = Convert.ToString(dt.Rows[i]["Size"]);
                    model.SizeDesc = Convert.ToString(dt.Rows[i]["SizeDesc"]);
                    model.Lang1Desc = Convert.ToString(dt.Rows[i]["Lang1Desc"]);
                    model.Lang2Desc = Convert.ToString(dt.Rows[i]["Lang2Desc"]);
                    model.Lang3Desc = Convert.ToString(dt.Rows[i]["Lang3Desc"]);
                    model.Lang4Desc = Convert.ToString(dt.Rows[i]["Lang4Desc"]);
                    model.Lang5Desc = Convert.ToString(dt.Rows[i]["Lang5Desc"]);
                    model.Lang6Desc = Convert.ToString(dt.Rows[i]["Lang6Desc"]);
                    model.NrfSize = Convert.ToString(dt.Rows[i]["NrfSize"]);
                    model.sizeGroup = Convert.ToString(dt.Rows[i]["sizeGroup"]);
                    model.LastMod = Convert.ToDateTime(dt.Rows[i]["LastMod"]);
                    model.TimeCreated = Convert.ToDateTime(dt.Rows[i]["TimeCreated"]);
                    model.ModUser = Convert.ToString(dt.Rows[i]["ModUser"]);

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
        //[Authorize]
        [HttpPost]
        public string Create_Size(SizeModel sizenmodel)
        {
            try
            {
                string msg;
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
                SqlCommand cmd = new SqlCommand("sp_SizeInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", sizenmodel.ClientID);
                cmd.Parameters.AddWithValue("@Size", sizenmodel.Size);
                cmd.Parameters.AddWithValue("@SizeDesc", sizenmodel.SizeDesc);
                cmd.Parameters.AddWithValue("@Lang1Desc", sizenmodel.Lang1Desc);
                cmd.Parameters.AddWithValue("@Lang2Desc", sizenmodel.Lang2Desc);
                cmd.Parameters.AddWithValue("@Lang3Desc", sizenmodel.Lang3Desc);
                cmd.Parameters.AddWithValue("@Lang4Desc", sizenmodel.Lang4Desc);
                cmd.Parameters.AddWithValue("@Lang5Desc", sizenmodel.Lang5Desc);
                cmd.Parameters.AddWithValue("@Lang6Desc", sizenmodel.Lang6Desc);
                cmd.Parameters.AddWithValue("@NrfSize", sizenmodel.NrfSize);
                cmd.Parameters.AddWithValue("@sizeGroup", sizenmodel.sizeGroup);
                cmd.Parameters.AddWithValue("@ModUser", sizenmodel.ModUser);

                cmd.Parameters.AddWithValue("@StatementType", "Insert");
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0)

                {
                    msg = "Size created successfully";
                }
                else
                {
                    msg = "Size not created";
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
