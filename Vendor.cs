using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Net.Http;
namespace WindowsFormsApp1
{
    public partial class Vendor : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=ashutosh;Initial Catalog=ERP_Project;Persist Security Info=True;User ID=sa;password=cellhut*321;");
        public Vendor()
        {
            InitializeComponent();
        }

        private void Vendor_Load(object sender, EventArgs e)
        {

            Client_Code();
            comboBox1.Enabled = false;
            LoadCountry();
        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        //http://localhost:82/api/Vendor/GetCustomerId
        public async void Client_Code()
        {

            string apiUrl = "http://localhost:82/api/Customer/GetClientCode";

            try
            {
                List<string> data = await FetchClientFromApiAsync(apiUrl);
                comboBox1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
        }
        public async Task<List<string>> FetchClientFromApiAsync(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JArray jsonArray = JArray.Parse(responseBody);

                List<string> items = jsonArray.Select(item => item["ClientCode"].ToString()).ToList();
                return items;
            }
        }

        private void btn1_Save_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into vendor values('" + comboBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox10.Text + "','" + comboBox3.Text + "','" + textBox9.Text + "','" + comboBox2.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + dateTimePicker1.Value.Date + "')", conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("New Data Submitted!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("New Data Not Submitted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update Data
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update View_Vendor set Vendorname='" + textBox1.Text + "',VendorType='" + textBox2.Text + "'Address1='" + textBox3.Text + "',Address2='" + textBox4.Text + "',Address3=" + textBox5.Text + "',Address4='" + textBox6.Text + "',Country='" + comboBox2.Text + "',State='" + comboBox3.Text + "',Zip='" + textBox9.Text + "',City='" + textBox10.Text + "',Shipvia='" + textBox11.Text + "',PaymentTerms='" + textBox12.Text + "',AccountNo='" + textBox13.Text + "',VendorCost='" + textBox14.Text + "',TimeCreated='" + dateTimePicker1.Value.Date + "', where CustomerId='" + comboBox1.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Update!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Data Not Update!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Search Data
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Vendor where CustomerId='" + comboBox1.Text + "'", conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Vendor");
              
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //conn.Open();
            SqlCommand cmd = new SqlCommand("select * from vendor where ClientCode='" + comboBox1.Text + "'", conn);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    textBox1.Text = dt.Rows[i]["vendorName"].ToString();
                    textBox2.Text = dt.Rows[i]["VendorType"].ToString();
                    textBox3.Text = dt.Rows[i]["Address1"].ToString();
                    textBox4.Text = dt.Rows[i]["Address2"].ToString();
                    textBox5.Text = dt.Rows[i]["Address3"].ToString();
                    textBox6.Text = dt.Rows[i]["Address4"].ToString();
                    comboBox2.Text = dt.Rows[i]["Country"].ToString();
                    comboBox3.Text = dt.Rows[i]["State"].ToString();
                    textBox9.Text = dt.Rows[i]["Zip"].ToString();
                    textBox10.Text = dt.Rows[i]["City"].ToString();
                    textBox11.Text = dt.Rows[i]["Shipvia"].ToString();
                    textBox12.Text = dt.Rows[i]["PaymentTerms"].ToString();
                    textBox13.Text = dt.Rows[i]["AccountNo"].ToString();
                    textBox14.Text = dt.Rows[i]["VendorCost"].ToString();
                    dateTimePicker1.Text = dt.Rows[i]["TimeCreated"].ToString();
                }
            }
            conn.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cost_Template cost_Template = new Cost_Template();
           
            cost_Template.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cost_Template cost_Template = new Cost_Template();
            
            cost_Template.Show();
        }
        public async void LoadCountry()
        {
            string apiUrl = "http://localhost:82/api/Country/GetAllCountry";

            try
            {
                List<string> data = await FetchDataFromApiAsync(apiUrl);
                comboBox2.DataSource = data;
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete vendor where ClientCode='"+comboBox1.Text+"'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Deleted");
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Network Issue");
            }
        }
        public async void Load_State()
        {

            string apiUrl = "http://localhost:82/api/State/GetStateName?Country_Name='" + comboBox2.Text + "'";

            try
            {
                List<string> data = await FetchStateFromApiAsync(apiUrl);
                comboBox3.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
        }
        public async Task<List<string>> FetchStateFromApiAsync(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JArray jsonArray = JArray.Parse(responseBody);

                List<string> items = jsonArray.Select(item => item["State_Name"].ToString()).ToList();
                return items;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select State_Name from tbl_State where Country_Name='" +comboBox2.Text + "' ", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox3.DisplayMember = "State_Name";
            comboBox3.DataSource = dt;
            conn.Close();
        }
    }
}
