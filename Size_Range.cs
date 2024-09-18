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
    public partial class Size_Range : Form
    {
        public Size_Range()
        {
            InitializeComponent();
        }

        private void txt_ClientCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_ClientCode_DoubleClick(object sender, EventArgs e)
        {
            Client_Code1 client_Code = new Client_Code1();
            
            client_Code.Show();
        }

        private void txt_Division_DoubleClick(object sender, EventArgs e)
        {
            Division_Code1 client_Code = new Division_Code1();
            
            client_Code.Show();
        }

        private void txt_SizeGroup_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_SizeGroup_DoubleClick(object sender, EventArgs e)
        {
            Size_RangeData2 size_RangeData = new Size_RangeData2();
            
            size_RangeData.ShowDialog();
        }

        private void Size_Range_Load(object sender, EventArgs e)
        {
            Load_Active();
            com_Active.Text = "Y";
            LoadData();
            textBox1.Text = Form1.SetValueForText1;
        }
        public void Load_Active()
        {
            string[] active_name = { "Y", "N" };
            for(int i = 0; i < active_name.Length; i++)
            {
                com_Active.Items.Add(active_name[i]);
            }
        }
        public void LoadData()
        {
            try
            {

                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("http://localhost:82/api/SizeRange/Get_SizeRange");
                var consumeapi = hc.GetAsync("Get_SizeRange");
                consumeapi.Wait();
                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    IList<SizeRangeModel> MyDeserialisedObject =
                    JsonConvert.DeserializeObject<List<SizeRangeModel>>(readdata.Content.ReadAsStringAsync().Result.ToString()).Cast<SizeRangeModel>().ToList();
                    dataGridView2.DataSource = MyDeserialisedObject;
                    dataGridView2.Columns["TimeCreated"].DefaultCellStyle.Format = "HH:mm:ss";
                }
            }
            catch (Exception)
            {
               // MessageBox.Show("Network Issue Please check API");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txt_SizeRange_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SizeRangeModel size = new SizeRangeModel();
            size.ClientID = txt_ClientCode.Text;
            size.Division = txt_Division.Text;
            size.SizeRange = txt_SizeRange.Text;
            size.SizeR = textBox4.Text;
            size.SizeRangeGroup = txt_SizeGroup.Text;
            size.SIzeUDF01 = textBox7.Text;
            size.SIzeUDF02 = textBox8.Text;
            size.SIzeUDF03 = textBox9.Text;
            size.Active = com_Active.Text;
            size.ModUser=textBox1.Text;
            await PostSizeAsync(size);
        }
        public async Task<LoginResponse> PostSizeAsync(SizeRangeModel request)
        {
            try
            {
                // Serialize the request object to JSON
                string jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                HttpClient _httpClient = new HttpClient();
                // Send POST request
                HttpResponseMessage response = await _httpClient.PostAsync("http://localhost:82/api/SizeRange", content);

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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txt_SizeRange_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            dataGridViewRow.CreateCells(dataGridView1);
           
        }
    }
}
