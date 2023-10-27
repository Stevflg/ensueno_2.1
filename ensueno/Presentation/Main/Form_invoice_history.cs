using ensueno.Sql.Stored_procedures;
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
    public partial class Form_invoice_history : Form
    {
        private DataTable dt = new DataTable();
        public Form_invoice_history()
        {
            InitializeComponent();
            Apply_dark_mode();
            this.Select();
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

        private void DataGridView_invoice_history_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView_invoice_history.Rows[e.RowIndex].Cells[0].Value.ToString() == string.Empty)
                {
                    Clear_textboxes();
                    MessageBox.Show("Elija una fila válida.");
                }
                else
                {
                    TextBox_id.Text =DataGridView_invoice_history.Rows[e.RowIndex].Cells[0].Value.ToString();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void read_history()
        {
            DataGridView_invoice_history.DataSource = dt;
            DataGridView_invoice_history.Refresh();

        }

        private void Clear_textboxes()
        {
            TextBox_id.Text = "";
        }

        private void Form_invoice_history_Load(object sender, EventArgs e)
        {
            read_history();
        }
        private void invoice_detail_list_restore(int invoice_id)
        {
            try
            {

                
            }catch(Exception)
            {

            }
        }
      

        private void Button_restore_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_id_TextChanged(object sender, EventArgs e)
        {
            if (TextBox_id.Text != string.Empty)
            {
                Button_restore.Enabled = true;
            }
            else
            {
                Button_restore.Enabled = false;
            }
        }
    }
    
}
