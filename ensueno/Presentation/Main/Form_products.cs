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
using Aplicacion.ProceduresDB;
using Dominio.Database;

namespace ensueno.Presentation.Main
{
    public partial class Form_products : Form
    {
        private readonly Values val = new Values();
        private string image_location;
        private byte[] image;
        private MemoryStream memory_stream;
        private bool validate_image_location;
        private Username userSessions;
        public Form_products(Color color, Username userSessions)
        {
            InitializeComponent();
            this.BackColor = color;
            this.userSessions = userSessions;
        }

        private async void Form_products_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
            LoadCategory();
            LoadSupplier();
        }

        #region Datagrids y AutoCompletado
        private void DataGridView_Products_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private async void LoadCategory()
        {
            try
            {
                var ListCategory = await ProcProducts.ListCategoryP();
                this.Invoke(new Action(() =>
                {
                    ComboBoxCategory.DataSource = ListCategory;
                    ComboBoxCategory.ValueMember = "CategoryId";
                    ComboBoxCategory.DisplayMember = "CategoryName";

                    AutoCompleteStringCollection lst = new AutoCompleteStringCollection();
                    for (int i = 0; i < ListCategory.Count; i++)
                    {
                        lst.Add(ListCategory[i].CategoryName);
                    }
                    ComboBoxCategory.AutoCompleteCustomSource = lst;
                    ComboBoxCategory.AutoCompleteMode = AutoCompleteMode.Suggest;
                    ComboBoxCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
                }));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadSupplier()
        {
            try
            {
                var ListSupplier = await ProcProducts.ListSuppliers();
                this.Invoke(new Action(() =>
                {
                    ComboBoxSuppliers.DataSource = ListSupplier;
                    ComboBoxSuppliers.ValueMember = "SupplierId";
                    ComboBoxSuppliers.DisplayMember = "SupplierName";

                    AutoCompleteStringCollection lst = new AutoCompleteStringCollection();
                    for (int i = 0; i < ListSupplier.Count; i++)
                    {
                        lst.Add(ListSupplier[i].SupplierName);
                    }
                    ComboBoxSuppliers.AutoCompleteCustomSource = lst;
                    ComboBoxSuppliers.AutoCompleteMode = AutoCompleteMode.Suggest;
                    ComboBoxSuppliers.AutoCompleteSource = AutoCompleteSource.ListItems;
                }));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ProductCategory = 0;
        private void ComboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ProductCategory = int.Parse(ComboBoxCategory.SelectedValue.ToString());
            }
            catch { }
        }
        private int SupplierId = 0;
        private void ComboBoxSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SupplierId = int.Parse(ComboBoxSuppliers.SelectedValue.ToString());
            }
            catch { }
        }
        #endregion

        #region Validations
        private void TextBox_Product_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Char_only(TextBox_Product, e);
        }

        private void TextBoxStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numbers_only(TextBoxStock, e);
        }

        private void TextBox_Product_TextChanged(object sender, EventArgs e)
        {
            val.ClearError();
        }

        private void TextBoxStock_TextChanged(object sender, EventArgs e)
        {
            val.ClearError();
        }

        private void TextBoxPurchase_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.decimal_only(TextBoxPurchase_Price, e);
        }

        private void TextBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.decimal_only(TextBoxPrice, e);
        }

        private void TextBoxPurchase_Price_TextChanged(object sender, EventArgs e)
        {
            val.ClearError();
        }

        private void TextBoxPrice_TextChanged(object sender, EventArgs e)
        {
            val.ClearError();
        }

        private void ClearTextBoxes()
        {
            TextBox_Id.Clear();
            TextBox_Product.Clear();
            TextBoxStock.Clear();
            TextBoxPurchase_Price.Clear();
        }

        #endregion

        #region Metodos
        private int productId = 0;
        private async void LoadDataGrid()
        {
            this.Invoke(new Action(() => { pictureBoxDark.Visible = true; }));
            var list = await ProcProducts.ListProducts();

            this.Invoke(new Action(() =>
            {
                DataGridView_Products.DataSource = list;
                pictureBoxDark.Visible = false;
            }));
        }

        private async void AddProducts()
        {
            if (!string.IsNullOrEmpty(TextBox_Product.Text) && !string.IsNullOrEmpty(TextBoxStock.Text) && !string.IsNullOrEmpty(TextBoxPurchase_Price.Text)
                && !string.IsNullOrEmpty(TextBoxPrice.Text))
            {
                this.Invoke(new Action(() => {
                    pictureBoxDark.Visible = true;
                }));
                var result = await ProcProducts.AddProducts(new Products
                {
                    ProductName = TextBox_Product.Text,
                    ProductCategoryId = ProductCategory,
                    Stock = int.Parse(TextBoxStock.Text),
                    Purchase_Price = decimal.Parse(TextBoxPurchase_Price.Text),
                    Unit_Price = decimal.Parse(TextBoxPrice.Text),
                    EmployeeId = userSessions.EmployeeId,
                    Image = image
                }, new Suppliers { SupplierId = SupplierId });

                this.Invoke(new Action(() => {
                    pictureBoxDark.Visible = false;
                    LoadDataGrid();
                }));
            }
        }


        #endregion

        #region Procedimientos lectura de imagen 
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

        private void Button_clear_Click(object sender, EventArgs e)
        {

        }

    }
}
