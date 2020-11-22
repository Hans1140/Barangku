using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace barangku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create connection with database
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=O:\Games\Tugas\loginformDB.accdb");
            //create data adapter
            OleDbDataAdapter da = new OleDbDataAdapter("select count(*) from Table1 where Username='"+txtusername.Text +"' and Password ='"+txtpassword.Text +"' ", con);
            //create datatable
            DataTable dt = new DataTable();
            //fill datatable
            da.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                //means the username and password is correct 
                Form2 f2 = new Form2();
                f2.Show();
            }
            else
            {
                //means the username and password is incorrect
                MessageBox.Show("invalid username or password");
            }
        }
    }
}
