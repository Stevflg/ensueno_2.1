using ensueno.Sql.Stored_procedures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ensueno.Presentation.Main
{
    public partial class Form_products_history : Form
    {
        private byte[] image;
        private MemoryStream memory_stream;
        public Form_products_history()
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

        private void Form_products_history_Load(object sender, EventArgs e)
        {
            Read_history();
            TextBox_id.Enabled = false;
            Button_restore.Enabled = false;
        }

        private void DataGridView_products_history_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView_products_history.Rows[e.RowIndex].Cells[0].Value.ToString() == string.Empty)
                {
                    Clear_textboxes();
                    MessageBox.Show("Elija una fila válida.");
                }
                else
                {
                    TextBox_id.Text = DataGridView_products_history.Rows[e.RowIndex].Cells[0].Value.ToString();
                    Read_image();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Read_image()
        {
            //image = products.Read_image(int.Parse(TextBox_id.Text));
            //memory_stream = new MemoryStream(image);
            //PictureBox_product.Image = Image.FromStream(memory_stream);
        }
        private void Clear_textboxes()
        {
            TextBox_id.Text = "";
            PictureBox_product.Image = null;
        }

        private void Button_restore_Click(object sender, EventArgs e)
        {
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