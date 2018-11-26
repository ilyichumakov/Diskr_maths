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
    public partial class DataInput : Form
    {
        public DataInput()
        {
            InitializeComponent();
        }

        public DataInput(Form1 MainF)
        {
            InitializeComponent();
            There = MainF;
        }

        private Form1 There;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!IsEmptyInput()) {
                Label l = new Label();
                TextBox t = new TextBox();
                t.Multiline = true;
                int x = 12;
                int xt = 157;
                int y = 135;
                int k = 1;
                t.Size = new System.Drawing.Size(141, 56);
                while (GetChildAtPoint(new Point(xt + 5, y + 2)) is TextBox)
                {
                    y += 67;
                    k++;
                }
                l.Text = "Вариант ответа " + k.ToString();
                l.Font = new Font("Tahoma", 12);
                l.AutoSize = true;
                l.Location = new Point(x, y + 19);
                t.Location = new Point(xt, y);
                t.TextChanged += new System.EventHandler(textBox1_TextChanged);
                DataInput.ActiveForm.Controls.Add(l);
                DataInput.ActiveForm.Controls.Add(t);
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label a = new Label();
            TextBox t = new TextBox();
            a.Text = textBox2.Text;
            a.BackColor = Color.Transparent;
            a.AutoSize = true;
            t.Font = new Font("Tahoma", 12);
            t.Size = new System.Drawing.Size(200, 18);
            int x = 10;
            int y = 10;
            while (There.GetChildAtPoint(new Point(x, y)) is Label)
            {
                y += 50;
            }
            a.Location = new Point(x, y);
            t.Location = new Point(x, y + 17);
            /*Form1.ActiveForm.Controls.Add(a);
            Form1.ActiveForm.Controls.Add(t);*/
            /*DataInput.ActiveForm.ParentForm.Controls.Add(a);
            DataInput.ActiveForm.ParentForm.Controls.Add(t);*/
            There.Controls.Add(a);
            There.Controls.Add(t);
        }

        private void DataInput_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Да/нет");
            comboBox1.Items.Add("Один вариант ответа");
            comboBox1.Items.Add("Несколько вариантов ответа");
            comboBox1.SelectedItem = comboBox1.Items[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(comboBox1.SelectedItem == comboBox1.Items[0]))
            {
                label2.Visible = true;
                textBox1.Visible = true;
            }
            else
            {
                label2.Visible = false;
                textBox1.Visible = false;
            }
        }

        private bool IsEmptyInput()
        {
            if (Form1.ActiveForm.Controls.Count > 0)
            {
                foreach (Control a in DataInput.ActiveForm.Controls)
                {
                    //MessageBox.Show(a.GetType().ToString());
                    if (a is TextBox)
                    {
                        if (a.Text == "") return true;
                    }
                }
                return false;
            }
            else return false;
        }
    }
}
