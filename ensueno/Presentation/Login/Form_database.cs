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
    public partial class Form_database : Form
    {
        public Form_database()
        {
            InitializeComponent();
            Apply_dark_mode();
            TextBox_data_source.Text = Properties.Settings.Default.data_source;
            TextBox_initial_catalog.Text = Properties.Settings.Default.initial_catalog;
            this.Select();
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

        private void Button_save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.data_source = TextBox_data_source.Text;
            Properties.Settings.Default.initial_catalog = TextBox_initial_catalog.Text;
            this.Close();
        }
    }
}
