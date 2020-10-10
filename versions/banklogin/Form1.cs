using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace banklogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, password;
            username = txtempname.Text;
            password = txtemppass.Text;
            if (username == "bank" && password == "bank")
            {
                //emplab.Text = "login succes";
                progress p = new progress(2);
                this.Hide();
                p.Show();
            }
            else
                emplab.Text = "INVALID USERNAME AND PASSWORD";
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            String username, password;
            username = txtusername.Text;
            password = txtuserpass.Text;
            if (username == "bank" && password == "bank")
            {
                //userlab.Text = "login succes";
                progress p = new progress(1);
                this.Hide();
                p.Show();
            }
            else
                userlab.Text = "INVALID USERNAME AND PASSWORD";
        }
    }
}
