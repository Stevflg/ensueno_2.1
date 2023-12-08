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
using Dominio.DTO;

namespace ensueno.Presentation.Main
{
    public partial class Form_products : Form
    {

        private string image_location;
        private byte[] image;
        private MemoryStream memory_stream;
        readonly Values val = new Values();
        private bool validate_image_location;
        public Form_products(Color color, Username userSessions)
        {
            InitializeComponent();
            this.BackColor = color;
        }

        private async void Form_products_Load(object sender, EventArgs e)
        {

        }




    }
}
