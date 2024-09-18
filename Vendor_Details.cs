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

namespace WindowsFormsApp1
{
    public partial class Vendor_Details : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=ashutosh;Initial Catalog=ERP_Project;Persist Security Info=True;User ID=sa;password=cellhut*321;");
        public Vendor_Details()
        {
            InitializeComponent();
        }

        private void Vendor_Details_Load(object sender, EventArgs e)
        {
            Load_VendorData();
        }
        public void Load_VendorData()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from View_Vendor", conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "View_Vendor");
                dataGridView1.DataSource = ds.Tables["View_Vendor"].DefaultView;
                conn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Data Not Found!!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
