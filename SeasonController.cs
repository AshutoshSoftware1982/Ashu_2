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
    public class SeasonController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public SeasonController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("Get_Season")]
        public string Get_SeasonData()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_Season", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<SeasonsModel> transfers = new List<SeasonsModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SeasonsModel model = new SeasonsModel();
                    model.ClientID = Convert.ToString(dt.Rows[i]["ClientID"]);
                    model.Division = Convert.ToString(dt.Rows[i]["Division"]);
                    model.Season = Convert.ToString(dt.Rows[i]["Season"]);
                    model.SeasonDesc = Convert.ToString(dt.Rows[i]["SeasonDesc"]);
                    model.Active = Convert.ToString(dt.Rows[i]["Active"]);
                    model.BookingStartDate = Convert.ToDateTime(dt.Rows[i]["BookingStartDate"]);
                    model.BookingCancelDate = Convert.ToDateTime(dt.Rows[i]["BookingCancelDate"]);
                    model.ShippingStartDate = Convert.ToDateTime(dt.Rows[i]["ShippingStartDate"]);
                    model.ShippingCancelDate = Convert.ToDateTime(dt.Rows[i]["ShippingCancelDate"]);
                    model.CostEffectiveDateStart = Convert.ToDateTime(dt.Rows[i]["CostEffectiveDateStart"]);
                    model.CostEffectiveDateEnd = Convert.ToDateTime(dt.Rows[i]["CostEffectiveDateEnd"]);
                    model.CostSheetCode = Convert.ToString(dt.Rows[i]["CostSheetCode"]);
                    model.InvoiceDueDate = Convert.ToDateTime(dt.Rows[i]["InvoiceDueDate"]);
                    model.AllowedSalesFlag = Convert.ToString(dt.Rows[i]["AllowedSalesFlag"]);
                    model.Sort = Convert.ToString(dt.Rows[i]["Sort"]);
                    model.ModUser = Convert.ToString(dt.Rows[i]["ModUser"]);
                    model.LastMod = Convert.ToDateTime(dt.Rows[i]["LastMod"]);
                    model.TimeCreated = Convert.ToDateTime(dt.Rows[i]["TimeCreated"]);
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

        public string CreateSeason(SeasonModel seasonmodel)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
                SqlCommand cmd = new SqlCommand("sp_SeasonInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", seasonmodel.ClientID);
                cmd.Parameters.AddWithValue("@Division", seasonmodel.Division);
                cmd.Parameters.AddWithValue("@Season", seasonmodel.Season);
                cmd.Parameters.AddWithValue("@SeasonDesc", seasonmodel.SeasonDesc);
                cmd.Parameters.AddWithValue("@Active", seasonmodel.Active);
                cmd.Parameters.AddWithValue("@BookingStartDate", seasonmodel.BookingStartDate);
                cmd.Parameters.AddWithValue("@BookingCancelDate", seasonmodel.BookingCancelDate);
                cmd.Parameters.AddWithValue("@ShippingStartDate", seasonmodel.ShippingStartDate);
                cmd.Parameters.AddWithValue("@ShippingCancelDate", seasonmodel.ShippingCancelDate);
                cmd.Parameters.AddWithValue("@CostEffectiveDateStart", seasonmodel.CostEffectiveDateStart);
                cmd.Parameters.AddWithValue("@CostEffectiveDateEnd", seasonmodel.CostEffectiveDateEnd);
                cmd.Parameters.AddWithValue("@CostSheetCode", seasonmodel.CostSheetCode);
                cmd.Parameters.AddWithValue("@InvoiceDueDate", seasonmodel.InvoiceDueDate);
                cmd.Parameters.AddWithValue("@AllowedSalesFlag", seasonmodel.AllowedSalesFlag);
                cmd.Parameters.AddWithValue("@Sort", seasonmodel.Sort);
                cmd.Parameters.AddWithValue("@ModUser", seasonmodel.ModUser);

                cmd.Parameters.AddWithValue("@StatementType", "Insert");
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0)

                {
                    msg = "Season created successfully";
                }
                else
                {
                    msg = "Season not created";
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
