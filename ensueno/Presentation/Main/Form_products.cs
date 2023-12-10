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

        #region Datagrids y AutoCompletado
        private void DataGridView_employees_CellClick(object sender, DataGridViewCellEventArgs e)
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
                    ComboBoxSuppliers.ValueMember = "SuppleirId";
                    ComboBoxSuppliers.DisplayMember = "SuppllierName";

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

        }
        private int SupplierId = 0;
        private void ComboBoxSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
