using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ensueno.Presentation.Login
{
    public partial class Form_welcome : Form
    {
        public Form_welcome()
        {
            InitializeComponent();
            Apply_dark_mode();
            this.Select();
            Button_ok.Select();
        }
        private void Apply_dark_mode()
        {
            if (Properties.Settings.Default.dark_mode)
            {
                this.BackColor = Color.FromArgb(31, 31, 31);
            }
            else
            {
                this.BackColor = Color.FromArgb(238, 238, 238);
            }
        }
        public void Welcome(string employee_name, string employee_last_name)
        {
            Label_employee_name.Text = $"{employee_name} {employee_last_name}";
        }

        private void Button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
