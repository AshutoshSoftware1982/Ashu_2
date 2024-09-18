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
    public class LoginController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetLogin")]
        public string GetLogin_Code(string UserName,string UPassword)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand sc = new SqlCommand("login_pro", con);
            LoginModel model = new LoginModel();
            sc.Parameters.Add(new SqlParameter("@UserName", UserName));
            sc.Parameters.Add(new SqlParameter("@Password", UPassword));
            
            sc.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = sc;
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<LoginModel> transfers = new List<LoginModel>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   
                    model.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
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
