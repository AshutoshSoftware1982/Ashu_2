using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
namespace WindowsFormsApp1
{
    public partial class Size_RangeData1 : Form
    {
        public Size_RangeData1()
        {
            InitializeComponent();
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Style_Master fr = (Style_Master)Application.OpenForms["Style_Master"];
            int row = e.RowIndex;
            fr.txt_SizeRange.Text = Convert.ToString(dataGridView1[0, row].Value);
            fr.txt_Sizerange7.Text = Convert.ToString(dataGridView1[1, row].Value);
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
    }
}
