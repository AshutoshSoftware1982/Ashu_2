using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Update_Password : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=ashutosh;Initial Catalog=ERP_Project;Persist Security Info=True;User ID=sa;password=cellhut*321;");
        public Update_Password()
        {
            InitializeComponent();
        }

        private void Update_Password_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select UPassword from New_User Where UPassword = '" + txt_OlePassword.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count.ToString() == "1")
            {
                if (txt_NewPassword.Text == txt_ReTypepassword.Text)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE New_User SET UPassword = '" + txt_NewPassword.Text + "',UCPassword='" + txt_ReTypepassword.Text + "' where UPassword = '" + txt_OlePassword.Text + "'", conn);


                    cmd.ExecuteNonQuery();
                    conn.Close();
                    label4.ForeColor = System.Drawing.Color.Green;
                    label4.Text = "Your Password Is Successfully Updated….";
                    txt_OlePassword.Text = "";
                    txt_NewPassword.Text = "";
                    txt_ReTypepassword.Text = "";
                }

            }
        }
    }
}
