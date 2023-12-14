using Aplicacion.ProceduresDB;
using Dominio.Database;
using Dominio.DTO;
using ensueno.Presentation.Validations;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ensueno.Presentation.Main
{
    public partial class Form_suppliers : Form
    {
        private Username UserSessions;
        private Suppliers supplier;
        public Form_suppliers(Color color, Username user)
        {
            InitializeComponent();
            this.BackColor = color;
            this.UserSessions = user;
        }

        private async void Form_suppliers_Load(object sender, EventArgs e)
        {
            ReadSuppliers();
        }
        #region Procedimientos
        private async void ReadSuppliers()
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    pictureBoxDark.Visible = true;
                }));

                var result = await ProcSupplier.GetListSuppliers();

                this.Invoke(new Action(() =>
                {
                    DataGridView_Suppliers.DataSource = result;
                    pictureBoxDark.Visible = false;
                }));
            }
            catch { }
        }
        private async void SearchSupplier()
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    pictureBoxDark.Visible = true;
                    TextBox_SearchSupplier.Enabled = false;
                    ButtonSearch.Enabled = false;
                }));
                supplier = new Suppliers
                {
                    SupplierName = TextBox_SearchSupplier.Text
                };
                var result = await ProcSupplier.SearchSuppliers(supplier);

                this.Invoke(new Action(() =>
                {
                    DataGridView_Suppliers.DataSource = result;
                    pictureBoxDark.Visible = false;
                    TextBox_SearchSupplier.Enabled = true;
                    ButtonSearch.Enabled = true;
                }));
            }
            catch { }
        }
        private async void CreateSupplier()
        {

            if (!string.IsNullOrEmpty(TextBoxSuplierName.Text) && !string.IsNullOrEmpty(TextBoxAddress.Text) && !string.IsNullOrEmpty(TextBoxRUC.Text)
                && !string.IsNullOrEmpty(TextBoxPhone.Text) && !string.IsNullOrEmpty(TextBoxEmail.Text))
            {
                supplier = new Suppliers
                {
                    SupplierName = TextBoxSuplierName.Text,
                    SupplierAddress = TextBoxAddress.Text,
                    SupplierRUC = TextBoxRUC.Text,
                    SupplierPhone = TextBoxPhone.Text,
                    SupplierEmail = TextBoxEmail.Text,
                    CreatedBy = UserSessions.EmployeeId
                };
                var result = await ProcSupplier.AddSupplier(supplier);
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxes();
                    ReadSuppliers();
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
        private int supplierId = 0;
        private async void DeleteSupplier()
        {
            if (supplierId > 0)
            {
                supplier = new Suppliers
                {
                    SupplierId = supplierId,
                    UpdateBy = UserSessions.EmployeeId,
                    Date_Updated = DateTime.Now
                };
                var result = await ProcSupplier.DeleteSupplier(supplier);
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReadSuppliers();
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

        #endregion
        #region Validaciones

        private void ClearTextBoxes()
        {
            TextBox_id.Clear();
            TextBoxSuplierName.Clear();
            TextBoxRUC.Clear();
            TextBoxAddress.Clear();
            TextBoxPhone.Clear();
            TextBoxEmail.Clear();
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
        #endregion

        #region Eventos
        private void Button_create_Click(object sender, EventArgs e)
        {
            try
            {
                CreateSupplier();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Form_supplier_edit frmsupplieredit;
        private void Button_update_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Form_supplier_edit);
                if (frm != null)
                {
                    frm.BringToFront();
                }
                else
                {
                    frmsupplieredit = new Form_supplier_edit(UserSessions, supplierId, BackColor);
                    frmsupplieredit.ShowDialog();
                    ReadSuppliers();
                }
            }
            catch { }
        }

        private void Button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteSupplier();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_report_Click(object sender, EventArgs e)
        {

        }

        private async void TextBox_SearchSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await Task.Run(() => { SearchSupplier(); });
            }
        }

        private async void TextBox_SearchSupplier_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_SearchSupplier.Text)) ReadSuppliers();
        }

        private async void ButtonSearch_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { SearchSupplier(); });
        }

        private void DataGridView_Suppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView_Suppliers.Rows[e.RowIndex].Cells[0].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("Elija una fila válida.");
                    Button_delete.Enabled = false;
                    Button_update.Enabled = false;
                    Button_create.Enabled = true;
                }
                else
                {
                    TextBox_id.Text = DataGridView_Suppliers.Rows[e.RowIndex].Cells[0].Value.ToString();
                    supplierId = int.Parse(DataGridView_Suppliers.Rows[e.RowIndex].Cells[0].Value.ToString());
                    TextBoxSuplierName.Text = DataGridView_Suppliers.Rows[e.RowIndex].Cells[1].Value.ToString();
                    TextBoxAddress.Text = DataGridView_Suppliers.Rows[e.RowIndex].Cells[2].Value.ToString();
                    TextBoxRUC.Text = DataGridView_Suppliers.Rows[e.RowIndex].Cells[3].Value.ToString();
                    TextBoxPhone.Text = DataGridView_Suppliers.Rows[e.RowIndex].Cells[4].Value.ToString();
                    TextBoxEmail.Text = DataGridView_Suppliers.Rows[e.RowIndex].Cells[5].Value.ToString();
                    Button_delete.Enabled = true;
                    Button_update.Enabled = true;
                    Button_create.Enabled = false;
                }
            }
            catch
            {
                Button_delete.Enabled = false;
                Button_update.Enabled = false;
                Button_create.Enabled = true;
            }
        }
        #endregion

        
    }
}
