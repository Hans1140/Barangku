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
    public partial class Form2 : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=O:\Games\Tugas\crudDB.accdb");
        public Form2()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("insert into PersonTbl (Nama,JenisBarang)values('" + txtNama.Text + "','" + txtJenis.Text + "' )", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record saved...");

            fillgrid();
        }

        void fillgrid()
        {
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from PersonTbl order by ID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("Update PersonTbl set Nama= '" + txtNama.Text + "',JenisBarang='" + txtJenis.Text + "' where ID="+txtID.Text+" ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated...");

            fillgrid();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("Delete from PersonTbl where ID="+txtID.Text+" ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted...");

            fillgrid();
        }
    }
}
