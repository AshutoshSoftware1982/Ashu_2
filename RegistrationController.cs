using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebApplication1.Model;
using Microsoft.Extensions.Configuration;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        string msg;
        public readonly IConfiguration _configuration;
        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllProduct")]
        public string GetProduct()
        {
            return "OK";
        }


       
      
        
        
        // [Authorize]
        [HttpPost]

        public string RegisterUser(RegistrationModel usermodel)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProviderAppCon").ToString());
                SqlCommand cmd = new SqlCommand("sp_register", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_Type", usermodel.User_Type);
                cmd.Parameters.AddWithValue("@UserName", usermodel.UserName);
                cmd.Parameters.AddWithValue("@UPassword", usermodel.UPassword);
                cmd.Parameters.AddWithValue("@UCPassword", usermodel.UCPassword);
                cmd.Parameters.AddWithValue("@CompanyID", usermodel.CompanyId);
                cmd.Parameters.AddWithValue("@Country_Name", usermodel.Country_Name);

                cmd.Parameters.AddWithValue("@StatementType", "Insert");
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0)

                {
                    msg = "User created successfully";
                }
                else
                {
                    msg = "User not created";
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
