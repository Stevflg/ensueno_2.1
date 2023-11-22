using Aplicacion.ProceduresDB;
using Dominio.Database;
using ensueno.Properties;
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
    public partial class Form_employee_edit : Form
    {
        public Form_employee_edit(int employeeid)
        {
            InitializeComponent();
            this.EmployeeId = employeeid;
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
            ProcEmployees procEmployees = new ProcEmployees();
            var result = await procEmployees.GetEmployeebyFormEdit(employee);
            this.Invoke((Action)(() =>
            {
                TextBox_id.Text = result.EmployeeId.ToString();
                TextBox_name.Text = result.EmployeeName;
                TextBox_last_name.Text = result.EmployeeLastName;
                TextBox_id_card.Text = result.EmployeeIdentification;
                TextBox_phone.Text = result.EmployeePhone;
                TextBox_address.Text = result.EmployeeAddress;
                TextBoxEmail.Text = result.Email;
                image = result.Image;
                Read_image();
                pictureBoxLoadData.Visible=false;
            }));
        }
        #endregion
        #region Eventos
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void Form_employee_edit_Load(object sender, EventArgs e)
        {
            await Task.Run(() => { LoadDataEmployee(EmployeeId); });
        }

        private void ButtonSave_Click(object sender, EventArgs e)
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
    }
}
