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
    public class Size_ColorController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public Size_ColorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("Get_Color")]
        public string Get_ColorData()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_color", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Size_ColorModel> transfers = new List<Size_ColorModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Size_ColorModel model = new Size_ColorModel();
                    model.ClientID = Convert.ToString(dt.Rows[i]["ClientID"]);
                    model.Color = Convert.ToString(dt.Rows[i]["Color"]);
                    model.ColorFlag = Convert.ToString(dt.Rows[i]["ColorFlag"]);
                    model.ShortColorDesc = Convert.ToString(dt.Rows[i]["ShortColorDesc"]);
                    model.ColorDesc = Convert.ToString(dt.Rows[i]["ColorDesc"]);
                    model.ColorGroup = Convert.ToString(dt.Rows[i]["ColorGroup"]);
                    model.NRFColor = Convert.ToString(dt.Rows[i]["NRFColor"]);
                    model.ColorRef = Convert.ToString(dt.Rows[i]["ColorRef"]);
                    model.ColorStandard = Convert.ToString(dt.Rows[i]["ColorStandard"]);
                    model.ColorName = Convert.ToString(dt.Rows[i]["ColorName"]);
                    model.LegacyColor = Convert.ToString(dt.Rows[i]["LegacyColor"]);
                    model.ColorUDF01 = Convert.ToString(dt.Rows[i]["ColorUDF01"]);
                    model.ColorUDF02 = Convert.ToString(dt.Rows[i]["ColorUDF02"]);
                    model.ColorUDF03 = Convert.ToString(dt.Rows[i]["ColorUDF03"]);
                    model.ColorUDF04 = Convert.ToString(dt.Rows[i]["ColorUDF04"]);
                    model.ColorUDF05 = Convert.ToString(dt.Rows[i]["ColorUDF05"]);
                    model.Active = Convert.ToString(dt.Rows[i]["Active"]);
                    model.LastMod = Convert.ToDateTime(dt.Rows[i]["LastMod"]);
                    model.TimeCretaed = Convert.ToDateTime(dt.Rows[i]["TimeCretaed"]);
                    model.ModUser = Convert.ToString(dt.Rows[i]["ModUser"]);
                    model.PantoneColor = Convert.ToString(dt.Rows[i]["PantoneColor"]);
                    model.C = Convert.ToString(dt.Rows[i]["C"]);
                    model.M = Convert.ToString(dt.Rows[i]["M"]);
                    model.Y = Convert.ToString(dt.Rows[i]["Y"]);
                    model.K = Convert.ToString(dt.Rows[i]["K"]);
                    model.RGB = Convert.ToString(dt.Rows[i]["RGB"]);
                   
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
        // [Authorize]
        [HttpPost]

        public string CreateColor(ColorsModel colormodel)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
                SqlCommand cmd = new SqlCommand("sp_ColorInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", colormodel.ClientID);
                cmd.Parameters.AddWithValue("@Color", colormodel.Color);
                cmd.Parameters.AddWithValue("@ColorFlag", colormodel.ColorFlag);
                cmd.Parameters.AddWithValue("@ShortColorDesc", colormodel.ShortColorDesc);
                cmd.Parameters.AddWithValue("@ColorDesc", colormodel.ColorDesc);
                cmd.Parameters.AddWithValue("@ColorGroup", colormodel.ColorGroup);
                cmd.Parameters.AddWithValue("@NRFColor", colormodel.NRFColor);
                cmd.Parameters.AddWithValue("@ColorRef", colormodel.ColorRef);
                cmd.Parameters.AddWithValue("@ColorStandard", colormodel.ColorStandard);
                cmd.Parameters.AddWithValue("@ColorName", colormodel.ColorName);
                cmd.Parameters.AddWithValue("@LegacyColor", colormodel.LegacyColor);
                cmd.Parameters.AddWithValue("@ColorUDF01", colormodel.ColorUDF01);
                cmd.Parameters.AddWithValue("@ColorUDF02", colormodel.ColorUDF02);
                cmd.Parameters.AddWithValue("@ColorUDF03", colormodel.ColorUDF03);
                cmd.Parameters.AddWithValue("@ColorUDF04", colormodel.ColorUDF04);
                cmd.Parameters.AddWithValue("@ColorUDF05", colormodel.ColorUDF05);
                cmd.Parameters.AddWithValue("@C", colormodel.C);
                cmd.Parameters.AddWithValue("@M", colormodel.M);
                cmd.Parameters.AddWithValue("@Y", colormodel.Y);
                cmd.Parameters.AddWithValue("@K", colormodel.K);
                cmd.Parameters.AddWithValue("@ModUser", colormodel.ModUser);
                cmd.Parameters.AddWithValue("@NRFColorList", colormodel.NRFColorList);
                cmd.Parameters.AddWithValue("@StatementType", "Insert");
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0)

                {
                    msg = "Color created successfully";
                }
                else
                {
                    msg = "Color not created";
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
