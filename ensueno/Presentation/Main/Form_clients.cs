using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ensueno.Presentation.Validations;
using Aplicacion.ProceduresDB;
using Dominio.Database;
using Dominio.DTO;
using Guna.UI2.WinForms.Suite;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;


namespace ensueno.Presentation.Main
{
    public partial class Form_clients : Form
    {
        private readonly Values val = new Values();
        private readonly ProcCustomers pCustomers;
        private Customers customer;
        private readonly Username userSessions;
        public Form_clients(Color color, Username userSessions)
        {
            InitializeComponent();
            this.BackColor = color;
            pCustomers = new ProcCustomers();
            this.userSessions = userSessions;
        }

        private async void Form_clients_Load(object sender, EventArgs e)
        {
            await Task.Run(new Action(() => { Read(); }));
        }
        #region Procedimientos
    
        private async void Read()
        {
            //estoy cansado jefe cansado
            this.Invoke(new Action(() =>
            {
                pictureBoxDark.Visible = true;
                ButtonSearch.Visible = false;
            }));
            var result = await pCustomers.ListCustomers();
            this.Invoke(new Action(() =>
            {
                DataGridView_Customers.DataSource = result;
                pictureBoxDark.Visible = false;
                ButtonSearch.Visible = true;
            }));
        }
        private async void AddCustomer()
        {
            customer = new Customers
            {
                CreatedBy = userSessions.EmployeeId,
                CustomerName = TextBox_name.Text,
                CustomerLastName = TextBox_last_name.Text,
                CustomerIdentification = TextBox_id_card.Text,
                CustomerPhone = TextBox_phone.Text,
                CustomerAddress = TextBox_address.Text,
                Email = TextBoxEmail.Text
            };

            if (string.IsNullOrWhiteSpace(TextBox_name.Text) || string.IsNullOrWhiteSpace(TextBox_last_name.Text) ||
                string.IsNullOrWhiteSpace(TextBox_id_card.Text) || string.IsNullOrWhiteSpace(TextBox_phone.Text) || string.IsNullOrWhiteSpace(TextBox_address.Text)
                || string.IsNullOrWhiteSpace(TextBoxEmail.Text))
            {
                ValidacionesText();
            }
            else
            {
                if (MessageBox.Show("¿Desea Agregar Este Registro?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var result = await pCustomers.AddCustomer(customer);
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearTextBoxes();
                        Read();
                    }));
                }
            }
        }
        private async void DeleteCustomer()
        {
            customer = new Customers
            {
                CustomerId = CustomerId,
                UpdateBy = userSessions.EmployeeId,
                Update_date_time = DateTime.Now
            };
            var result = await pCustomers.DeleteCustomer(customer);
            this.Invoke(new Action(() =>
            {
                MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTextBoxes();
                Read();
            }));
        }
        private async void SearchCustomer()
        {
            try
            {
                customer = new Customers
                {
                    CustomerName = TextBox_name.Text,
                };
                this.Invoke(new Action(() =>
                {
                    pictureBoxDark.Visible = true;
                    ButtonSearch.Enabled = false;
                }));
                var result = await pCustomers.SearchCustomers(customer);
                this.Invoke(new Action(() =>
                {
                    DataGridView_Customers.DataSource = result;
                    pictureBoxDark.Visible = false;
                    ButtonSearch.Enabled = true;
                }));
            }
            catch { }
        }

        #endregion

        #region Events
        private void Button_clear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
        private async void ButtonSearch_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { SearchCustomer(); });
        }
        private void TextBox_id_TextChanged(object sender, EventArgs e)
        {
            if (TextBox_id.Text != string.Empty)
            {
                Button_create.Enabled = false;
                Button_update.Enabled = true;
                Button_delete.Enabled = true;
            }
            else
            {
                if (string.IsNullOrEmpty(TextBox_id.Text)) { val.ClearError(); }
                Button_create.Enabled = true;
                Button_update.Enabled = false;
                Button_delete.Enabled = false;
            }
        }
        private int CustomerId;
        private void DataGridView_Customers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView_Customers.Rows[e.RowIndex].Cells[0].Value.ToString() == string.Empty)
                {
                    ClearTextBoxes();
                    MessageBox.Show("Elija una fila válida.");
                }
                else
                {
                    TextBox_id.Text = DataGridView_Customers.Rows[e.RowIndex].Cells[0].Value.ToString();
                    CustomerId = int.Parse(DataGridView_Customers.Rows[e.RowIndex].Cells[0].Value.ToString());
                    TextBox_name.Text = DataGridView_Customers.Rows[e.RowIndex].Cells[1].Value.ToString();
                    TextBox_last_name.Text = DataGridView_Customers.Rows[e.RowIndex].Cells[2].Value.ToString();
                    TextBox_id_card.Text = DataGridView_Customers.Rows[e.RowIndex].Cells[3].Value.ToString();
                    TextBox_phone.Text = DataGridView_Customers.Rows[e.RowIndex].Cells[4].Value.ToString();
                    TextBox_address.Text = DataGridView_Customers.Rows[e.RowIndex].Cells[5].Value.ToString();
                    TextBoxEmail.Text = DataGridView_Customers.Rows[e.RowIndex].Cells[6].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void Button_create_Click(object sender, EventArgs e)
        {
            try
            {
                AddCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private Form_customer_edit cedit;
        private async void Button_update_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Form_customer_edit);
                if (frm != null)
                {
                    frm.BringToFront();
                }
                else
                {
                    cedit = new Form_customer_edit(CustomerId, userSessions, BackColor);
                    cedit.ShowDialog();
                    pictureBoxDark.Visible = true;
                    Read();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Button_delete_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { DeleteCustomer(); });
        }
        private async void TextBox_Search_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await Task.Run(() => { SearchCustomer(); });
            }
        }
        #endregion


        #region Validaciones

        private void ValidacionesText()
        {
            val.empty_text(TextBox_last_name);
            val.empty_text(TextBox_last_name);
            val.empty_text(TextBox_id_card);
            val.empty_text(TextBox_phone);
            val.empty_text(TextBox_address);
            val.empty_text(TextBoxEmail);
        }

        private void ClearTextBoxes()
        {
            TextBox_id.Clear();
            TextBox_id_card.Clear();
            TextBox_name.Clear();
            TextBox_last_name.Clear();
            TextBox_phone.Clear();
            TextBox_address.Clear();
            TextBoxEmail.Clear();
        }
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
