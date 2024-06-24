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

namespace CSharp_QLTT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAB1-MAY14\\MISASME2022;initial catalog=QLTT;Integrated security=True");
        private void openCon() 
        {
            if (con.State==ConnectionState.Closed) 
            { 
                con.Open();
            }
        }
        private void closeCon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        private Boolean Exe(string cmd) 
        {
            openCon();
            Boolean check;
            try 
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception) 
            {       
                check = false;
                throw;
            }

            closeCon();
            return check;
        }
        private DataTable Red(String cmd) 
        {
            openCon();
            DataTable dt = new DataTable();
            try 
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);
            }
            catch (Exception) 
            {
                dt = null;
                throw;
            }
            closeCon();
            return dt;
        }
        private void load()
        {
            DataTable dt = Red("Select * from QLTT");
            if (dt != null) 
            {
                dataGridView1.DataSource = dt;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
