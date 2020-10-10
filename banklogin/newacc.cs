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
    public partial class newacc : Form
    {
        public newacc()
        {
            InitializeComponent();
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
         SqlCommand cmd;
         SqlDataReader dr;
        public void custid()
        {
            con.Open();
            String syntax = "Select max(custid) from customer";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                String val = dr[0].ToString();
                if(val=="")
                {
                    txtcustid.Text = "10000";
                }
                else
                {
                    int a;
                    a = int.Parse(dr[0].ToString());
                    a = a + 1;
                    txtcustid.Text = a.ToString();

                }
                con.Close();
            }
            //con.Close();
        }
        public void accid()
        {
            con.Open();
            String syntax = "Select max(accid) from accounts";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                String val = dr[0].ToString();
                if (val == "")
                {
                    accl.Text = "100000";
                }
                else
                {
                    int a;
                    a = int.Parse(dr[0].ToString());
                    a = a + 1;
                    accl.Text = a.ToString();

                }
                con.Close();
            }
            
        }
       
        
















        private void newacc_Load(object sender, EventArgs e)
        {
            custid();
            accid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String custid, fname, lname, sex, add, phno, dob, uid, accid, acctype, bal,bid;
            custid = txtcustid.Text;
            fname = txtfname.Text;
            lname = txtlname.Text;
            sex = txtsex.Text;
            add = txtadd.Text;
            phno = txtphno.Text;
            dob = txtdob.Text;
            uid = txtuid.Text;
            accid = accl.Text;
            acctype = comacc.Text;
            bal = txtbal.Text;
            bid = txtbid.Text;
            // con.Open();
            
            try
            {
                con.Open();
                String syntax1 = "insert into customer(custid,fname,lname,sex,address,dob,phno,uid,bid) values('" + custid + "', '" + fname + "','" + lname + "', '" + sex + "', '" + add + "', '" + dob + "', '" + phno + "', '" + uid + "','" + bid + "')";
                //cmd.ExecuteNonQuery();
                SqlCommand  cmd = new SqlCommand(syntax1,con);
                //SqlTransaction trans;
                cmd.ExecuteNonQuery();
                // SqlTransaction trans;
              //  trans = con.BeginTransaction();
            cmd.Connection = con;
            //cmd.Transaction = trans;
                String syntax2 = "insert into accounts(accid,acctype,balance,bid,custid) values('" + accid + "','" + acctype + "','" + bal + "','" + bid + "','" + custid + "')";
                SqlCommand cm = new SqlCommand(syntax2, con);
                //SqlTransaction trans;
                cm.ExecuteNonQuery();
              //  trans = con.BeginTransaction();
                cm.Connection = con;
                //cm.Transaction = trans;

                //cmd.CommandText = "insert into customer(custid,fname,lname,sex,address,dob,phno,uid,bid) values('" + custid + "', '" + fname + "','" + lname + "', '" + sex + "', '" + add + "', '" + dob + "', '" + phno + "', '" + uid + "','" + bid + "')";
                //cmd.ExecuteNonQuery();


                // cmd.CommandText = "insert into accounts(accid,acctype,balance,bid,custid) values('" + accid + "','" + acctype + "','" + bal + "','" + bid + "','" + custid + "')";
                //cmd.ExecuteNonQuery();
                //trans.Commit();

                MessageBox.Show("Record added Successfully.........");


            }


            catch (Exception ex)
            {
                
                //trans.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally { con.Close(); }; 













        }

        private void accl_Click(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
