﻿using Aplicacion.ProceduresDB;
using Dominio.Database;
using Dominio.DTO;
using ensueno.Presentation.Validations;
using ensueno.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ensueno.Presentation.Main
{
    public partial class Form_employee_edit : Form
    {
        private Username UserSesion;
        public Form_employee_edit(int employeeid, Username userSesions, Color color)
        {
            InitializeComponent();
            this.EmployeeId = employeeid;
            this.UserSesion = userSesions;
            this.BackColor = color;
        }

        #region Carga de los datos
        private int EmployeeId;
        private async void LoadDataEmployee(int employeeId)
        {
            this.Invoke(new Action(() =>
            {
                pictureBoxLoadData.Visible = true;
            }));
            
            Employees employee = new Employees { EmployeeId = employeeId };
            var result = await ProcEmployees.GetEmployeebyFormEdit(employee);
            this.Invoke(new Action(() =>
            {
                TextBox_id.Text = result.EmployeeId.ToString();
                TextBox_name.Text = (!result.EmployeeName.Equals(" "))? result.EmployeeName:string.Empty;
                TextBox_last_name.Text = (!result.EmployeeLastName.Equals(" "))? result.EmployeeName:string.Empty;
                TextBox_id_card.Text = (!result.EmployeeIdentification.Equals(" ")) ? result.EmployeeIdentification : string.Empty;
                TextBox_phone.Text = (!result.EmployeePhone.Equals(" ")) ? result.EmployeePhone : string.Empty;
                TextBox_address.Text = (!result.EmployeeAddress.Equals(" ")) ? result.EmployeeAddress : string.Empty;
                TextBoxEmail.Text = (!result.Email.Equals(" ")) ? result.Email : string.Empty;
                image = result.Image;
                Read_image();
                pictureBoxLoadData.Visible = false;
            }));
        }
        #endregion

        readonly Values val = new Values();
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
        //Metodo para guardar cambios
        private async void saveChanges()
        {
            Convert_image();
            Employees employee = new Employees
            {
                EmployeeId = EmployeeId,
                EmployeeName = TextBox_name.Text,
                EmployeeLastName = TextBox_last_name.Text,
                EmployeeIdentification = TextBox_id_card.Text,
                EmployeePhone = TextBox_phone.Text,
                EmployeeAddress = TextBox_address.Text,
                Email = TextBoxEmail.Text,
                Image = image,
                UpdatedBy = UserSesion.EmployeeId,
                Date_Updated = DateTime.Now,
            };
            if (string.IsNullOrWhiteSpace(TextBox_last_name.Text) || string.IsNullOrWhiteSpace(TextBox_last_name.Text) ||
               string.IsNullOrWhiteSpace(TextBox_id_card.Text) || string.IsNullOrWhiteSpace(TextBox_phone.Text) || string.IsNullOrWhiteSpace(TextBox_address.Text)
               || string.IsNullOrWhiteSpace(TextBoxEmail.Text))
            {

                ValidacionesText();
            }
            else
            {
                if (MessageBox.Show("¿Desea Guardar Cambios?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var result = await ProcEmployees.EditEmployee(employee);
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }));
                }
            }

        }

        #region Eventos
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void Form_employee_edit_Load(object sender, EventArgs e)
        {
            await Task.Run(() => { LoadDataEmployee(EmployeeId); });
        }
        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            saveChanges();
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
                PictureBox_Employee.ImageLocation = image_location;
                Convert_image();
            }
        }
        private void Read_image()
        {
            if (image != null)
            {
                memory_stream = new MemoryStream(image);
                PictureBox_Employee.Image = Image.FromStream(memory_stream);
            }
            else
            {
                PictureBox_Employee.Image = Resources.error;
            }
        }

        private void Convert_image()
        {
            if (PictureBox_Employee.ImageLocation == null)
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

        #region Validaciones
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
