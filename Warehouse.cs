using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace WindowsFormsApp1
{
    public partial class Warehouse : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=ashutosh;Initial Catalog=ERP_Project;Persist Security Info=True;User ID=sa;password=cellhut*321;");
        public Warehouse()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Warehouse_Load(object sender, EventArgs e)
        {
            LoadData();
            Pick_Type();
            GetClient_Code();
            //Country_Name();
            Alloc_Inv();
            //State_Name();
            com_WarehouseID.Enabled = false;
            LoadCountry();
            Load_State();
        }
        public void LoadData()
        {

            try
            {
                //IEnumerable<ProviderModel> empobj = null;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("http://localhost:82/api/Warehouse/GetAllWarehouse");
                var consumeapi = hc.GetAsync("GetAllWarehouse");
                consumeapi.Wait();
                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    IList<WarehouseModel> MyDeserialisedObject =
                    JsonConvert.DeserializeObject<List<WarehouseModel>>(readdata.Content.ReadAsStringAsync().Result.ToString()).Cast<WarehouseModel>().ToList();
                    dataGridView1.DataSource = MyDeserialisedObject;
                    label5.Visible = false;

                    

                }
            }
            catch (Exception)
            {

                label5.Text = "Please check API";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void Pick_Type()
        {
            string[] pick_type = { "PP", "DC" };
            for (int i = 0; i < pick_type.Length; i++)
            {
                com_PickType.Items.Add(pick_type[i]);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_Warehouse.Text == string.Empty || com_Country.Text == string.Empty || com_State.Text == string.Empty)
            {
                MessageBox.Show("Please Fill All Fileds", "Done", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_Warehouse.Text == string.Empty || com_Country.Text == string.Empty || com_State.Text == string.Empty)
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Warehouse values('" + txt_WheseName.Text + "','" + txt_Address1.Text + "','" + txt_Address2.Text + "','" + com_Country.Text + "','" + com_State.Text + "','" + txt_Contact.Text + "','" + txt_Email.Text + "','" + com_PickType.Text + "','" + txt_Divison.Text + "','" + com_NotAllocInv.Text + "','" + txt_CloseMainfest.Text + "','" + txt_Whs.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New Data Submitted!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    LoadData();
                    //ResetData();
                    this.Hide();
                    //page reload
                    var War = new Warehouse();
                    War.Closed += (s, args) => this.Close();
                    War.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("New Data Not Submitted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void GetClient_Code()
        {
            SqlCommand cmd = new SqlCommand("select CustomerID from Customer", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            com_WarehouseID.DisplayMember = "CustomerID";
            com_WarehouseID.DataSource = dt;
            conn.Close();
        }

        public void Alloc_Inv()
        {
            string[] Inv = { "Y", "P", "N" };
            for (int i = 0; i < Inv.Length; i++)
            {
                com_NotAllocInv.Items.Add(Inv[i]);
            }
        }
        
        public async void LoadCountry()
        {
            string apiUrl = "http://localhost:82/api/Country/GetAllCountry";

            try
            {
                List<string> data = await FetchDataFromApiAsync(apiUrl);
                com_Country.DataSource = data;
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

       
        public async void Load_State()
        {

            string apiUrl = "http://localhost:82/api/State/GetStateName?Country_Name='" + com_Country.Text + "'";

            try
            {
                List<string> data = await FetchStateFromApiAsync(apiUrl);
                com_State.DataSource = data;
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

        private void com_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
           // conn.Open();
            SqlCommand cmd = new SqlCommand("select State_Name from tbl_State where Country_Name='" + com_Country.Text + "'", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            com_State.DisplayMember = "State_Name";
            com_State.DataSource = dt;
            conn.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                com_WarehouseID.Enabled = true;
            }
            else
            {
                com_WarehouseID.Enabled = false;
                Reset_Data();
            }
        }

        private void com_WarehouseID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Warehouse where WarehouseID='" + com_WarehouseID.Text + "'", conn);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //txt_Warehouse.Text = dt.Rows[i]["Warehouse"].ToString();
                    txt_WheseName.Text = dt.Rows[i]["WarehouseName"].ToString();
                    txt_Address1.Text = dt.Rows[i]["Address1"].ToString();
                    txt_Address2.Text = dt.Rows[i]["Address2"].ToString();
                    com_Country.Text = dt.Rows[i]["Country"].ToString();
                    com_State.Text = dt.Rows[i]["State"].ToString();
                    txt_Contact.Text = dt.Rows[i]["Contact"].ToString();
                    txt_Email.Text = dt.Rows[i]["Contact_Email"].ToString();
                    com_PickType.Text = dt.Rows[i]["Pick_Type"].ToString();
                    txt_Divison.Text = dt.Rows[i]["Divison"].ToString();
                    com_NotAllocInv.Text = dt.Rows[i]["Not_Alloc_Inv"].ToString();
                    txt_CloseMainfest.Text = dt.Rows[i]["Close_Mainfest"].ToString();
                    txt_Whs.Text = dt.Rows[i]["Whs_Group"].ToString();

                }
            }
            conn.Close();
        }
        public void Reset_Data()
        {
            txt_WheseName.Text = "";
            txt_Address1.Text = "";
            txt_Address2.Text = "";
            com_Country.Text = "";
            com_State.Text = "";
            txt_Contact.Text = "";
            txt_Email.Text = "";
            com_PickType.Text = "";
            txt_Divison.Text = "";
            com_NotAllocInv.Text = "";
            txt_CloseMainfest.Text = "";
            txt_Whs.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Warehouse set WarehouseName='" + txt_WheseName.Text + "',Address1='" + txt_Address1.Text + "',Address2='" + txt_Address2.Text + "',Country='" + com_Country.Text + "',State='" + com_State.Text + "',Contact='" + txt_Contact.Text + "',Contact_Email='" + txt_Email.Text + "',Pick_Type='" + com_PickType.Text + "',Divison='" + txt_Divison.Text + "',Not_Alloc_Inv='" + com_NotAllocInv.Text + "',Close_Mainfest='" + txt_CloseMainfest.Text + "',Whs_Group='" + txt_Whs.Text + "' where WarehouseID='" + com_WarehouseID.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Update");
                conn.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("network Issue");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Warehouse where WarehouseID='" + com_WarehouseID.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Deleted Successfully.");
                conn.Close();
                Reset_Data();
            }
            catch (Exception)
            {
                MessageBox.Show("Network Issue");
            }
        }
    }
}
