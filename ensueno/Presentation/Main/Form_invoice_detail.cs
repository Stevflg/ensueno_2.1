using Aplicacion.Negocio;
using Aplicacion.ProceduresDB;
using Dominio.Database;
using Dominio.DTO;
using ensueno.Presentation.Validations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ensueno.Presentation.Main
{
    public partial class Form_invoice_detail : Form
    {
        private Invoices invoices;
        private Username UserSessions;
        public Form_invoice_detail(Invoices invoice, Username UserSessions, Color color)
        {
            this.invoices = invoice;
            this.UserSessions = UserSessions;
            InitializeComponent();
            SetComboBoxHeight();
            BackColor = color;
        }

        private async void Form_invoice_detail_Load(object sender, EventArgs e)
        {
            Read();
            LoadProducts();
            Title();
        }


        private async void Title()
        {
            var customer = await ProcInvoiceDetail.getCustomerName(invoices);
            Label_client_name.Text = customer.CustomerName + " " + customer.CustomerLastName;
            Label_Employee_Name.Text = UserSessions.UserName;
            TextBox_invoice_id.Text = invoices.InvoiceId.ToString();
        }



        #region Datagrid y ComboBox
        private int productId;
        private void comboBoxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                productId = int.Parse(comboBoxProducts.SelectedValue.ToString());
                var product = listProducts.Where(a => a.ProdutId.Equals(productId)).First();
                TextBoxStock.Text = product.Stock.ToString();
                TextBox_Precio.Text = product.Unit_Price.ToString();

                SetComboBoxHeight();
            }
            catch { }
        }

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight()
        {
            SendMessage(comboBoxProducts.Handle, CB_SETITEMHEIGHT, -1, 23);
        }


        private void comboBoxInvoice_TextChanged(object sender, EventArgs e)
        {
            SetComboBoxHeight();
        }

        private List<Products> listProducts;
        private async void LoadProducts()
        {
            try
            {
                var ListProd = await ProcInvoiceDetail.ListProducts();
                listProducts = ListProd;

                this.Invoke(new Action(() =>
                {
                    comboBoxProducts.DataSource = ListProd;
                    comboBoxProducts.ValueMember = "ProdutId";
                    comboBoxProducts.DisplayMember = "ProductName";

                    AutoCompleteStringCollection lst = new AutoCompleteStringCollection();
                    for (int i = 0; i < ListProd.Count; i++)
                    {
                        lst.Add(ListProd[i].ProductName);
                    }
                    comboBoxProducts.AutoCompleteCustomSource = lst;
                    comboBoxProducts.AutoCompleteMode = AutoCompleteMode.Suggest;
                    comboBoxProducts.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    SetComboBoxHeight();
                }));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DataGridView_invoice_detail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(DataGridView_invoice_detail.Rows[e.RowIndex].Cells[0].Value.ToString()))
                {
                    Clear_textboxes();
                    EnabledButtons(false);
                }
                else
                {
                    productId = int.Parse(DataGridView_invoice_detail.Rows[e.RowIndex].Cells[1].Value.ToString());
                    comboBoxProducts.Text = DataGridView_invoice_detail.Rows[e.RowIndex].Cells[2].Value.ToString();
                    TextBox_Precio.Text = DataGridView_invoice_detail.Rows[e.RowIndex].Cells[3].Value.ToString();
                    TextBox_amount.Text = DataGridView_invoice_detail.Rows[e.RowIndex].Cells[4].Value.ToString();
                    TextBox_Sub_Total.Text = DataGridView_invoice_detail.Rows[e.RowIndex].Cells[5].Value.ToString();
                    TextBox_IVA.Text = DataGridView_invoice_detail.Rows[e.RowIndex].Cells[6].Value.ToString();
                   TextBox_total.Text = DataGridView_invoice_detail.Rows[e.RowIndex].Cells[3].Value.ToString();
                    EnabledButtons(true);

                }
            }
            catch (Exception ex)
            {
                EnabledButtons(false); 
            }
        }
        private void EnabledButtons(bool state)
        {
            Button_Add.Enabled = !state;
            Button_disable.Enabled = state;
        }



        #endregion

        #region Metodos
        private async void Read()
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    pictureBoxDark.Visible = true;
                    double sumatotal = 0;
                }));
                double sumatotal = 0;
                var result = await ProcInvoiceDetail.ListInvoiceDetail(invoices);
                await Task.Run(() =>
                {
                    foreach (var item in result)
                    {
                        sumatotal += Math.Round((double)item.Total, 2);
                    }
                });
                this.Invoke(new Action(() =>
                {
                    DataGridView_invoice_detail.DataSource = result;
                    pictureBoxDark.Visible = false;
                    Label_Total_Venta.Text = sumatotal.ToString();
                }));
            }
            catch { }
        }


        private async void Add() {
            if (productId != 0)
            {
                await ProcInvoiceDetail.AddInvoiceDetail(new Invoice_Detail
                {
                    InvoiceId = invoices.InvoiceId,
                    ProductId = productId,
                    Units = (int)amount,
                    Price = (int)price
                },UserSessions) ;
                Read();
                Clear_textboxes();
            }
        }
        private async void Delete()
        {
            if (productId != 0)
            {
                await ProcInvoiceDetail.VoidInvoiceDetail(new Invoice_Detail
                {
                    InvoiceId = invoices.InvoiceId,
                    ProductId = productId,
                    Units = (int)amount,
                    Price = (decimal)price
                }, UserSessions);
                Read();
                Clear_textboxes();
            }
        }

        #endregion


        private void Button_invoice_Click(object sender, EventArgs e)
        {
        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private double price, amount, subtotal, iva, total;

        private void TextBox_amount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_amount.Text != string.Empty)
                {
                    Calculate();
                    TextBox_Sub_Total.Text = Convert.ToString(subtotal);
                    TextBox_IVA.Text = Convert.ToString(iva);
                    TextBox_total.Text = Convert.ToString(total);
                }
                else
                {
                    TextBox_Sub_Total.Clear();
                    TextBox_IVA.Clear();
                    TextBox_total.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_agregar_producto_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private Values val = new Values();

        private void TextBox_Precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.decimal_only(TextBox_Precio, e);
        }

        private void TextBox_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.number(TextBox_amount, e);
        }

        private void TextBox_Sub_Total_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.decimal_only(TextBox_Sub_Total, e);
        }

        private void TextBox_IVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.decimal_only(TextBox_IVA, e);
        }

        private void TextBox_total_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.decimal_only(TextBox_total, e);
        }
        private void Clear_textboxes()
        {
            TextBoxStock.Clear();
            TextBox_Precio.Clear();
            TextBox_amount.Clear();
            TextBox_Sub_Total.Clear();
            TextBox_IVA.Clear();
            TextBox_total.Clear();
            TextBoxStock.Clear();
            comboBoxProducts.Text = "";
        }
      
        private void Calculate()
        {
            try
            {
                price = Convert.ToDouble(TextBox_Precio.Text);
                amount = Convert.ToDouble(TextBox_amount.Text);
                subtotal = price * amount;
                iva = subtotal * 0.15;
                total = subtotal + iva;
            }
            catch (Exception)
            { }
        }

        private int Stock;

        private void Button_clear_Click(object sender, EventArgs e)
        {
            Clear_textboxes();
        }

        private void Button_Restore_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_report_Click(object sender, EventArgs e)
        {
            try
            {
                //Program.Values.invoice_id = int.Parse(TextBox_invoice_id.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_disable_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void Button_print_Click(object sender, EventArgs e)
        {
           
        }
    }
}
