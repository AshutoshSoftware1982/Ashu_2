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
    public partial class Session : Form
    {
        public Session()
        {
            InitializeComponent();
        }

        private async void btn_Save_Click(object sender, EventArgs e)
        {
            SeasonModel size = new SeasonModel();
            size.ClientID = txt_ClientID.Text;
            size.Division=txt_Division.Text;
            size.Season=txt_Season.Text;
            size.SeasonDesc=txt_SeaDesc.Text;
            size.Active = com_Active.Text;
            size.BookingStartDate = dateTimePicker1.Value;
            size.BookingCancelDate = dateTimePicker5.Value;
            size.ShippingStartDate = dateTimePicker2.Value;
            size.ShippingCancelDate = dateTimePicker6.Value;
            size.CostEffectiveDateStart = dateTimePicker3.Value;
            size.CostEffectiveDateEnd = dateTimePicker7.Value;
            size.CostSheetCode = textBox6.Text;
            size.InvoiceDueDate = dateTimePicker4.Value;
            size.AllowedSalesFlag = com_Flag.Text;
            size.Sort = textBox5.Text;
            size.ModUser = txt_ModUser.Text;
            LoginResponse lr = await PostSizeAsync(size);
            if (lr != null)
            {
                MessageBox.Show("Your Data inserted.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset_Data();
            }
            else
            {
                MessageBox.Show("Your Data not inserted.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Session_Load(object sender, EventArgs e)
        {
            txt_ModUser.Text = Form1.SetValueForText1;
            Flag_Sales();
            LoadData();
            Active_Data();
            com_Active.Text = "Y";
        }

        public void Flag_Sales()
        {
            string[] Flag = { "S", "C" };
            for (int i = 0; i < Flag.Length; i++)
            {
                com_Flag.Items.Add(Flag[i]);
            }
        }
        public void Active_Data()
        {
            string[] Flag = { "Y", "N" };
            for (int i = 0; i < Flag.Length; i++)
            {
                com_Active.Items.Add(Flag[i]);
            }
        }
        public void LoadData()
        {
            try
            {

                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("http://localhost:82/api/Season/Get_Season");
                var consumeapi = hc.GetAsync("Get_Season");
                consumeapi.Wait();
                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    IList<SeasonsModel> MyDeserialisedObject =
                    JsonConvert.DeserializeObject<List<SeasonsModel>>(readdata.Content.ReadAsStringAsync().Result.ToString()).Cast<SeasonsModel>().ToList();
                    dataGridView1.DataSource = MyDeserialisedObject;
                    dataGridView1.Columns["TimeCreated"].DefaultCellStyle.Format = "HH:mm:ss";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Network Issue please check API");
            }
        }

        public async Task<LoginResponse> PostSizeAsync(SeasonModel request)
        {
            try
            {
              
                string jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                HttpClient _httpClient = new HttpClient();
               
                HttpResponseMessage response = await _httpClient.PostAsync("http://localhost:82/api/Season", content);

                
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

        private void txt_ClientID_DoubleClick(object sender, EventArgs e)
        {
            Client_Code5 client_Code5 = new Client_Code5();
            client_Code5.Show();
        }

        private void txt_Division_DoubleClick(object sender, EventArgs e)
        {
            Division_Code2 division_Code2 = new Division_Code2();
            division_Code2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        public void Reset_Data()
        {
            txt_ClientID.Text="";
            txt_Division.Text = "";
            txt_Season.Text = "";
            txt_SeaDesc.Text = "";
            com_Active.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
        }
    }
}
