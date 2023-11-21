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


namespace ensueno.Presentation.Main
{
    public partial class Form_clients : Form
    {
        readonly Values val=new Values();
        private Form_clients_history fh;
        public Form_clients(Color color)
        {
            InitializeComponent();
            this.BackColor = color;
        }

        private void Form_clients_Load(object sender, EventArgs e)
        {
            Read();
            TextBox_id.Enabled = false;
            Button_update.Enabled = false;
            Button_delete.Enabled = false;
            TextBox_read_by_name.Select();
        }
        private void Read()
        {

        }
        private void Clear_textboxes()
        {
            TextBox_id.Text = "";
            TextBox_id_card.Clear();
            TextBox_name.Clear();
            TextBox_last_name.Clear();
            TextBox_phone.Clear();
            TextBox_address.Clear();
        }

        private void Button_clear_Click(object sender, EventArgs e)
        {
            Clear_textboxes();
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
                Button_create.Enabled = true;
                Button_update.Enabled = false;
                Button_delete.Enabled = false;
            }
        }

        private void Button_create_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView_clients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView_clients.Rows[e.RowIndex].Cells[0].Value.ToString() == string.Empty)
                {
                    Clear_textboxes();
                    MessageBox.Show("Elija una fila válida.");
                }
                else
                {
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_read_by_name_TextChanged(object sender, EventArgs e)
        {
        }

        private void TextBox_read_by_last_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button_update_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_delete_Click(object sender, EventArgs e)
        {
        }

        private void Button_history_Click(object sender, EventArgs e)
        {
            fh = new Form_clients_history();
            fh.ShowDialog();
            Read();
        }

        private void TextBox_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numbers_only(TextBox_id,e);
        }

        private void TextBox_id_card_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.empty_text(TextBox_id_card);
        }

        private void TextBox_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Char_only(TextBox_name,e);
        }

        private void TextBox_last_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Char_only(TextBox_last_name, e);
        }

        private void TextBox_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numbers_only(TextBox_phone, e);
        }

        private void TextBox_address_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.empty_text(TextBox_address);
        }

        private void TextBox_read_by_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Search_by_letters(TextBox_read_by_name, e);
        }

        private void TextBox_read_by_last_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Search_by_letters(TextBox_read_by_last_name, e);
        }

        private void Button_report_Click(object sender, EventArgs e)
        {

        }
    }
}
