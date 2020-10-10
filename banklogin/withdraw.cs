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
    public partial class withdraw : Form
    {
        public withdraw(String id)
        {
            InitializeComponent();
            txteid.Text = id;
        }
        public void transid()
        {
            con.Open();
            String syntax = "Select max(transid) from transact";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                String val = dr[0].ToString();
                if (val == "")
                {
                    txttransid.Text = "2345678";
                }
                else
                {
                    int a;
                    a = int.Parse(dr[0].ToString());
                    a = a + 1;
                    txttransid.Text = a.ToString();

                }
                con.Close();
            }
            //con.Close();
        }

            private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        private void withdraw_Load(object sender, EventArgs e)
        {
            transid();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            // int a = Convert.ToInt32(id);
            String syntax = "Select * from accounts  where accid='" + txtaccid.Text + "'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtcustid.Text = dr[3].ToString();
                txtbal.Text = dr[2].ToString();
            }
            con.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            String accid, transid, custid, empid, date;
            double balance, amount;
            accid = txtaccid.Text;
            transid = txttransid.Text;
            custid = txtcustid.Text;
            empid = txteid.Text;
            date = txtdate.Text;
            balance = double.Parse(txtbal.Text);
            amount = double.Parse(txtamt.Text);
            String type = "withdraw";
            double a= double.Parse(txtbal.Text)- double.Parse(txtamt.Text);
            String bal = a.ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trans;
            trans = con.BeginTransaction();
            cmd.Connection = con;
            cmd.Transaction = trans;

            try
            {
                cmd.CommandText = "insert into transact(transid,custid,accid,eid,typeoftrans,amount,date) values('" + transid + "', '" + custid + "','" + accid + "', '" + empid + "', '" + type + "', '" + amount + "', '" + date + "')";
                cmd.ExecuteNonQuery();


                cmd.CommandText = "update accounts set balance='"+bal+"' where accid='" + accid + "'";
                cmd.ExecuteNonQuery();
                trans.Commit();

                MessageBox.Show("Transaction  Successfully.........");


            }


            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally { con.Close(); };


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
