using Aplicacion.ProceduresDB;
using Dominio.Database;
using Dominio.DTO;
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
    public partial class Form_Category : Form
    {
        public Form_Category(Username UserSessions, Color color)
        {
            InitializeComponent();
            this.UserSessions = UserSessions;
            BackColor = color;
        }
        private Username UserSessions;


        private void Read()
        {
            DataGridView_Category.DataSource = ProcProducts.ListCategories();
        }

        private void Add()
        {
            if (!string.IsNullOrEmpty(TextBox_Category.Text))
            {
                var result = ProcProducts.AddCategory(new Product_Category
                {
                    CategoryName = TextBox_Category.Text,
                    CreatedBy = UserSessions.EmployeeId,
                });
                MessageBox.Show(result, "Informmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Read();
            }
        }


        private int CategoryId;
        private void Update()
        {
            if (!string.IsNullOrEmpty(TextBox_Category.Text))
            {
                var result = ProcProducts.UpdateCategory(new Product_Category
                {
                    CategoryId = CategoryId,
                    CategoryName = TextBox_Category.Text,
                    CreatedBy = UserSessions.EmployeeId,
                });
                MessageBox.Show(result, "Informmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Read();
            }
        }


        private void Form_Category_Load(object sender, EventArgs e)
        {
            Read();
        }

        private void Button_create_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void Button_update_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void DataGridView_Category_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(DataGridView_Category.Rows[e.RowIndex].Cells[0].Value.ToString()))
                {
                    TextBox_Category.Clear();
                    Button_create.Enabled = true;
                    Button_update.Enabled = false;
                }
                else
                {
                    CategoryId = int.Parse(DataGridView_Category.Rows[e.RowIndex].Cells[0].Value.ToString());
                    TextBox_Category.Text = DataGridView_Category.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Button_create.Enabled = false;
                    Button_update.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                TextBox_Category.Clear();
                Button_create.Enabled = true;
                Button_update.Enabled = false;
            }
        }
    }
}
