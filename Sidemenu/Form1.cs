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
        private bool _isCollapsed = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_isCollapsed)
            {
                button2.Image = Resources.caret_arrow_up;
                panelButton2Dropdown.Height += 10;
                if (panelButton2Dropdown.Size == panelButton2Dropdown.MaximumSize)
                {
                    timer1.Stop();
                    _isCollapsed = false;
                }
                
            }
            else
            {
                button2.Image = Resources.caret_down;

                panelButton2Dropdown.Height -= 10;
                if (panelButton2Dropdown.Size == panelButton2Dropdown.MinimumSize)
                {
                    timer1.Stop();
                    _isCollapsed = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
