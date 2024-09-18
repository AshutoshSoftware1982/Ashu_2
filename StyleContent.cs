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
    public partial class StyleContent : Form
    {
        public StyleContent()
        {
            InitializeComponent();
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            Client_Code6 client_Code6 = new Client_Code6();
            client_Code6.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset_Data();
        }
        public void Reset_Data()
        {
            txt_ClientCode.Text = "";
            txt_ContentCode.Text = "";
            txt_ContentDesc.Text = "";
        }

        private void StyleContent_Load(object sender, EventArgs e)
        {
            LoadData();
            textBox1.Text = Form1.SetValueForText1;
        }
        public void LoadData()
        {
            try
            {

                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("http://localhost:82/api/StyleContent/Get_Content");
                var consumeapi = hc.GetAsync("Get_Content");
                consumeapi.Wait();
                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    IList<StyleContentModel> MyDeserialisedObject =
                    JsonConvert.DeserializeObject<List<StyleContentModel>>(readdata.Content.ReadAsStringAsync().Result.ToString()).Cast<StyleContentModel>().ToList();
                    dataGridView1.DataSource = MyDeserialisedObject;
                    dataGridView1.Columns["TimeCreated"].DefaultCellStyle.Format = "HH:mm:ss";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Network Issue please check API");
            }
        }
    }
}
