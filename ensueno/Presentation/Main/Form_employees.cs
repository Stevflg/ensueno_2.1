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
using Dominio.DTO;
using ensueno.Presentation.Validations;
using Guna.UI2.WinForms;

namespace ensueno.Presentation.Main
{
    public partial class Form_employees : Form
    {
        private Username userSesions;
        private Employees employe;
        readonly Values val = new Values();
        public Form_employees(Color color, Username user)
        {
            InitializeComponent();
            this.BackColor = color;
            this.userSesions = user;
            this.color = color;
        }
        private Color color;
        private async void Form_employees_Load(object sender, EventArgs e)
        {
            Read();
        }
        #region Validaciones
        private void ValidacionesText()
        {
            //val.empty_text(TextBox_id);
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

        private void TextBox_address_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.empty_text(TextBox_address);
        }
        private void TextBox_name_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_name.Text)) val.ClearError();
            val.ClearError();
        }

        private void TextBox_last_name_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_last_name.Text)) val.ClearError();
            val.ClearError();
        }

        private void TextBox_id_card_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_id_card.Text)) val.ClearError();
            val.ClearError();
        }

        private void TextBox_phone_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_phone.Text)) val.ClearError();
            val.ClearError();
        }

        private void TextBox_address_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_address.Text)) val.ClearError();
            val.ClearError();
        }

        private void TextBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxEmail.Text)) val.ClearError();
            val.ClearError();
        }

        #endregion

        #region Procedimientos
        private async void Read()
        {
            this.Invoke(new Action(() =>
            {
                pictureBoxDark.Visible = true;
            }));
            var result = await ProcEmployees.GetEmployeeList();
            this.Invoke(new Action(() =>
            {
                DataGridView_employees.DataSource = result;
                pictureBoxDark.Visible = false;
            }));
        }

        private async void SearchEmployee()
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    pictureBoxDark.Visible = true;
                    ButtonSearch.Enabled = false;
                    TextBox_SearchEmployee.Enabled = false;
                }));

                employe = new Employees
                {
                    EmployeeName = TextBox_SearchEmployee.Text
                };
                var result = await ProcEmployees.SearchEmployee(employe);
                this.Invoke(new Action(() =>
                {
                    DataGridView_employees.DataSource = result;
                    pictureBoxDark.Visible = false;
                    ButtonSearch.Enabled = true;
                    TextBox_SearchEmployee.Enabled = true;
                }));
            }
            catch { }
        }

        private async void AddEmployee()
        {
            employe = new Employees
            {
                CreatedBy = userSesions.EmployeeId,
                EmployeeName = TextBox_name.Text,
                EmployeeLastName = TextBox_last_name.Text,
                EmployeeIdentification = TextBox_id_card.Text,
                EmployeePhone = TextBox_phone.Text,
                EmployeeAddress = TextBox_address.Text,
                Email = TextBoxEmail.Text,
                Image = image
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
                    var result = await ProcEmployees.AddEmployee(employe);
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearTextBoxes();
                        Read();
                    }));
                }
            }
        }
        private async void DeleteEmployee()
        {
            employe = new Employees
            {
                EmployeeId = employeeId,
                UpdatedBy = userSesions.EmployeeId,
                Date_Updated = DateTime.Now
            };
            var result = await ProcEmployees.DeleteEmployee(employe);
            this.Invoke(new Action(() =>
            {
                MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTextBoxes();
                Read();
            }));
        }
        #endregion

        #region Events
        private async void Button_create_Click(object sender, EventArgs e)
        {
            try
            {
                AddEmployee();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Form_employee_edit epedit;
        private int employeeId;
        private void Button_update_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Form_employee_edit);
                if (frm != null)
                {
                    frm.BringToFront();
                }
                else
                {
                    epedit = new Form_employee_edit(employeeId, userSesions, BackColor);
                    epedit.ShowDialog();
                    Read();
                }
            }
            catch { }
        }
        private async void Button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteEmployee();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void DataGridView_employees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView_employees.Rows[e.RowIndex].Cells[0].Value.ToString() == string.Empty)
                {
                    ClearTextBoxes();
                    MessageBox.Show("Elija una fila válida.");
                }
                else
                {
                    TextBox_id.Text = DataGridView_employees.Rows[e.RowIndex].Cells[0].Value.ToString();
                    employeeId = int.Parse(DataGridView_employees.Rows[e.RowIndex].Cells[0].Value.ToString());
                    TextBox_name.Text = DataGridView_employees.Rows[e.RowIndex].Cells[1].Value.ToString();
                    TextBox_last_name.Text = DataGridView_employees.Rows[e.RowIndex].Cells[2].Value.ToString();
                    TextBox_id_card.Text = DataGridView_employees.Rows[e.RowIndex].Cells[3].Value.ToString();
                    TextBox_phone.Text = DataGridView_employees.Rows[e.RowIndex].Cells[4].Value.ToString();
                    TextBox_address.Text = DataGridView_employees.Rows[e.RowIndex].Cells[5].Value.ToString();
                    TextBoxEmail.Text = DataGridView_employees.Rows[e.RowIndex].Cells[6].Value.ToString();
                }
            }
            catch (Exception ex)
            { }
        }

        private async void ButtonSearch_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { SearchEmployee(); });
        }

        private async void TextBox_SearchEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await Task.Run(() => { SearchEmployee(); });
            }
        }

        private void Button_clear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
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
                if (string.IsNullOrEmpty(TextBox_id.Text)) val.ClearError();
                Button_create.Enabled = true;
                Button_update.Enabled = false;
                Button_delete.Enabled = false;
            }
        }

        private async void TextBox_SearchEmployee_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_SearchEmployee.Text)) await Task.Run(() => Read());
        }

        private async void Button_report_Click(object sender, EventArgs e)
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
