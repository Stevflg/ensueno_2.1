using Aplicacion.ProceduresDB;
using Dominio.Database;
using Dominio.DTO;
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
    }
}
