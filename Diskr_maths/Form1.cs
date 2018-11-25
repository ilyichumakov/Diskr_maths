using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diskr_maths
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool IsEnough()
        {
            int k = 0;
            if (Form1.ActiveForm.Controls.Count > 0)
            {                
                foreach (Control a in Form1.ActiveForm.Controls)
                {
                    //MessageBox.Show(a.GetType().ToString());
                    if(a is Label)
                    {
                        k++;
                    }
                }
            }
            if (k > 1) return true;
            else return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IsEnough();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label a = new Label();
            a.Text = "New";
            int x = 10;
            int y = 10;
            while (GetChildAtPoint( new Point(x,y)) is Label)
            {
                y += 15;
            }
            a.Location = new Point(x, y);
            Form1.ActiveForm.Controls.Add(a);            
            if(IsEnough()) button2.Enabled = true;
        }
    }
}
