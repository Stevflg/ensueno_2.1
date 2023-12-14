using ensueno.Presentation.Validations;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ensueno.Presentation.Main
{
    public partial class Form_invoice : Form
    {
        private Form_Users__ fh;
        private DataTable dt = new DataTable();
        readonly Values val = new Values();

        public Form_invoice(Color color)
        {
            InitializeComponent();
            SetComboBoxHeight();
            comboBoxClientes.Refresh();
            this.BackColor = color;
            this.Select();
            // Client_autocomplete();
        }
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight()
        {
            SendMessage(comboBoxClientes.Handle, CB_SETITEMHEIGHT, -1, 29);
        }


        private void Form_invoice_Load(object sender, EventArgs e)
        {
            Read();
        }


        private void Invoice_detail_list_delete(int invoice_id)
        {

        }

        private void DataGridView_invoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void Read()
        {
        }

        private void comboBoxClientes_TextChanged(object sender, EventArgs e)
        {
            SetComboBoxHeight();
        }

        private void comboBoxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetComboBoxHeight();
        }
    }
}
