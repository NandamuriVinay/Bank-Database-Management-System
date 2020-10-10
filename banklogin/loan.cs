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

namespace banklogin
{
    public partial class loan : Form
    {
       // String id;
        public loan(String id)
        {
            InitializeComponent();
            txteid.Text = id;
        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void loanid()
        {
            con.Open();
            String syntax = "Select max(loanid) from loan";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                String val = dr[0].ToString();
                if (val == "")
                {
                    txtloan.Text = "45678";
                }
                else
                {
                    int a;
                    a = int.Parse(dr[0].ToString());
                    a = a + 1;
                    txtloan.Text = a.ToString();

                }
                con.Close();
            }
            //con.Close();
        }

            private void loan_Load(object sender, EventArgs e)
        {
            loanid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            // int a = Convert.ToInt32(id);
            String syntax = "Select * from accounts a,loan l  where a.accid='" + txtacc.Text + "' and a.accid=l.accid";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtcust.Text = dr[3].ToString();
                MessageBox.Show("LOAN DENIED");
            }
            else
            {
                
                MessageBox.Show("LOAN POSSIBLE");
            }
            con.Close();
            con.Open(); 

            String syntax1= "Select * from accounts   where accid='" + txtacc.Text + "'";
            cmd = new SqlCommand(syntax1, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtcust.Text = dr[3].ToString();
            }
                con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
    }
