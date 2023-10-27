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
    public partial class Form_employees_history : Form
    {
        public Form_employees_history()
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
        private void Read_history()
        {            
        }

        private void Form_employees_history_Load(object sender, EventArgs e)
        {
            Read_history();
            TextBox_id.Enabled = false;
            TextBox_user.Enabled = false;
            TextBox_password.Enabled = false;
            Button_restore.Enabled = false;
        }

        private void DataGridView_employees_history_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView_employees_history.Rows[e.RowIndex].Cells[0].Value.ToString() == string.Empty)
                {
                    Clear_textboxes();
                    MessageBox.Show("Elija una fila válida.");
                }
                else
                {
                    TextBox_id.Text = DataGridView_employees_history.Rows[e.RowIndex].Cells[0].Value.ToString();                    
                    TextBox_user.Text = DataGridView_employees_history.Rows[e.RowIndex].Cells[6].Value.ToString();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Clear_textboxes()
        {
            TextBox_id.Text = "";            
            TextBox_user.Text="";
            TextBox_password.Text="";
        }

        private void Button_restore_Click(object sender, EventArgs e)
        {            
        }

        private void TextBox_id_TextChanged(object sender, EventArgs e)
        {
            if (TextBox_id.Text != string.Empty)
            {                
                TextBox_password.Enabled = true;
                Button_restore.Enabled = true;
            }
            else
            {                
                TextBox_password.Enabled = false;
                Button_restore.Enabled = false;
            }
        }
    }
}
