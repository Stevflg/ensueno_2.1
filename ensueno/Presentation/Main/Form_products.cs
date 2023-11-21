using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using Guna.UI2.WinForms;
using ensueno.Presentation.Validations;

namespace ensueno.Presentation.Main
{
    public partial class Form_products : Form
    {

        private string image_location;
        private byte[] image;
        private MemoryStream memory_stream;
        private Form_products_history fh;
        readonly Values val=new Values();
        private bool validate_image_location;
        public Form_products(Color color)
        {
            InitializeComponent();
            this.BackColor = color;
        }
        private void Button_add_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog file_dialog = new OpenFileDialog
            {
                Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*"
            };
            if (file_dialog.ShowDialog() == DialogResult.OK)
            {
                image_location = file_dialog.FileName.ToString();
                PictureBox_product.ImageLocation = image_location;
            }
        }
        private void Convert_image()
        {
            if (PictureBox_product.ImageLocation == null)
            {                
                validate_image_location = false;                
            }
            else
            {                
                FileStream file_stream = new FileStream(image_location, FileMode.Open, FileAccess.Read);
                BinaryReader bynary_reader = new BinaryReader(file_stream);
                image = bynary_reader.ReadBytes((int)file_stream.Length);                
                validate_image_location = true;//se usa en el if de crear producto, sino se cumple pedira al usuario que agregue una imagen sin mostrar una excepción.
            }
        }
        private void Read_image()//esté método se ejecuta cuando se selecciona una celda en el datagrid.
        {
            //image = products.Read_image(int.Parse(TextBox_id.Text));
            //memory_stream = new MemoryStream(image);
            //PictureBox_product.Image = Image.FromStream(memory_stream);
        }
        private void Clear_textboxes()
        {
            TextBox_id.Text = "";
            TextBox_name.Clear();
            TextBox_stock.Clear();
            TextBox_unit_price.Clear();
            PictureBox_product.ImageLocation = null;//para que se pueda validar de nuevo en el método Convert_image y no sobreescriba luego de crear o actualizar el producto.
            PictureBox_product.Image = null;//para que elimine la imagen que se muestra en el form una vez que se crea o actualice el producto.
        }
        private void Button_create_Click(object sender, EventArgs e)
        {
            try
            {
                //método para convertir una imagen a byte[].el método cleartextboxes lo complementa.
                Convert_image();
                //validar si el nombre existe en productos.
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
                //método para convertir una imagen a byte[]. el método cleartextboxes lo complementa.
                Convert_image();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void Button_clear_Click(object sender, EventArgs e)
        {
            Clear_textboxes();
        }
        private void Form_products_Load(object sender, EventArgs e)
        {
            Read();
            TextBox_id.Enabled = false;
            Button_update.Enabled = false;
            Button_delete.Enabled = false;
            PictureBox_product.Image = null;
            TextBox_read_by_name.Select();
        }
        private void Read()
        {
        }

        private void DataGridView_products_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView_products.Rows[e.RowIndex].Cells[0].Value.ToString() == string.Empty)
                {
                    Clear_textboxes();
                    MessageBox.Show("Elija una fila válida.");
                }
                else
                {
                    TextBox_id.Text = DataGridView_products.Rows[e.RowIndex].Cells[0].Value.ToString();                   
                    TextBox_name.Text = DataGridView_products.Rows[e.RowIndex].Cells[1].Value.ToString();
                    TextBox_stock.Text = DataGridView_products.Rows[e.RowIndex].Cells[2].Value.ToString();
                    TextBox_unit_price.Text = DataGridView_products.Rows[e.RowIndex].Cells[3].Value.ToString();
                    Read_image();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        private void TextBox_read_by_name_TextChanged(object sender, EventArgs e)
        {
        }

        private void Button_delete_Click(object sender, EventArgs e)
        {
            try
            {
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_history_Click(object sender, EventArgs e)
        {
            fh = new Form_products_history();
            fh.ShowDialog();
            Read();
        }

        private void TextBox_read_by_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Search_by_letters(TextBox_read_by_name, e);
        }

        private void TextBox_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numbers_only(TextBox_id, e);
        }

        private void TextBox_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Char_only(TextBox_name, e);
        }

        private void TextBox_stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numbers_only(TextBox_stock,e);
        }

        private void TextBox_unit_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.decimal_only(TextBox_unit_price,e);
        }

        private void Button_report_Click(object sender, EventArgs e)
        {

        }
    }
}
