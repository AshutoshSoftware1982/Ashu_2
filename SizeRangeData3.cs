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
    public partial class SizeRangeData3 : Form
    {
        public SizeRangeData3()
        {
            InitializeComponent();
        }

        private void SizeRangeData3_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            try
            {

                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("http://localhost:82/api/Size_Range/GetSize_Range");
                var consumeapi = hc.GetAsync("GetSize_Range");
                consumeapi.Wait();
                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    IList<Size_RangeModel> MyDeserialisedObject =
                    JsonConvert.DeserializeObject<List<Size_RangeModel>>(readdata.Content.ReadAsStringAsync().Result.ToString()).Cast<Size_RangeModel>().ToList();
                    dataGridView1.DataSource = MyDeserialisedObject;
                    //label1.Visible = false;

                   

                }
            }
            catch (Exception)
            {

                //label1.Text = "Please check API";
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SizeExplosion fr = (SizeExplosion)Application.OpenForms["SizeExplosion"];
            int row = e.RowIndex;
            fr.textBox4.Text = Convert.ToString(dataGridView1[0, row].Value);
            //fr.textBox6.Text = Convert.ToString(dataGridView1[1, row].Value);
            this.Hide();
        }
    }
}
