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
namespace WindowsFormsApp1
{
    public partial class State : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=ashutosh;Initial Catalog=ERP_Project;Persist Security Info=True;User ID=sa;password=cellhut*321;");
        public State()
        {
            InitializeComponent();
        }

        private void State_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 2; i++)
            {
                com_Active.Items.Add(i.ToString());
            }
            com_StateCode.Enabled = false;
            Country_Code();
            State_Code();
        }

        private void btn_NewData_Click(object sender, EventArgs e)
        {
            com_StateCode.Text = "";
            comboBox1.Text = "";
            txt_TimeZone.Text = "";
            com_Active.Text = "";
            com_CountryCode.Text = "";
        }

        private void btn_AddData_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into tbl_State values('" + comboBox1.Text + "','" + txt_TimeZone.Text + "','" + com_Active.Text + "','" + com_CountryCode.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Submmitted!!!");
                conn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Data Not Submitted!!!!");
            }
        }

        private void com_StateCode_SelectedIndexChanged(object sender, EventArgs e)
        {
           // conn.Open();
            SqlCommand cmd = new SqlCommand("select State_Name from tbl_State", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox1.DisplayMember = "State_Name";
            comboBox1.DataSource = dt;
            conn.Close();
        }
        public void Country_Code()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Country_Name from Country", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            com_CountryCode.DisplayMember = "Country_Name";
            com_CountryCode.DataSource = dt;
            conn.Close();
        }
        public void State_Code()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select StateCode from tbl_State", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            com_StateCode.DisplayMember = "StateCode";
            com_StateCode.DataSource = dt;
            conn.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                com_StateCode.Enabled = true;
            }
            else
            {
                com_StateCode.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                com_StateCode.Enabled = true;
            }
            else
            { com_StateCode.Enabled = false;
            }
        }
    }
}
