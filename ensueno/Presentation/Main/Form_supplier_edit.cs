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

namespace ensueno.Presentation.Main
{
    public partial class Form_supplier_edit : Form
    {
        private Username UserSessions;
        private int SupplierId;
        public Form_supplier_edit(Username UserSession, int SupplierId, Color color)
        {
            InitializeComponent();
            UserSessions = UserSession;
            this.SupplierId = SupplierId;
            BackColor = color;
        }

        private async void Form_supplier_edit_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            this.Invoke(new Action(() => { pictureBoxLoadData.Visible = true; }));
            var result = await ProcSupplier.GetSupplier(new Suppliers { SupplierId = SupplierId });
            this.Invoke(new Action(() =>
            {
                TextBox_id.Text = result.SupplierId.ToString();
                TextBoxSuplierName.Text = result.SupplierName;
                TextBoxAddress.Text = result.SupplierAddress;
                TextBoxRUC.Text = result.SupplierRUC.ToString();
                TextBoxPhone.Text = result.SupplierPhone;
                TextBoxEmail.Text = result.SupplierEmail;
                pictureBoxLoadData.Visible = false;
            }));
        }
        private async void UpdateSupplier()
        {
            if (!string.IsNullOrEmpty(TextBoxSuplierName.Text) && !string.IsNullOrEmpty(TextBoxAddress.Text) && !string.IsNullOrEmpty(TextBoxRUC.Text)
                && !string.IsNullOrEmpty(TextBoxPhone.Text) && !string.IsNullOrEmpty(TextBoxEmail.Text))
            {
                this.Invoke(new Action(() => { ButtonSave.Enabled = false; }));
                Suppliers supplier = new Suppliers
                {
                    SupplierId = SupplierId,
                    SupplierName = TextBoxSuplierName.Text,
                    SupplierAddress = TextBoxAddress.Text,
                    SupplierRUC = TextBoxRUC.Text,
                    SupplierPhone = TextBoxPhone.Text,
                    SupplierEmail = TextBoxEmail.Text,
                    UpdateBy = UserSessions.EmployeeId,
                    Date_Updated = DateTime.Now,
                };
                var result = await ProcSupplier.UpdateSupplier(supplier);
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ButtonSave.Enabled = true;
                    this.Close();
                }));
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    Validations();
                }));
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateSupplier();
            }
            catch { }
        }

        private readonly Values val = new Values();
        private void Validations()
        {
            val.empty_text(TextBox_id);
            val.empty_text(TextBoxSuplierName);
            val.empty_text(TextBoxRUC);
            val.empty_text(TextBoxAddress);
            val.empty_text(TextBoxPhone);
            val.empty_text(TextBoxEmail);
        }

        private void TextBox_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numbers_only(TextBox_id, e);
        }

        private void TextBoxSuplierName_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.empty_text(TextBoxSuplierName);
        }

        private void TextBoxAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.empty_text(TextBoxAddress);
        }

        private void TextBoxRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.empty_text(TextBoxRUC);
        }

        private void TextBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numbers_only(TextBoxPhone, e);
        }

        private void TextBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.empty_text(TextBoxEmail);
        }

        private void TextBox_id_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_id.Text)) val.ClearError();
            val.ClearError();
        }

        private void TextBoxSuplierName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxSuplierName.Text)) val.ClearError();
            val.ClearError();
        }

        private void TextBoxAddress_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxAddress.Text)) val.ClearError();
            val.ClearError();
        }

        private void TextBoxRUC_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxRUC.Text)) val.ClearError();
            val.ClearError();
        }

        private void TextBoxPhone_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxPhone.Text)) val.ClearError();
            val.ClearError();
        }

        private void TextBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxEmail.Text)) val.ClearError();
            val.ClearError();
        }


    }
}
