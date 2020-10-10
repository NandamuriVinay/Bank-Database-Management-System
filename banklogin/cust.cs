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
    public partial class cust : Form
    {
        //String id;
        public cust(String id)
        { 
            InitializeComponent();
            custidl.Text = id;

        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;


        public void getuser()
        {

            con.Open();

            String syntax = "Select * from customer c,branch b where c.bid=b.bid and custid='" + custidl.Text + "'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                custidl.Text = dr[0].ToString();
                fnamel.Text = dr[1].ToString();
                lnamel.Text = dr[2].ToString();
                genl.Text = dr[3].ToString();
                uidl.Text = dr[4].ToString();
                phnol.Text = dr[5].ToString();
                addl.Text = dr[6].ToString();
                dobl.Text = dr[7].ToString();
                bidl.Text= dr[8].ToString();
                bnamel.Text = dr[10].ToString();
            }
            con.Close();

        }

        private void cust_Load(object sender, EventArgs e)
        {
            getuser();
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }
    }
}
