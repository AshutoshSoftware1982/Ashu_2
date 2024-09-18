using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Size : Form
    {
        SizeModel model = new SizeModel ();
        public Size()
        {
            InitializeComponent();
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            Reset_Data();
        }
        public void Reset_Data()
        {
            txt_ClientID.Text = "";
            txt_Size.Text = "";
            txt_SizeDesc.Text = "";
            txt_Lang1.Text = "";
            txt_Lang2.Text = "";
            txt_Lang3.Text = "";
            txt_Lang4.Text = "";
            txt_lang5.Text = "";
            txt_lang6.Text = "";
            txt_NrfSize.Text = "";
            txt_SizeGroup.Text = "";
        }

        private void txt_ClientID_DoubleClick(object sender, EventArgs e)
        {
            Client_Code2 client_Code = new Client_Code2();
            client_Code.Show();
        }

        public void LoadData()
        {
            try
            {

                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("http://localhost:82/api/Size/get_Size");
                var consumeapi = hc.GetAsync("get_Size");
                consumeapi.Wait();
                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    IList<SizeModel> MyDeserialisedObject =
                    JsonConvert.DeserializeObject<List<SizeModel>>(readdata.Content.ReadAsStringAsync().Result.ToString()).Cast<SizeModel>().ToList();
                    dataGridView1.DataSource = MyDeserialisedObject;
                    dataGridView1.Columns["TimeCreated"].DefaultCellStyle.Format = "HH:mm:ss";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Network Issue please check API");
            }
        }

        private void Size_Load(object sender, EventArgs e)
        {
            
            LoadData();
            txt_ModUser.Text = Form1.SetValueForText1;
        }

        private void txt_ClientID_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btn_Save_Click(object sender, EventArgs e)
        {
            SizeModel size = new SizeModel();
            size.ClientID = txt_ClientID.Text;
            size.Size = txt_Size.Text;
            size.SizeDesc = txt_SizeDesc.Text;
            size.Lang1Desc = txt_Lang1.Text;
            size.Lang2Desc = txt_Lang2.Text;
            size.Lang3Desc = txt_Lang3.Text;
            size.Lang4Desc = txt_Lang4.Text;
            size.Lang5Desc = txt_lang5.Text;
            size.Lang6Desc = txt_lang6.Text;
            size.NrfSize = txt_NrfSize.Text;
            size.sizeGroup = txt_SizeGroup.Text;
            size.ModUser = txt_ModUser.Text;
            LoginResponse lr = await PostSizeAsync(size);
            if (lr != null)
            {
                MessageBox.Show("Your Data inserted.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Your Data not inserted.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        public async Task<LoginResponse> PostSizeAsync(SizeModel request)
        {
            try
            {
                // Serialize the request object to JSON
                string jsonRequest = JsonConvert.SerializeObject(request);
                //var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                HttpClient _httpClient = new HttpClient();
                //string headerName = "Authorization";
                //string headerValue = "Bearer " + GetOAuthToken();
                // _httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", GetOAuthToken()));
                var requestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json"),
                    RequestUri = new Uri("http://localhost:83/api/Size")
                };
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", GetOAuthToken());
                // Send POST request
                //HttpResponseMessage response = await _httpClient.PostAsync("http://localhost:82/api/Size", content);
                HttpResponseMessage response = await _httpClient.SendAsync(requestMessage);
                //var response = await _httpClient.PostAsync(requestMessage);

                // Ensure the response status code is successful
                response.EnsureSuccessStatusCode();

                // Read and deserialize the response content
                string jsonResponse = await response.Content.ReadAsStringAsync();
                LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(jsonResponse);

                return loginResponse;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return new LoginResponse { Success = false, Message = $"Error: {ex.Message}" };
            }
        }
        
        public string GetOAuthToken()
        {
            string token;
            using (HttpClient httpClient = new HttpClient())
            {
                HttpClient client = new HttpClient();
                //client.BaseAddress = new Uri("http://192.168.1.66:82/token");
                client.BaseAddress = new Uri("http://localhost:83/token");
                var login = new Dictionary<string, string>
                {
          {"grant_type", "password"},
          {"username", Form1.SetValueForText1},
          {"password", Form1.SetValueForText2},
         
            };
                var response = client.PostAsync("Token", new FormUrlEncodedContent(login)).Result;
               token = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content.ReadAsStringAsync().Result)["access_token"];
            }
            return token;   
        }

    }
}

        
   
