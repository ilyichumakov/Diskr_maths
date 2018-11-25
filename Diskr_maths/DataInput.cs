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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Label l = new Label();
            TextBox t = new TextBox();
            t.Multiline = true;            
            int x = 12;
            int xt = 157;
            int y = 90;
            int k = 1;
            t.Size = new System.Drawing.Size(141, 56);
            while (GetChildAtPoint(new Point(xt+5, y+2)) is TextBox)
            {
                y += 67;
                k++;
            }
            l.Text = "Вариант ответа " + k.ToString();
            l.Font = new Font("Tahoma", 12);
            l.AutoSize = true;
            l.Location = new Point(x, y+19);
            t.Location = new Point(xt, y);
            t.TextChanged += new System.EventHandler(textBox1_TextChanged);
            DataInput.ActiveForm.Controls.Add(l);
            DataInput.ActiveForm.Controls.Add(t);
        }
    }
}
