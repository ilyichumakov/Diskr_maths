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

        private void button2_Click(object sender, EventArgs e)
        {
            q.Clear();
            //int p = 1;
            foreach (Control z in this.Controls)
            {
                if (z is Panel)
                {
                    foreach (Control c in z.Controls)
                    {
                        if (c is TextBox && c.Visible==true && Int32.TryParse(c.Text, out int f))
                        {
                            Control lb = z.Controls.Find("label" + (Int32.Parse(c.Name.Substring(7))+1).ToString(), true)[0];
                            q.Add(new Hash(lb.Text.Length, f));
                            //p++;
                        }
                        else if (c is TextBox && c.Visible == true)
                        {
                            MessageBox.Show("Не все значения заполнены, исправьте это", "Так нельзя", MessageBoxButtons.OK);
                            break;
                        }
                    }
                }                
            }
            IndexComparer comp = new IndexComparer();
            q.Sort(comp);
            MessageBox.Show("Мощность объединенных множеств "+IncMis(q, Int32.Parse(comboBox1.SelectedItem.ToString())), "Результат", MessageBoxButtons.OK);
        }

        private List<Hash> q = new List<Hash>();

        private int IncMis(List<Hash> pows, int cnt)
        {
            int res = 0;
            int i = 0;
            int addit = -1;
            for (int j = 1; j < cnt + 1; j++)
            {
                int c = 0;
                addit *= -1;
                while(c<Combinations(cnt, j))
                {
                    res += addit * pows[i].value;
                    i++;
                    c++;
                }
            }
            /*while (i < cnt)
            {
                res += pows[i];
                i++;
            }
            while (i < pows.Count)
            {
                res -= pows[i];
            }*/
            return res;
        }

        private int Factorial(int n)
        {
            int res = 1;
            int i = 1;
            if (n > 1)
            {
                while (i <= n)
                {
                    res *= i;
                    i++;
                }
            }
            return res;
        }

        private int Combinations(int n, int k)
        {
            return (int)Factorial(n) / Factorial(k) / Factorial(n - k);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            comboBox1.Items.Add("5");
            comboBox1.SelectedItem = comboBox1.Items[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == comboBox1.Items[0])
            {
                foreach(Control z in this.Controls)
                {
                    if (z is Panel)
                    {
                        foreach (Control r in z.Controls)
                        {
                            if (r is Label && Int32.Parse(r.Name.Substring(5)) > 4 ||
                            r is TextBox && Int32.Parse(r.Name.Substring(7)) > 3)
                            {
                                r.Visible = false;
                            }
                        }
                    }
                }
            }
            else if (comboBox1.SelectedItem == comboBox1.Items[1])
            {
                foreach (Control z in this.Controls)
                {
                    if (z is Panel)
                    {
                        foreach (Control r in z.Controls)
                        {
                            if (r is Label && Int32.Parse(r.Name.Substring(5)) > 8 ||
                        r is TextBox && Int32.Parse(r.Name.Substring(7)) > 7)
                            {
                                r.Visible = false;
                            }
                            else
                            {
                                r.Visible = true;
                            }
                        }
                    }
                }
            }
            else if (comboBox1.SelectedItem == comboBox1.Items[2])
            {
                foreach (Control z in this.Controls)
                {
                    if (z is Panel)
                    {
                        foreach (Control r in z.Controls)
                        {
                            if (r is Label && Int32.Parse(r.Name.Substring(5)) > 16 ||
                        r is TextBox && Int32.Parse(r.Name.Substring(7)) > 15)
                            {
                                r.Visible = false;
                            }
                            else
                            {
                                r.Visible = true;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (Control z in this.Controls)
                {
                    if (z is Panel)
                    {
                        foreach (Control r in z.Controls)
                        {                           
                            r.Visible = true;                           
                        }
                    }
                }
            }
        }
    }
}
