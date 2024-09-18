using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class SizeExplosion : Form
    {
        public SizeExplosion()
        {
            InitializeComponent();
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            Client_Code3 client_Code = new Client_Code3();
            client_Code.Show();
        }

        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            Division2 division2 = new Division2();
            division2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            SizeRangeData3 sizeRangeData3 = new SizeRangeData3();
            sizeRangeData3.Show();
        }

        private void SizeExplosion_Load(object sender, EventArgs e)
        {
            Get_Expl();
            com_ExplBy.Text = "N";
            textBox4.Text = "0.00";
            LoadData();
            textBox6.Text = Form1.SetValueForText1;
            LoadData_Balance();
        }
        public void LoadData()
        {
            try
            {

                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("http://localhost:82/api/SizeExplosion/Get_SizeExplo");
                var consumeapi = hc.GetAsync("Get_SizeExplo");
                consumeapi.Wait();
                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    IList<SizeExplosionModel> MyDeserialisedObject =
                    JsonConvert.DeserializeObject<List<SizeExplosionModel>>(readdata.Content.ReadAsStringAsync().Result.ToString()).Cast<SizeExplosionModel>().ToList();
                    dataGridView2.DataSource = MyDeserialisedObject;
                    dataGridView2.Columns["TimeCreated"].DefaultCellStyle.Format = "HH:mm:ss";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Network Issue Please check API");
            }
        }

        private void com_ExplBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void Get_Expl()
        {
            string[] Expl = { "Y", "N" };
            for (int i = 0; i < Expl.Length; i++)
            {
                com_ExplBy.Items.Add(Expl[i]);
            }

        }
        
        public async Task<LoginResponse> PostSizeAsync(SizeExplosionsModel request)
        {
            try
            {
                // Serialize the request object to JSON
                string jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                HttpClient _httpClient = new HttpClient();
                // Send POST request
                HttpResponseMessage response = await _httpClient.PostAsync("http://localhost:82/api/SizeExplosion", content);

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
        
        private async void btn_Save_Click(object sender, EventArgs e)
        {
            SizeExplosionsModel size = new SizeExplosionsModel();
            size.ClientID = textBox1.Text;
            size.Size_Explosion = textBox2.Text;
            size.SizeExplDesc = textBox5.Text;
            size.Divison = textBox3.Text;
            size.SizeRange = textBox4.Text;
            size.ExplBy = com_ExplBy.Text;
            size.ModUser = textBox6.Text;
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

        public void Reset_Data()
        {
            textBox1.Text = "" ;
            textBox2.Text = "";
            textBox5.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            com_ExplBy.Text = "";
        }

        public void LoadData_Balance()
        {
            try
            {

                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("http://localhost:82/api/SizeExplosion/Get_SizeExplo");
                var consumeapi = hc.GetAsync("Get_SizeExplo");
                consumeapi.Wait();
                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    IList<SizeExplosion_BalanceModel> MyDeserialisedObject =
                    JsonConvert.DeserializeObject<List<SizeExplosion_BalanceModel>>(readdata.Content.ReadAsStringAsync().Result.ToString()).Cast<SizeExplosion_BalanceModel>().ToList();
                    dataGridView1.DataSource = MyDeserialisedObject;
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Network Issue Please check API");
            }
        }
    }
}
