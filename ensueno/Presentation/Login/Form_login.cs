using Aplicacion.ProceduresDB;
using Dominio.Database;
using ensueno.Presentation.Main;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ensueno.Presentation.Login
{
    public partial class Form_login : Form
    {
        private Form_database fd;
        private Form_welcome fw;
        private Form_login_error fle;
        private Users user;
        private Form_main fm;
        public Form_login()
        {
            InitializeComponent();
            Apply_dark_mode();
            Switch_dark_mode.Checked = Properties.Settings.Default.dark_mode;
            TextBox_user.Select();
        }
        #region Show Pass
        private void MostrarPass()
        {
            ButtonShowPass.Visible = false;
            TextBox_password.PasswordChar = '\0';
        }
        private void OcultarPass()
        {
            TextBox_password.PasswordChar = '*';
        }

        private void TextBox_password_TextChanged(object sender, EventArgs e)
        {

            if (TextBox_password.Text == string.Empty)
            {
                ButtonShowPass.Visible = false;
            }
            else
            {
                ButtonShowPass.Visible = true;
            }
            OcultarPass();
        }

        private void ButtonShowPass_Click(object sender, EventArgs e)
        {
            MostrarPass();
            TextBox_password.Focus();
        }


        #endregion
        private void Form_login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
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
        private void Button_dark_mode_Click(object sender, EventArgs e)
        {
            Switch_dark_mode.Checked = !Switch_dark_mode.Checked;
            Properties.Settings.Default.dark_mode = Switch_dark_mode.Checked;
            Apply_dark_mode();
        }
        private void Switch_dark_mode_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.dark_mode = Switch_dark_mode.Checked;
            Apply_dark_mode();
        }
        private void Form_login_BackColorChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }
        private void Button_database_Click(object sender, EventArgs e)
        {
            fd = new Form_database();
            fd.ShowDialog();
        }
        private void Button_login_Click(object sender, EventArgs e)
        {
            Login();
        }
        public static string employee_id, employee_name, employee_last_name;


        private void Login()
        {
            try
            {
                user = new Users
                {
                    UserName = TextBox_user.Text,
                    Password = ProcUsers.Encrypt(TextBox_password.Text)
                };
                if (ProcUsers.UserLogin(user))
                {
                    Clear_textboxes();
                    this.Hide();
                    Show_form_welcome(user.UserName);
                    Show_form_main(user.UserName);
                    this.Close();
                }
                else
                {
                    fle = new Form_login_error();
                    fle.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El usuario está deshabilitado.");
                MessageBox.Show(ex.Message);
            }
        }
        private void Clear_textboxes()
        {
            TextBox_user.Clear();
            TextBox_password.Clear();
        }
        private void Show_form_welcome(string name)
        {
            fw = new Form_welcome(name);
            fw.ShowDialog();
        }

        private void Label_about_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Label_about.LinkVisited = true;
            System.Diagnostics.Process.Start("https://linktr.ee/perfumeria.ensueno");
        }

        private void Show_form_main(string username)
        {
            fm = new Form_main(username);
            fm.ShowDialog();
        }

        private void TextBox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }
    }
}