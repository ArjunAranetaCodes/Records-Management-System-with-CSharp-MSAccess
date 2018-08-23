using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CSharpAccessRecordSys
{
    public partial class Form1 : Form
    {
        OleDbConnection conn = new OleDbConnection();
        string dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;";
        string dbSource = "Data Source=D:\\AccessDB\\db_csrecordsys.mdb;";
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = dbProvider + dbSource;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox4.Text == textBox5.Text){
                ds = new DataSet();
                adapter = new OleDbDataAdapter("insert into [tbl_accounts] ([username], [password], [privilege]) VALUES " +
                 "('" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')", conn);
                adapter.Fill(ds, "tbl_accounts");
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                comboBox1.Text = "";
                MessageBox.Show("User Registered!");
            }else{
                MessageBox.Show("Passwords do not match!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter = new OleDbDataAdapter("select * from [tbl_accounts] where username = '" + textBox1.Text +
                "' and password = '" + textBox2.Text + "'", conn);
            adapter.Fill(ds, "tbl_accounts");

            if (ds.Tables["tbl_accounts"].Rows.Count > 0)
            {
                Form2 frm = new Form2();
                frm.Show();
                MessageBox.Show("Login Successful!");
            }
            else
            {
                MessageBox.Show("Invalid username and password!");
            }
        }
    }
}
