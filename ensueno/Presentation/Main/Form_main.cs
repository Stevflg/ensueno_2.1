using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ensueno.Presentation.Main
{
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();
            Apply_dark_mode();
            Admin();
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
        private void Admin()
        {            
            if (Properties.Settings.Default.admin)
            {
                
                Label_user_role.Text = $"Rol de usuario: Administrador ({Properties.Settings.Default.active_user})";
            }
            else
            {
                Separator_slide_panel.Visible = false;
                Button_employees.Visible = false;
                Label_user_role.Text = $"Rol de usuario: Empleado ({Properties.Settings.Default.active_user})";
            }
        }

        private void Button_show_Click(object sender, EventArgs e)
        {
            Button_show.Visible = false;            
            Slide_panel.Visible = false;
            Slide_panel.Width = 175;
            Transition_slide_panel_show.ShowSync(Slide_panel);
            Button_hide.Visible = true;
        }

        private void Button_hide_Click(object sender, EventArgs e)
        {
            Button_hide.Visible = false;            
            Slide_panel.Visible = false;
            Slide_panel.Width = 50;
            Transition_slide_panel_hide.ShowSync(Slide_panel);
            Button_show.Visible = true;
        }

        private void Open_form_panel(object form_panel)
        {
            if (Container_panel.Controls.Count > 0)
            {
                Container_panel.Controls.RemoveAt(0);
            }
            Form fp = form_panel as Form;
            fp.TopLevel = false;
            fp.Dock = DockStyle.Fill;            
            Container_panel.Controls.Add(fp);
            Container_panel.Tag = fp;
            fp.Show();
        }

        private void Button_employees_Click(object sender, EventArgs e)
        {
            Label_form_selected.Text = "Empleados";
            Open_form_panel(new Form_employees());
        }
        private void Button_clients_Click(object sender, EventArgs e)
        {
            Label_form_selected.Text = "Clientes";
            Open_form_panel(new Form_clients());
        }
        private void Button_products_Click(object sender, EventArgs e)
        {
            Label_form_selected.Text = "Productos";
            Open_form_panel(new Form_products());
        }
        private void Button_bills_Click(object sender, EventArgs e)
        {
            Label_form_selected.Text = "Facturas";
            Open_form_panel(new Form_invoice());
        }
    }
}
