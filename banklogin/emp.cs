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
    public partial class emp : Form
    {
        String id;
        public emp(String id)
        {
           
            InitializeComponent();
            txteid.Text = id;
            this.id = id;
        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            newacc s = new newacc();
            s.Show();
            


        }

        private void btnwith_Click(object sender, EventArgs e)
        {
            withdraw w = new withdraw(id);
            w.Show();
        }

        private void btndep_Click(object sender, EventArgs e)
        {
            deposit d = new deposit(id);
            d.Show();
                
        }

        private void btnloan_Click(object sender, EventArgs e)
        {
            loan l = new loan(id);
            l.Show();

        }

        private void btntransfer_Click(object sender, EventArgs e)
        {
            withdraw w = new withdraw(id);
            deposit d = new deposit(id);
           
            d.Show();
            w.Show();



        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            getemp();
        }
        public void getemp()
        {
          
            con.Open();
            
            String syntax = "Select * from employee e,branch b where e.bid=b.bid and eid='"+ txteid.Text + "'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txteid.Text = dr[0].ToString();
                enamel.Text = dr[1].ToString();
                salal.Text = dr[2].ToString();
                phnol.Text = dr[3].ToString();
                genl.Text = dr[4].ToString();
                desigl.Text = dr[5].ToString();
                bidl.Text = dr[6].ToString();
                txtbname.Text = dr[8].ToString();
            }
            con.Close();

        }

        private void emp_Load(object sender, EventArgs e)
        {
            getemp();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }
    }
}
