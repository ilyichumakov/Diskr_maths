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
                    if(a is Label)
                    {
                        k++;
                    }
                }
            }
            if (k > 2) return true;
            else return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //IsEnough();
            foreach(Control c in this.Controls)
            {
                if(c is TextBox && Int32.TryParse(c.Text, out int f))
                {
                    continue;
                }
                else
                {
                    MessageBox.Show("Не все значения заполнены, исправьте это", "Так нельзя", MessageBoxButtons.OK);
                    break;
                }
            }
        }

        public List<string> q = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            DataInput f = new DataInput(this);           
            f.Show();
            if (IsEnough()) button2.Enabled = true;            
        }

        private int IncMis(List<int> pows, int cnt)
        {
            int res = 0;
            int i = 0;
            while (i < cnt)
            {
                res += pows[i];
                i++;
            }
            while (i < pows.Count)
            {
                res -= pows[i];
            }
            return res;
        }

    }
}
