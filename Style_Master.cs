using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace WindowsFormsApp1
{
    public partial class Style_Master : Form
    {
        public Style_Master()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Size_Range size_Range = new Size_Range();
            size_Range.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Style_Calender style_Calender = new Style_Calender();
            style_Calender.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Session session = new Session();
            session.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data has been changed. Please either save or undo the changes.");
        }

        private void txt_ClientID_DoubleClick(object sender, EventArgs e)
        {
            Client_Code client_Code = new Client_Code();
            client_Code.Show();
            //SetValueForText1 = txt_ClientID.Text;
        }

        private void txt_DivisionCode_DoubleClick(object sender, EventArgs e)
        {
            Division_Code division_Code = new Division_Code();
            division_Code.Show();
            //SetValueForText2 = txt_DivisionCode.Text;
        }

        private void txt_SizeRange_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_SizeRange_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Size_RangeData1 size_RangeData = new Size_RangeData1();
            size_RangeData.Show();
        }

        private void txt_Content_DoubleClick(object sender, EventArgs e)
        {
            Content_Data content_Data = new Content_Data();
            content_Data.Show();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Style_Master_Load(object sender, EventArgs e)
        {
            string[] CRN = { "C", "R", "N" };
            for (int i = 0; i < CRN.Length; i++)
            {
                comboBox1.Items.Add(CRN[i]);
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void link_merchC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
