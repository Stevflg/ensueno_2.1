using ensueno.Presentation.Login;
using ensueno.Presentation.Validations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

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
            this.BackColor = color;
            this.Select();
           // Client_autocomplete();
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
        
        private void Button_history_Click(object sender, EventArgs e)
        {
            try
            {
                    //Program.Values.invoice_id =0;
                    //fh = new Form_Users();
                    //fh.ShowDialog();
                    Read();
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form_invoice_Load(object sender, EventArgs e)
        {
            TextBox_search_by_id.Select();
            Read();
            //TextBox_invoice_id.Enabled = false;
            //TextBox_client_id.Enabled = false;
            TextBox_client_id.Text = "";
            Button_update.Enabled = false;
            Button_delete.Enabled = false;
            Button_report.Enabled = false;
            Button_detail.Enabled = false;
        }
        public void Last_id(int client_id,string client_name)
        {

        }

        private void Client_autocomplete()
        {
            try
            {
 
                ComboBox1.DataSource = dt;
                ComboBox1.ValueMember = "ID";
                ComboBox1.DisplayMember = "Nombre Completo";

                AutoCompleteStringCollection lst = new AutoCompleteStringCollection();
                for(int i =0;i< dt.Rows.Count;i++)
                {
                    lst.Add(dt.Rows[i]["Nombre Completo"].ToString());
                }
                ComboBox1.AutoCompleteCustomSource = lst;
                ComboBox1.AutoCompleteMode =AutoCompleteMode.Suggest;
                ComboBox1.AutoCompleteSource=AutoCompleteSource.CustomSource;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Invoice_detail_list_delete(int invoice_id)
        {
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox_client_id.Text = ComboBox1.SelectedValue.ToString();
            }
            catch  { }
        }

        private void Button_update_Click(object sender, EventArgs e)
        {
            try
            {
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_delete_Click(object sender, EventArgs e)
        {
            try
            {

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_invoice_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numbers_only(TextBox_invoice_id, e);   
        }

        private void TextBox_client_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numbers_only(TextBox_client_id, e);
        }
        private void Clear_textboxes()
        {
            TextBox_invoice_id.Text="";
            TextBox_client_id.Text="";           
        }
        private void DataGridView_invoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView_invoices.Rows[e.RowIndex].Cells[0].Value.ToString() == string.Empty)
                {
                    Clear_textboxes();
                    MessageBox.Show("Elija una fila válida.");
                }
                else
                {
                    TextBox_invoice_id.Text = DataGridView_invoices.Rows[e.RowIndex].Cells[0].Value.ToString();
                    TextBox_client_id.Text = DataGridView_invoices.Rows[e.RowIndex].Cells[3].Value.ToString();
                    ComboBox1.Text = DataGridView_invoices.Rows[e.RowIndex].Cells[4].Value.ToString();
                    //Program.Values.employee_name= DataGridView_invoices.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Create_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_client_id.Text == string.Empty)
                {
                    val.empty_text(TextBox_client_id);
                    MessageBox.Show("Rellene los campos faltantes");
                }
                else
                {
                    Last_id(int.Parse(TextBox_client_id.Text),ComboBox1.Text);
                    Form_invoice_create form_Invoice_Create = new Form_invoice_create();
                    form_Invoice_Create.ShowDialog();
                    Read();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_invoice_id_TextChanged(object sender, EventArgs e)
        {

            if (TextBox_invoice_id.Text != string.Empty)
            {
                Button_Create.Enabled = false;
                Button_update.Enabled = true;
                Button_delete.Enabled = true;
                Button_report.Enabled = true;
                Button_detail.Enabled = true;
            }
            else
            {
                Button_Create.Enabled = true;
                Button_update.Enabled = false;
                Button_delete.Enabled = false;
                Button_report.Enabled = false;
                Button_detail.Enabled = false;
            }
        }
        private void Read()
        {
        }

        private void Button_clear_Click(object sender, EventArgs e)
        {
            Clear_textboxes();
        }

        private void Button_detail_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_client_id.Text == string.Empty || TextBox_invoice_id.Text==string.Empty)
                {
                    val.empty_text(TextBox_client_id);
                    val.empty_text(TextBox_invoice_id);
                    MessageBox.Show("Rellene los campos faltantes");
                }
                else
                {
                    //Program.Values.invoice_id = int.Parse(TextBox_invoice_id.Text);
                    //Program.Values.client_name = ComboBox1.Text;
                    Form_invoice_detail fid = new Form_invoice_detail();
                    fid.ShowDialog();
                    Read();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_search_by_id_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_search_by_id.Text==string.Empty)
                {
                    Read();
                }
                else
                {
                }
            }catch(Exception)
            { }
        }

        private void TextBox_search_by_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.number(TextBox_search_by_id, e);
        }
    }
}
