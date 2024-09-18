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
    public class SizeExplosionController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public SizeExplosionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("Get_SizeExplo")]
        public string Get_SizeExplosion()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_SizeExplosion", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<SizeExplosionModel> transfers = new List<SizeExplosionModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SizeExplosionModel model = new SizeExplosionModel();
                    model.ClientID = Convert.ToString(dt.Rows[i]["ClientID"]);
                    model.Size_Explosion = Convert.ToString(dt.Rows[i]["Size_Explosion"]);
                    model.SizeExplDesc = Convert.ToString(dt.Rows[i]["SizeExplDesc"]);
                    model.Divison = Convert.ToString(dt.Rows[i]["Divison"]);
                    model.SizeRange = Convert.ToString(dt.Rows[i]["SizeRange"]);
                    model.ExplRatio = Convert.ToString(dt.Rows[i]["ExplRatio"]);
                    model.ExplBy = Convert.ToString(dt.Rows[i]["ExplBy"]);
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
        string msg;
        //[Authorize]
        [HttpPost]

        public string CreateSizeExplosion(SizeExplosionsModel sizeexplosionmodel)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
                SqlCommand cmd = new SqlCommand("sp_SizeExplosionInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", sizeexplosionmodel.ClientID);
                cmd.Parameters.AddWithValue("@Size_Explosion", sizeexplosionmodel.Size_Explosion);
                cmd.Parameters.AddWithValue("@SizeExplDesc", sizeexplosionmodel.SizeExplDesc);
                cmd.Parameters.AddWithValue("@Divison", sizeexplosionmodel.Divison);
                cmd.Parameters.AddWithValue("@SizeRange", sizeexplosionmodel.SizeRange);
                cmd.Parameters.AddWithValue("@ExplBy", sizeexplosionmodel.ExplBy);
                cmd.Parameters.AddWithValue("@ModUser", sizeexplosionmodel.ModUser);


                cmd.Parameters.AddWithValue("@StatementType", "Insert");
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0)

                {
                    msg = "SizeExplosion created successfully";
                }
                else
                {
                    msg = "SizeExplosion not created";
                }
                con.Close();

            }
            catch (Exception ex)
            {
            }
            return msg;
        }
    }
}
