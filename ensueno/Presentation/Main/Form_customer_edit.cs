using Aplicacion.Negocio;
using Aplicacion.ProceduresDB;
using Dominio.Database;
using Dominio.DTO;
using ensueno.Presentation.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ensueno.Presentation.Main
{
    public partial class Form_customer_edit : Form
    {
        private readonly Username userSessions;
        public Form_customer_edit(int employeeid, Username userSesions, Color color)
        {
            InitializeComponent();
            this.CustomerId = employeeid;
            this.userSessions = userSesions;
            this.BackColor = color;
        }
        private int CustomerId;
        #region Carga de datos
        private async void LoadDataCustomer(int customerId)
        {
            this.Invoke(new Action(() =>
            {
                pictureBoxLoadData.Visible = true;
            }));
           
            Customers customer = new Customers { CustomerId = customerId };
            var result = await ProcCustomers.GetCustomerByEdit(customer);
            this.Invoke((Action)(() =>
            {
                TextBox_id.Text = result.CustomerId.ToString();
                TextBox_name.Text = result.CustomerName;
                TextBox_last_name.Text = result.CustomerLastName;
                TextBox_id_card.Text = result.CustomerIdentification;
                TextBox_phone.Text = result.CustomerPhone;
                TextBox_address.Text = result.CustomerAddress;
                TextBoxEmail.Text = result.Email;
                pictureBoxLoadData.Visible = false;
            }));
        }
        #endregion
        readonly Values val = new Values();
        private void ValidacionesText()
        {
            val.empty_text(TextBox_id);
            val.empty_text(TextBox_last_name);
            val.empty_text(TextBox_last_name);
            val.empty_text(TextBox_id_card);
            val.empty_text(TextBox_phone);
            val.empty_text(TextBox_address);
            val.empty_text(TextBoxEmail);
        }
        private async void saveChanges()
        {
            Customers customer = new Customers
            {
                CustomerId = CustomerId,
                CustomerName = TextBox_name.Text,
                CustomerLastName = TextBox_last_name.Text,
                CustomerIdentification = TextBox_id_card.Text,
                CustomerPhone = TextBox_phone.Text,
                CustomerAddress = TextBox_address.Text,
                Email = TextBoxEmail.Text,
                UpdateBy = userSessions.EmployeeId,
                Update_date_time = DateTime.Now
            };
            if (string.IsNullOrWhiteSpace(TextBox_last_name.Text) || string.IsNullOrWhiteSpace(TextBox_last_name.Text) ||
               string.IsNullOrWhiteSpace(TextBox_id_card.Text) || string.IsNullOrWhiteSpace(TextBox_phone.Text) || string.IsNullOrWhiteSpace(TextBox_address.Text)
               || string.IsNullOrWhiteSpace(TextBoxEmail.Text))
            {
                ValidacionesText();
            }
            else
            {
                if (MessageBox.Show("¿Desea Guardar Cambios?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var result = await ProcCustomers.EditCustomer(customer);
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }));
                }
            }
        }

        #region Eventos
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            saveChanges();
        }
        private async void Form_customer_edit_Load(object sender, EventArgs e)
        {
            await Task.Run(() => { LoadDataCustomer(CustomerId); });
        }
        #endregion


        #region Validaciones
        private void TextBox_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numbers_only(TextBox_id, e);
        }
        private void TextBox_id_card_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.empty_text(TextBox_id_card);
        }
        private void TextBox_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Char_only(TextBox_name, e);
        }
        private void TextBox_last_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Char_only(TextBox_last_name, e);
        }
        private void TextBox_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numbers_only(TextBox_phone, e);
        }
        private void TextBox_name_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_name.Text)) val.ClearError();
        }
        private void TextBox_last_name_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_last_name.Text)) val.ClearError();
        }
        private void TextBox_id_card_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_id_card.Text)) val.ClearError();
        }
        private void TextBox_phone_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_phone.Text)) val.ClearError();
        }
        private void TextBox_address_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_address.Text)) val.ClearError();
        }
        private void TextBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxEmail.Text)) val.ClearError();
        }
        #endregion
    }
}
