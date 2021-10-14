using Sidemenu.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sidemenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            ClearSelect(this);

            Button button = sender as Button;
            button.BackColor = Color.Yellow;
            button.ForeColor = Color.Black;
        }

        private void ClearSelect(Control root)
        {
            foreach (Control control in root.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    if (control.BackColor == Color.Yellow)
                    {
                        control.BackColor = Color.Blue;
                        control.ForeColor = Color.White;

                        break;
                    }
                }
                ClearSelect(control);
            }
        }
    }
}
