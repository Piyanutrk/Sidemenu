using Sidemenu.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sidemenu
{
    public class PanelDropdown : Panel
    {
        private Timer _timer;
        private Button _buttonMenu;
        private bool _isCollapsed = true;

        private bool _setup = false;

        public PanelDropdown()
        {
            _buttonMenu = new Button();
            _buttonMenu.Dock = DockStyle.Top;
            _buttonMenu.Height = 50;
            _buttonMenu.FlatStyle = FlatStyle.Flat;
            _buttonMenu.FlatAppearance.BorderSize = 0;
            _buttonMenu.BackColor = Color.Navy;
            _buttonMenu.Text = "Button Menu";
            _buttonMenu.ForeColor = Color.White;
            _buttonMenu.Font = new Font(this.Font.Name, 12f, FontStyle.Bold);
            _buttonMenu.Image = Resources.caret_down;
            _buttonMenu.TextImageRelation = TextImageRelation.TextBeforeImage;
            _buttonMenu.TextAlign = ContentAlignment.MiddleRight;
            _buttonMenu.Click += ButtonMenu_Click;

            this.Controls.Add(_buttonMenu);


            _timer = new Timer();
            _timer.Interval = 15;
            _timer.Tick += _timer_Tick;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!_setup)
            {
                List<Control> control = new List<Control>();
                foreach (Control item in Controls)
                {
                    control.Add(item);
                }

                control.Reverse();
                Controls.Clear();


                foreach (var item in control)
                {
                    Controls.Add(item);
                }                

                _setup = true;
            }
            base.OnPaint(e);    
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_isCollapsed)
            {
                _buttonMenu.Image = Resources.caret_arrow_up;
                this.Height += 10;
                if (this.Size == this.MaximumSize)
                {
                    _timer.Stop();
                    _isCollapsed = false;
                }

            }
            else
            {
                _buttonMenu.Image = Resources.caret_down;

                this.Height -= 10;
                if (this.Size == this.MinimumSize)
                {
                    _timer.Stop();
                    _isCollapsed = true;
                }
            }
        }

        private void ButtonMenu_Click(object sender, EventArgs e)
        {
            _timer.Start();
        }
    }
}
