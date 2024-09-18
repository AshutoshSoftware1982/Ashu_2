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
    public partial class Size_RangeData2 : Form
    {
        public Size_RangeData2()
        {
            InitializeComponent();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Size_Range fr = (Size_Range)Application.OpenForms["Size_Range"];
            int row = e.RowIndex;
            fr.txt_SizeGroup.Text = Convert.ToString(dataGridView1[0, row].Value);
            fr.textBox6.Text = Convert.ToString(dataGridView1[1, row].Value);
            this.Hide();
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

                // label1.Text = "Please check API";
            }
        }

        private void Size_RangeData2_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
