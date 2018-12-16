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
            if (k > 1) return true;
            else return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //IsEnough();
            bool goingOn = true;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox && Int32.TryParse(c.Text, out int f))
                {
                    p.Add(f);
                }
                else if(c is TextBox)
                {
                    MessageBox.Show("Не все значения заполнены, исправьте это", "Так нельзя", MessageBoxButtons.OK);
                    goingOn = false;
                    p.Clear();
                    break;
                }
            }
            if (goingOn)
            {
                AskUser adt = new AskUser(this);
                for (int i=0; i<q.Count-1; i++)
                {
                    for(int j=i+1; j<q.Count; j++)
                    {
                        Label l = new Label();
                        TextBox t = new TextBox();                        
                        int x = 12;                        
                        int y = 10;                        
                        t.Size = new System.Drawing.Size(80, 16);
                        while (GetChildAtPoint(new Point(x + 5, y + 2)) is TextBox)
                        {
                            y += 67;                            
                        }
                        l.Text = q[i]+" и "+q[j];
                        l.Font = new Font("Tahoma", 12);
                        l.AutoSize = true;
                        l.Location = new Point(x, y);
                        t.Location = new Point(x, y+20);                        
                        adt.Controls.Add(l);
                        adt.Controls.Add(t);
                    }
                }
                adt.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataInput f = new DataInput(this);           
            f.Show();
            if (IsEnough()) button2.Enabled = true;            
        }

        public List<string> q = new List<string>();
        public List<int> p = new List<int>();

        public int IncMis(List<int> pows, int cnt)
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
                i++;
            }
            return res;
        }
    }
}
