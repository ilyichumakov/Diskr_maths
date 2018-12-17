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
    public partial class AskUser : Form
    {
        public AskUser()
        {
            InitializeComponent();
        }
        public AskUser(Form1 MainF)
        {
            InitializeComponent();
            There = MainF;
        }

        private Form1 There;

        private void button1_Click(object sender, EventArgs e)
        {
            
            foreach (Control z in this.Controls)
            {
                if (z is TextBox && Int32.TryParse(z.Text, out int f))
                {
                    There.p.Add(f);                    
                }
            }
            this.Hide();
            for (int i=0; i<There.Controls.Count; i++)
            {
                if(There.Controls[i] is TextBox|| There.Controls[i] is Label)
                {
                    There.Controls[i].Dispose();
                    i--;
                }
            }
            MessageBox.Show("Всего в опросе приняло участие " + There.IncMis(There.p, There.q.Count) + " человек", "Результаты", MessageBoxButtons.OK);
            this.Dispose();
        }
    }
}
