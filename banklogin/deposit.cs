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
    public partial class deposit : Form
    {
        public deposit(String id)
        {
            InitializeComponent();
            txtempid.Text = id;
        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
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

            private void deposit_Load(object sender, EventArgs e)
        {
            transid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
           // int a = Convert.ToInt32(id);
            String syntax = "Select * from accounts  where accid='" + txtacc.Text + "'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtcustid.Text = dr[3].ToString();
                txtbal.Text = dr[2].ToString();
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
                
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            String accid, transid, custid, empid, date;
            double balance, amount;
            accid = txtacc.Text;
            transid = txttransid.Text;
            custid = txtcustid.Text;
            empid = txtempid.Text;
            date = txtdate.Text;
            balance = double.Parse(txtbal.Text);
            amount = double.Parse(txtamt.Text);
            String type = "deposit";
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


                cmd.CommandText = "update accounts set balance=balance+'" + amount + "' where accid='" + accid + "'";
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
    }
}
