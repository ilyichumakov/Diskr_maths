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
            foreach (Control z in this.Controls)
            {
                if (z is Panel)
                {
                    foreach (Control c in z.Controls)
                    {
                        if (c is TextBox && c.Visible==true && Int32.TryParse(c.Text, out int f))
                        {
                            q.Add(f);
                        }
                        else
                        {
                            MessageBox.Show("Не все значения заполнены, исправьте это", "Так нельзя", MessageBoxButtons.OK);
                            break;
                        }
                    }
                }                
            }
            MessageBox.Show("Мощность объединенных множеств "+IncMis(q, Int32.Parse(comboBox1.SelectedItem.ToString())), "Результат", MessageBoxButtons.OK);
        }

       public List<int> q = new List<int>();


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
