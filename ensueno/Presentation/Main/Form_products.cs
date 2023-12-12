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
            Read();
            LoadCategory();
            LoadSupplier();
        }

        #region Datagrids y AutoCompletado
        private string SupplierName = "";
        private void DataGridView_Products_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(DataGridView_Products.Rows[e.RowIndex].Cells[0].Value.ToString()))
                {
                    ClearTextBoxes();
                }
                else
                {
                    TextBox_Id.Text = DataGridView_Products.Rows[e.RowIndex].Cells[0].Value.ToString();
                    TextBox_Product.Text = DataGridView_Products.Rows[e.RowIndex].Cells[1].Value.ToString();
                    ComboBoxCategory.Text = DataGridView_Products.Rows[e.RowIndex].Cells[2].Value.ToString();
                    ComboBoxSuppliers.Text = DataGridView_Products.Rows[e.RowIndex].Cells[3].Value.ToString();
                    SupplierName = DataGridView_Products.Rows[e.RowIndex].Cells[3].Value.ToString();
                    TextBoxStock.Text = DataGridView_Products.Rows[e.RowIndex].Cells[4].Value.ToString();
                    TextBoxPurchase_Price.Text = DataGridView_Products.Rows[e.RowIndex].Cells[5].Value.ToString();
                    TextBoxPrice.Text = DataGridView_Products.Rows[e.RowIndex].Cells[6].Value.ToString();
                    productId = 0;
                    SupplierId = 0;
                }
            }
            catch (Exception ex)
            { }
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
            if (string.IsNullOrEmpty(TextBox_Product.Text)) val.ClearError();
            val.ClearError();
        }

        private void TextBoxStock_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TextBoxStock.Text)) val.ClearError();
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
            if (string.IsNullOrEmpty(TextBoxPurchase_Price.Text)) val.ClearError();
            val.ClearError();
        }

        private void TextBoxPrice_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxPrice.Text)) val.ClearError();
            val.ClearError();
        }
        private void validateTextBox()
        {
            val.empty_text(TextBox_Product);
            val.empty_text(TextBoxStock);
            val.empty_text(TextBoxPurchase_Price);
            val.empty_text(TextBoxPrice);
        }

        private void ClearTextBoxes()
        {
            TextBox_Id.Clear();
            TextBox_Product.Clear();
            TextBoxStock.Clear();
            TextBoxPurchase_Price.Clear();
            TextBoxPrice.Clear();
            SupplierId = 0;
            ProductCategory = 0;
            SupplierName = string.Empty;
        }
        #endregion


        #region Metodos
        private int productId = 0;
        private async void Read()
        {
            this.Invoke(new Action(() => { pictureBoxDark.Visible = true; }));
            var list = await ProcProducts.ListProducts();

            this.Invoke(new Action(() =>
            {
                DataGridView_Products.DataSource = list;
                DataGridView_Products.Columns[0].HeaderText = "Id";
                DataGridView_Products.Columns[1].HeaderText = "Insumo";
                DataGridView_Products.Columns[5].HeaderText = "Precio de Compra";
                DataGridView_Products.Columns[6].HeaderText = "Precio de Venta";
                pictureBoxDark.Visible = false;
            }));
        }

        private async void AddProducts()
        {
            try
            {
                if (!string.IsNullOrEmpty(TextBox_Product.Text) && !string.IsNullOrEmpty(TextBoxStock.Text) && !string.IsNullOrEmpty(TextBoxPurchase_Price.Text)
               && !string.IsNullOrEmpty(TextBoxPrice.Text))
                {
                    this.Invoke(new Action(() =>
                    {
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

                    this.Invoke(new Action(() =>
                    {
                        ClearTextBoxes();
                        pictureBoxDark.Visible = false;
                        Read();
                    }));
                }
                else
                {
                    validateTextBox();
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private async void UpdateProducts()
        {
            try
            {
                if (!string.IsNullOrEmpty(TextBox_Id.Text) && !string.IsNullOrEmpty(TextBox_Product.Text) && !string.IsNullOrEmpty(TextBoxStock.Text) && !string.IsNullOrEmpty(TextBoxPurchase_Price.Text)
               && !string.IsNullOrEmpty(TextBoxPrice.Text))
                {
                    this.Invoke(new Action(() =>
                    {
                        pictureBoxDark.Visible = true;
                    }));
                    var result = await ProcProducts.UpdateProducts(new Products
                    {
                        ProdutId = int.Parse(TextBox_Id.Text),
                        ProductName = TextBox_Product.Text,
                        ProductCategoryId = ProductCategory,
                        Stock = int.Parse(TextBoxStock.Text),
                        Unit_Price = decimal.Parse(TextBoxPrice.Text),
                        UpdateBy = userSessions.EmployeeId,
                        Update_date_time = DateTime.Now,
                        Image = image
                    }, new Suppliers { SupplierId = SupplierId, SupplierName = SupplierName });

                    this.Invoke(new Action(() =>
                    {
                        ClearTextBoxes();
                        pictureBoxDark.Visible = false;
                        Read();
                    }));
                }
                else
                {
                    validateTextBox();
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async void UpdateStockProducts()
        {
            try
            {

                if (!string.IsNullOrEmpty(TextBox_Id.Text) && !string.IsNullOrEmpty(TextBox_Product.Text) && !string.IsNullOrEmpty(TextBoxStock.Text) && !string.IsNullOrEmpty(TextBoxPurchase_Price.Text)
                    && !string.IsNullOrEmpty(TextBoxPrice.Text))
                {
                    this.Invoke(new Action(() =>
                    {
                        pictureBoxDark.Visible = true;
                    }));
                    var result = await ProcProducts.UpdateStockProducts(new Products
                    {
                        ProdutId = int.Parse(TextBox_Id.Text),
                        ProductName = TextBox_Product.Text,
                        ProductCategoryId = productId,
                        Stock = int.Parse(TextBoxStock.Text),
                        Purchase_Price = decimal.Parse(TextBoxPurchase_Price.Text),
                        Unit_Price = decimal.Parse(TextBoxPrice.Text),
                        UpdateBy = userSessions.EmployeeId,
                        Update_date_time = DateTime.Now,
                        Image = image
                    }, new Suppliers { SupplierId = SupplierId, SupplierName = SupplierName });

                    this.Invoke(new Action(() =>
                    {
                        ClearTextBoxes();
                        pictureBoxDark.Visible = false;
                        Read();
                    }));
                }
                else
                {
                    validateTextBox();
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private async void DeleteProducts()
        {
            try
            {
                if (!string.IsNullOrEmpty(TextBox_Id.Text))
                {
                    this.Invoke(new Action(() =>
                    {
                        pictureBoxDark.Visible = true;
                    }));
                    var result = await ProcProducts.Delete(new Products
                    {
                        ProdutId = int.Parse(TextBox_Id.Text),
                    }, new Suppliers { SupplierName = SupplierName });

                    this.Invoke(new Action(() =>
                    {
                        ClearTextBoxes();
                        pictureBoxDark.Visible = false;
                        Read();
                    }));
                }
                else
                {
                    validateTextBox();
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async void SearchProduct()
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    pictureBoxDark.Visible = true;
                    ButtonSearch.Enabled = false;
                    TextBox_SearchProduct.Enabled = false;
                }));
                var result = await ProcProducts.SearchProducts(new ProductsDTO { ProductName = TextBox_SearchProduct.Text });
                this.Invoke(new Action(() =>
                {
                    DataGridView_Products.DataSource = result;
                    pictureBoxDark.Visible = false;
                    ButtonSearch.Enabled = true;
                    TextBox_SearchProduct.Enabled = true;
                }));
            }
            catch { }
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
            ClearTextBoxes();
        }

        private async void ButtonSearch_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { SearchProduct(); });
        }

        private async void TextBox_SearchProduct_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_SearchProduct.Text)) await Task.Run(() => Read());
        }

        private async void TextBox_SearchProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await Task.Run(() => { SearchProduct(); });
            }
        }
    }
}
