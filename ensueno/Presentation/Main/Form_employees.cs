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
using Aplicacion.ProceduresDB;
using Dominio.Database;
using ensueno.Presentation.Validations;
using Guna.UI2.WinForms;

namespace ensueno.Presentation.Main
{
    public partial class Form_employees : Form
    {
        private readonly ProcEmployees procEmpl = new ProcEmployees();
        private Employees employe;
        readonly Values val = new Values();
        public Form_employees(Color color)
        {
            InitializeComponent();
            this.BackColor = color;
        }
        #region Validaciones
        private void ValidacionesText()
        {
            val.empty_text(TextBox_id);
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
        #endregion

        #region Procedimientos
        private async void Read()
        {
            var result = await procEmpl.GetEmployeeList();
            this.Invoke(new Action(() =>
            {
                DataGridView_employees.DataSource = result;
            }));
        }

        private void SearchEmployee()
        {
            try
            {
                employe = new Employees
                {
                    //EmployeeId = int.Parse(TextBox_SearchEmployee.Text),
                    EmployeeName = TextBox_SearchEmployee.Text,
                    EmployeeLastName = TextBox_SearchEmployee.Text,
                    EmployeeIdentification = TextBox_SearchEmployee.Text,
                    EmployeePhone = TextBox_SearchEmployee.Text,
                    EmployeeAddress = TextBox_SearchEmployee.Text,
                    Email = TextBox_SearchEmployee.Text
                };
                //var result = await procEmpl.SearchEmployee(TextBox_SearchEmployee.Text);
                //this.Invoke(new Action(() =>
                //{
                //    DataGridView_employees.DataSource = result;
                //    DataGridView_employees.Show();
                //}));
                DataGridView_employees.DataSource = procEmpl.SearchEmployee(employe);
            }
            catch { }
        }

        private async void AddEmployee()
        {
            employe = new Employees
            {
                EmployeeName = TextBox_name.Text,
                EmployeeLastName = TextBox_last_name.Text,
                EmployeeIdentification = TextBox_id_card.Text,
                EmployeePhone = TextBox_phone.Text,
                EmployeeAddress = TextBox_address.Text,
                Email = TextBoxEmail.Text,
                Image = image
            };

            if (string.IsNullOrWhiteSpace(TextBox_last_name.Text) || string.IsNullOrWhiteSpace(TextBox_last_name.Text) ||
                string.IsNullOrWhiteSpace(TextBox_id_card.Text) || string.IsNullOrWhiteSpace(TextBox_phone.Text) || string.IsNullOrWhiteSpace(TextBox_address.Text)
                || string.IsNullOrWhiteSpace(TextBoxEmail.Text))
            {
                ValidacionesText();
            }
            else
            {
                if (MessageBox.Show("¿Desea Agregar Este Registro?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var result = await procEmpl.AddEmployee(employe);
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearTextBoxes();
                        Read();
                    }));
                }
            }

        }




        #endregion

        #region Events
        private async void Button_create_Click(object sender, EventArgs e)
        {
               AddEmployee();
        }
        private void TextBox_SearchEmployee_TextChanged(object sender, EventArgs e)
        {
            SearchEmployee();
        }
        private void Button_update_Click(object sender, EventArgs e)
        {

        }
        private void Button_delete_Click(object sender, EventArgs e)
        {

        }
        private void DataGridView_employees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView_employees.Rows[e.RowIndex].Cells[0].Value.ToString() == string.Empty)
                {
                    //Clear_textboxes();
                    MessageBox.Show("Elija una fila válida.");
                }
                else
                {
                    TextBox_id.Text = DataGridView_employees.Rows[e.RowIndex].Cells[0].Value.ToString();
                    TextBox_id_card.Text = DataGridView_employees.Rows[e.RowIndex].Cells[1].Value.ToString();
                    TextBox_name.Text = DataGridView_employees.Rows[e.RowIndex].Cells[2].Value.ToString();
                    TextBox_last_name.Text = DataGridView_employees.Rows[e.RowIndex].Cells[3].Value.ToString();
                    TextBox_phone.Text = DataGridView_employees.Rows[e.RowIndex].Cells[4].Value.ToString();
                    TextBox_address.Text = DataGridView_employees.Rows[e.RowIndex].Cells[5].Value.ToString();
                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_clear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
        private async void Form_employees_Load(object sender, EventArgs e)
        {
            await Task.Run(() => { Read(); });
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

        private void TextBox_address_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.empty_text(TextBox_address);
        }

        private void Button_report_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Agregar Imagen
        private string image_location;
        private byte[] image;
        private MemoryStream memory_stream;
        private bool validate_image_location;
        private void ButtonSubirImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog file_dialog = new OpenFileDialog
            {
                Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*"
            };
            if (file_dialog.ShowDialog() == DialogResult.OK)
            {
                image_location = file_dialog.FileName.ToString();
                PictureBox_product.ImageLocation = image_location;
                Convert_image();
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
                validate_image_location = true;
            }
        }

        #endregion

        
    }
}
