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
    public partial class progress : Form
    { int i;
        public progress(int i)
        {
            this.i = i;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int a = i;
            progressBar1.Value = progressBar1.Value + 1;
            if(progressBar1.Value>=99 && a==1)
            {
                cust c = new cust();
                this.Hide();
                c.Show();
                
                timer1.Enabled = false;
                progressBar1.Value = progressBar1.Value - 1;
            }
            if (progressBar1.Value >= 99 && a == 2)
            {
                emp m = new emp();
                this.Hide();
                m.Show();

                timer1.Enabled = false;
                progressBar1.Value = progressBar1.Value - 1;
            }


        }
    }
}
