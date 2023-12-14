using ensueno.Presentation.Login;
using ensueno.Presentation.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ensueno.Presentation.Main
{
    public partial class Form_invoice_detail : Form
    {
        public Form_invoice_detail()
        {
            InitializeComponent();
            Apply_dark_mode();
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

        private void Button_invoice_Click(object sender, EventArgs e)
        {
        }

        private void Form_invoice_detail_Load(object sender, EventArgs e)
        {
        }
        private void Read_invoice_detail(int invoice_id)
        {
        }
        private void Product_autocomplete()
        {
            try
            {
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                TextBox_product_id.Text = ComboBox1.SelectedValue.ToString();
            }
            catch (Exception)
            {

            }
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox_product_id.Text = Convert.ToString(ComboBox1.SelectedValue.ToString());
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
        private void Button_update_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception)
            {

            }
        }
        private void Button_delete_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception)
            {

            }
        }


        private Values val = new Values();
        private void TextBox_id_producto_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numbers_only(TextBox_product_id, e);
        }

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
            TextBox_invoice_id.Clear();
            TextBox_product_id.Clear();
            TextBox_Precio.Clear();
            TextBox_amount.Clear();
            TextBox_Sub_Total.Clear();
            TextBox_IVA.Clear();
            TextBox_total.Clear();
            //TextBox_invoice_id.Text = Convert.ToString(Program.Values.invoice_id);
        }
        private void DataGridView_invoice_detail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView_invoice_detail.Rows[e.RowIndex].Cells[0].Value.ToString() == string.Empty)
                {
                    Clear_textboxes();
                    MessageBox.Show("Elija una fila válida.");
                }
                else
                {
                    TextBox_product_id.Text = DataGridView_invoice_detail.Rows[e.RowIndex].Cells[1].Value.ToString();
                    TextBox_Precio.Text = DataGridView_invoice_detail.Rows[e.RowIndex].Cells[3].Value.ToString();
                    TextBox_amount.Text = DataGridView_invoice_detail.Rows[e.RowIndex].Cells[4].Value.ToString();
                    TextBox_Sub_Total.Text = DataGridView_invoice_detail.Rows[e.RowIndex].Cells[5].Value.ToString();
                    TextBox_IVA.Text = DataGridView_invoice_detail.Rows[e.RowIndex].Cells[6].Value.ToString();
                    TextBox_total.Text = DataGridView_invoice_detail.Rows[e.RowIndex].Cells[7].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            {

            }
        }
        private void Button_history_Click(object sender, EventArgs e)
        {
            try
            {

                //if (TextBox_invoice_id.Text == string.Empty)
                //{
                //    val.empty_text(TextBox_invoice_id);
                //    MessageBox.Show("Este campo no puede estar vacio");
                //}
                //else if (Read_history_by_invoice_id(Program.Values.invoice_id) == true)
                //{
                //    Button_agregar_producto.Visible = false;
                //    Button_report.Visible = false;
                //    Button_update.Visible = false;
                //    Button_delete.Visible = false;
                //    Button_history.Visible = false;
                //    Button_Restore.Visible = true;
                //    Button_return.Visible = true;
                //    ComboBox1.Visible = false;
                //    Clear_textboxes();
                //    TextBox_search_product_Invoice_d.Visible = false;
                //    LabelTotal.Visible = false;
                //    Label_Total_Venta.Visible = false;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int Stock;

        private void Button_clear_Click(object sender, EventArgs e)
        {
            Clear_textboxes();
        }

        private void Button_return_Click(object sender, EventArgs e)
        {
            //  Read_invoice_detail(Program.Values.invoice_id);
            Button_agregar_producto.Visible = true;
            Button_report.Visible = true;
            Button_print.Visible = true;
            Button_delete.Visible = true;
            Button_history.Visible = true;
            Button_Restore.Visible = false;
            Button_return.Visible = false;
            ComboBox1.Visible = true;
            Clear_textboxes();
            TextBox_search_product_Invoice_d.Visible = true;
            Invoice_Detail_total();
            LabelTotal.Visible = true;
            Label_Total_Venta.Visible = true;
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

        private void TextBox_search_product_Invoice_d_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Search_by_letters(TextBox_search_product_Invoice_d, e);
        }

        private void TextBox_search_product_Invoice_d_TextChanged(object sender, EventArgs e)
        {
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

        private void Autocomplete_Product()
        {
            try
            {
                if (TextBox_product_id.Text != string.Empty)
                {
                }
                else
                {
                    TextBox_Precio.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Invoice_Detail_total()
        {
        }
        private void TextBox1_id_producto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Autocomplete_Product();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_disable_Click(object sender, EventArgs e)
        {

        }
    }
}
