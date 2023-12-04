using Aplicacion.ProceduresDB;
using Aplicacion.ProceduresDB;
using Dominio.Database;
using ensueno.Presentation.Validations;
using Guna.UI2.WinForms;
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
    public partial class Agregar_Usuario : Form
    {
      
        private Users user;
        public Agregar_Usuario()
        {
            InitializeComponent();
        }
        #region Textboxes Pass
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
        }
        #endregion

        #region Combobox Autcompletado
        private void AutoCompletEmployee()
        {
            try
            {
            //    var ListEmployees = pEmployees.GetEmployeeList();
            //    ComboBoxEmployees.DataSource = ListEmployees;
            //    ComboBoxEmployees.ValueMember = "EmployeeId";
            //    ComboBoxEmployees.DisplayMember = "EmployeeName";

            //    AutoCompleteStringCollection lst = new AutoCompleteStringCollection();
            //    for (int i = 0; i < ListEmployees.Count; i++)
            //    {
            //        lst.Add(ListEmployees[i].EmployeeName);
            //    }
            //    ComboBoxEmployees.AutoCompleteCustomSource = lst;
            //    ComboBoxEmployees.AutoCompleteMode = AutoCompleteMode.Suggest;
            //    ComboBoxEmployees.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch { }
        }


        private int EmployeeId=0;
        private void ComboBoxEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EmployeeId = int.Parse(ComboBoxEmployees.SelectedValue.ToString());
            }
            catch { }
        }
        #endregion
        private void Agregar_Usuario_Load(object sender, EventArgs e)
        {
            AutoCompletEmployee();
        }

        private void ClearTextBoxes()
        {
            TextBox_password.Clear();
            TextBox_user.Clear();
        }

        private void Button_login_Click(object sender, EventArgs e)
        {
            if (TextBox_user.Text != string.Empty && TextBox_password.Text != string.Empty && ComboBoxEmployees.Text != string.Empty 
                && EmployeeId!=0)
            {
                user = new Users
                {
                    EmployeeId = EmployeeId,
                    UserName = TextBox_user.Text,
                    Password = ProcUsers.Encrypt(TextBox_password.Text)
                };
                MessageBox.Show(ProcUsers.AddUsers(user), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTextBoxes();
            }
            else{
                val.empty_text(TextBox_user);
                val.empty_text(TextBox_password);
            }
        }

        #region Validaciones
        private readonly Values val = new Values();
        #endregion


    }
}
