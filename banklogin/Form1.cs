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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string MyValue
        {
            get { return txtemppass.Text; }
        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private String getempname()
        {
            con.Open();
            String syntax = "Select ename from employee";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String temp=null;
              temp = dr[0].ToString();
                    
                   
                
            
            con.Close();
            return temp;
        }
        private String getempid()
        {
            con.Open();
            String syntax = "Select eid from employee";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String temp = null;
           
                    temp = dr[0].ToString();
                   
                
            
            con.Close();
            return temp;
        }
        private void button1_Click(object sender, EventArgs e)
        {

             String username= getempname(), password=getempid();
            // int n = username.Length;
             
             String name = txtempname.Text;
             String pass = txtemppass.Text;
            String id= txtemppass.Text;
            // for (int i = 0; i < n; i++)
            //{

            if (username == name && password == pass)
                {
                     //emplab.Text = "login succes";
                     progress p = new progress(2,id);
                     this.Hide();
                     p.Show();
                     
                 }
                 else
                 {
                     emplab.Text = "INVALID USERNAME AND PASSWORD";
                 }
             }
          /*  String username, password;
            username = txtempname.Text;
            password = txtemppass.Text;
            if (username == "bank" && password == "bank")
            {
                //userlab.Text = "login succes";
                progress p = new progress(2);
                this.Hide();
                p.Show();
            }
            else
                emplab.Text = "INVALID USERNAME AND PASSWORD";*/
        
    private String getusername()
    {
        con.Open();
        String syntax = "Select fname from customer";
        cmd = new SqlCommand(syntax, con);
        dr = cmd.ExecuteReader();
            dr.Read();
            String temp = null;
        temp = dr[0].ToString();




        con.Close();
        return temp;
    }
    private String getuserid()
    {
        con.Open();
        String syntax = "Select custid from customer";
        cmd = new SqlCommand(syntax, con);
        dr = cmd.ExecuteReader();
        
            dr.Read();
            String temp = null;

        temp = dr[0].ToString();



        con.Close();
        return temp;
     }
    private void btnuser_Click(object sender, EventArgs e)
        {
            String username= getusername(), password= getuserid();
           String name = txtusername.Text;
          String  pass = txtuserpass.Text;
            String id= txtuserpass.Text;
            if (username == name && password == pass)
            {
                //userlab.Text = "login succes";
                progress p = new progress(1,id);
                this.Hide();
                p.Show();
            }
            else
                userlab.Text = "INVALID USERNAME AND PASSWORD";
        }
    }
}
