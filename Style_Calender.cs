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
    public partial class Style_Calender : Form
    {
        public Style_Calender()
        {
            InitializeComponent();
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadData()
        {
            try
            {

                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("http://localhost:82/api/StyleCalendar/GetCalendar");
                var consumeapi = hc.GetAsync("GetCalendar");
                consumeapi.Wait();
                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    IList<StyleCalendarModel> MyDeserialisedObject =
                    JsonConvert.DeserializeObject<List<StyleCalendarModel>>(readdata.Content.ReadAsStringAsync().Result.ToString()).Cast<StyleCalendarModel>().ToList();
                    dataGridView1.DataSource = MyDeserialisedObject;
                    label7.Visible = false;

                   


                }
            }
            catch (Exception)
            {

                label7.Text = "Please check API";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            txt_Calendar.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
        }

        private void txt_Calendar_DoubleClick(object sender, EventArgs e)
        {
            Calendar_Data data = new Calendar_Data();
            data.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Style_Master style_Master = new Style_Master();
            style_Master.Show();
            this.Hide();
        }
    }
}
