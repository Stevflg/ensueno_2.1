using Aplicacion.ProceduresDB;
using Dominio.Database;
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
        private Users user;
        private readonly ProcEmployees proc = new ProcEmployees();
        public Form_welcome(string user)
        {
            InitializeComponent();
            Apply_dark_mode();
            this.Select();
            Button_ok.Select();
            this.usernm = user;
            NameEmployee();
        }
        private void NameEmployee()
        {
            user = new Users { UserName = usernm };
            var employee = proc.GetEmployeeByUserName(user);

            this.Label_employee_name.Text = $"{employee.EmployeeName} {employee.EmployeeLastName}";
        }
        private string usernm;
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

        private void Button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
