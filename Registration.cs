using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class Registration : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=ashutosh;Initial Catalog=ERP_Project;Persist Security Info=True;User ID=sa;password=cellhut*321;");
        public Registration()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            RegistrationModel size = new RegistrationModel();
            size.User_Type = comUser_Type.Text;
            size.UserName  = txtusername.Text;
            size.UPassword = txtpassword.Text;
            size.UCPassword = txtconfirmpassword.Text;
            size.CompanyId = Convert.ToInt32(com_CompanyID.Text);
            size.Country_Name = com_Country.Text;

            try

            {

                LoginResponse lr = await PostSizeAsync(size);
                //if (txtconfirmpassword.Text == txtpassword.Text)
                //{
                   
                //    MessageBox.Show("User password does not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                if (lr!=null)
                {
                    MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                else
                {
                    MessageBox.Show("User Name does not allow duplicate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception)
            {
                
            }
        }
        public async Task<LoginResponse> PostSizeAsync(RegistrationModel request)
        {
            try
            {
               
                string jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                HttpClient _httpClient = new HttpClient();
               
                HttpResponseMessage response = await _httpClient.PostAsync("http://localhost:82/api/Registration", content);

               
                response.EnsureSuccessStatusCode();

               
                string jsonResponse = await response.Content.ReadAsStringAsync();
                LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(jsonResponse);

                return loginResponse;
            }
            catch (Exception ex)
            {
              
                return new LoginResponse { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            User_Type();
            Company_ID();
            LoadCountry();
        }
        public void User_Type()
        {
            string[] User_Type = { "ADMIN", "VENDOR", "CLIENT" };
            for (int i = 0; i < User_Type.Length; i++)
            {
                comUser_Type.Items.Add(User_Type[i]);
            }
        }
        public void Company_ID()
        {
            
            for (int i = 0; i<2; i++)
            {
                com_CompanyID.Items.Add(i);
            }
        }
        public async void LoadCountry()
        {
            string apiUrl = "http://localhost:82/api/Country/GetAllCountry";

            try
            {
                List<string> data = await FetchDataFromApiAsync(apiUrl);
                com_Country.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
        }
        public async Task<List<string>> FetchDataFromApiAsync(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JArray jsonArray = JArray.Parse(responseBody);

                List<string> items = jsonArray.Select(item => item["Country_Name"].ToString()).ToList();
                return items;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }
    }
}
