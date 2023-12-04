using Aplicacion.ProceduresDB;
using Dominio.Database;
using Dominio.DTO;
using ensueno.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace ensueno.Presentation.Main
{
    public partial class Form_main : Form
    {
        private string username = "";
        public Form_main(string username)
        {
            InitializeComponent();
            Apply_dark_mode();
            Admin(username);
            this.Select();
            //Open_form_panel(new Form_Report_Employee());
        }
        private Username userSesion;
        private Color color;
        private void Apply_dark_mode()
        {
            var color = Properties.Settings.Default.dark_mode == true ? Color.FromArgb(31, 31, 31) : Color.FromArgb(238, 238, 238);
            this.BackColor = color;
            this.color = color;
        }
        private async void Admin(string username)
        {
            Users users = new Users { UserName = username };
            userSesion = await ProcUsers.UserName(users);
            Label_user_role.Text = userSesion.UserName + " : " + userSesion.RolName;
            Read_image(userSesion.Image);
        }
        private MemoryStream memory_stream;
        private void Read_image(byte[] image)
        {
            if (image != null)
            {
                memory_stream = new MemoryStream(image);
                pictureBoxUser.Image = Image.FromStream(memory_stream);
            }
            else
            {
                pictureBoxUser.Image = Resources.error;
            }
        }

        private void Button_show_Click(object sender, EventArgs e)
        {
            Button_show.Visible = false;
            Slide_panel.Visible = false;
            Slide_panel.Width = 200;
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

        private async void Open_form_panel(object form_panel)
        {
            Form fp = form_panel as Form;
            if (Container_panel.Controls.Count > 0)
            {
                Container_panel.Controls.RemoveAt(0);
            }
            fp.TopLevel = false;
            fp.Dock = DockStyle.Fill;
            Container_panel.Controls.Add(fp);
            Container_panel.Tag = fp;
            fp.Show();
        }

        private void Button_employees_Click(object sender, EventArgs e)
        {
            Label_form_selected.Text = "Empleados";
            Open_form_panel(new Form_employees(color, userSesion));
        }
        private void Button_clients_Click(object sender, EventArgs e)
        {
            Label_form_selected.Text = "Clientes";
            Open_form_panel(new Form_clients(color, userSesion));
        }
        private void Button_products_Click(object sender, EventArgs e)
        {
            Label_form_selected.Text = "Productos";
            Open_form_panel(new Form_products(color));
        }
        private void Button_bills_Click(object sender, EventArgs e)
        {
            Label_form_selected.Text = "Facturas";
            Open_form_panel(new Form_invoice(color));
        }
        private void ButtonInventories_Click(object sender, EventArgs e)
        {
            Label_form_selected.Text = "Inventarios";
            Open_form_panel(new Form_Inventories(color));
        }

        private void Button_suppliers_Click(object sender, EventArgs e)
        {
            Label_form_selected.Text = "Proveedores";
            Open_form_panel(new Form_suppliers(color, userSesion));
        }
    }
}
