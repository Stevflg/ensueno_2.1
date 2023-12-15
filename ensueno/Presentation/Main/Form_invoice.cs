using Aplicacion.Negocio;
using Aplicacion.ProceduresDB;
using Dominio.Database;
using Dominio.DTO;
using ensueno.Presentation.Validations;
using Persistencia.Proc;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ensueno.Presentation.Main
{
    public partial class Form_invoice : Form
    {
        private Form_Users__ fh;
        private DataTable dt = new DataTable();
        readonly Values val = new Values();

        private Username UserSessions;
        public Form_invoice(Color color, Username UserSessions)
        {
            InitializeComponent();
            this.UserSessions = UserSessions;
            SetComboBoxHeight();
            comboBoxClientes.Refresh();
            this.BackColor = color;
            this.Select();
        }
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight()
        {
            SendMessage(comboBoxClientes.Handle, CB_SETITEMHEIGHT, -1, 23);
        }

        private void Button_clear_Click(object sender, EventArgs e)
        {
            comboBoxClientes.Text = string.Empty;
        }

        private async void Form_invoice_Load(object sender, EventArgs e)
        {
            Read();
            LoadCustomers();
        }


        #region Metodos
        private async void SearchInvoice()
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    pictureBoxDark.Visible = true;
                    TextBox_Search_Invoice.Enabled = false;
                    ButtonSearch.Enabled = false;
                }));
                var result = await ProcInvoice.SearchInvoice(TextBox_Search_Invoice.Text);
                this.Invoke(new Action(() =>
                {
                    DataGridView_invoices.DataSource = result;
                    pictureBoxDark.Visible = false;
                    ButtonSearch.Enabled = true;
                    TextBox_Search_Invoice.Enabled = true;
                }));
            }
            catch { }
        }

        private async void Read()
        {
            this.Invoke(new Action(() =>
            {
                pictureBoxDark.Visible = true;
                ButtonSearch.Visible = false;
            }));
            var result = await ProcInvoice.ListInvoice();
            this.Invoke(new Action(() =>
            {
                DataGridView_invoices.DataSource = result;
                pictureBoxDark.Visible = false;
                ButtonSearch.Visible = true;
            }));
        }

        private async void Add()
        {
            if (CustomerId != 0)
            {
                if (MessageBox.Show("Desea Crear Factura?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    var invoice = await ProcInvoice.AddInvoice(new Invoices { EmployeeId = UserSessions.EmployeeId, CustomerId = CustomerId });
                    if (invoice != null)
                    {
                        Form_invoice_detail frmid = new Form_invoice_detail(invoice, UserSessions, BackColor);
                        frmid.ShowDialog();
                    }
                }
            }
        }

        private async void VoidInvoice()
        {
            if (InvoiceId != 0)
            {
                this.Invoke(new Action(() =>
                {
                    EnabledButtons(false);
                }));
                var result = await ProcInvoice.VoidInvoice(new Invoices
                {
                    InvoiceId = InvoiceId,
                    UpdateBy = UserSessions.EmployeeId,
                    UpdateDate = DateTime.Now
                });
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Read();
                }));
            }
        }

        private void Detail()
        {
            if (InvoiceId != 0)
            {
                Form_invoice_detail frmid = new Form_invoice_detail(new Invoices { InvoiceId = InvoiceId
                    ,EmployeeId = UserSessions.EmployeeId, CustomerId = CustomerId }
                , UserSessions, BackColor);
                frmid.ShowDialog();
            }
        }

        #endregion


        #region Datagrid y Combobox
        private int InvoiceId;
        private void DataGridView_invoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(DataGridView_invoices.Rows[e.RowIndex].Cells[0].Value.ToString()))
                {
                    comboBoxClientes.Text = string.Empty;
                    EnabledButtons(false);
                }
                else
                {
                    InvoiceId = int.Parse(DataGridView_invoices.Rows[e.RowIndex].Cells[0].Value.ToString());
                    EnabledButtons(true);
                }
            }
            catch
            {
                comboBoxClientes.Text = string.Empty;
                EnabledButtons(false);
            }
        }

        private async void LoadCustomers()
        {
            try
            {
                var ListCategory = await ProcInvoice.ListCustomers();
                this.Invoke(new Action(() =>
                {
                    comboBoxClientes.DataSource = ListCategory;
                    comboBoxClientes.ValueMember = "Id";
                    comboBoxClientes.DisplayMember = "Nombres";

                    AutoCompleteStringCollection lst = new AutoCompleteStringCollection();
                    for (int i = 0; i < ListCategory.Count; i++)
                    {
                        lst.Add(ListCategory[i].Nombres);
                    }
                    comboBoxClientes.AutoCompleteCustomSource = lst;
                    comboBoxClientes.AutoCompleteMode = AutoCompleteMode.Suggest;
                    comboBoxClientes.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    SetComboBoxHeight();
                }));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnabledButtons(bool state)
        {
            Button_create.Enabled = !state;
            Button_delete.Enabled = state;
            Button_Detail.Enabled = state;
        }
        private void comboBoxClientes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetComboBoxHeight();
            }
            catch { }
        }

        private int CustomerId;
        private void comboBoxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                SetComboBoxHeight();
                CustomerId = int.Parse(comboBoxClientes.SelectedValue.ToString());
            }
            catch { }
        }
        #endregion



        #region Events
        private async void ButtonSearch_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { SearchInvoice(); });
        }

        private async void TextBox_Search_Invoice_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                await Task.Run(() => { SearchInvoice(); });
            }
        }
        private void TextBox_Search_Invoice_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_Search_Invoice.Text)) Read();
        }
        #endregion


        private async void Button_create_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void Button_Detail_Click(object sender, EventArgs e)
        {
            Detail();
        }

        private async void Button_delete_Click(object sender, EventArgs e)
        {
            VoidInvoice();
        }
    }
}
