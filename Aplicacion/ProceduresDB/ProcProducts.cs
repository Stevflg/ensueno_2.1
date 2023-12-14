using Dominio.Database;
using Dominio.DTO;
using Persistencia.Proc;

namespace Aplicacion.ProceduresDB
{
    public static class ProcProducts
    {
        public static async Task<List<ProductsDTO>> ListProducts()
        {
            return await DProducts.ListProducts();
        }

        public static async Task<List<ProductsDTO>> SearchProducts(ProductsDTO obj)
        {
            return await DProducts.SearchProducts(obj);
        }

        public static async Task<List<Product_Category>> ListCategoryP()
        {
            return await DProducts.ListCategoryP();
        }

        public static async Task<List<Suppliers>> ListSuppliers()
        {
           return await DProducts.ListSuppliers();
        }

        public static async Task<string> AddProducts(Products obj, Suppliers supplier)
        {
            return await DProducts.AddProducts(obj, supplier);
        }

        public static async Task<string> UpdateStockProducts(Products obj, Suppliers supplier)
        {
            return await DProducts.UpdateStockProducts(obj, supplier);
        }

        public static async Task<string> UpdateProducts(Products obj, Suppliers supplier)
        {
            return await DProducts.UpdateProducts(obj, supplier);
        }

        public static async Task<string> Delete(Products obj, Suppliers supplier)
        {
            return await DProducts.Delete(obj, supplier);
        }


        public static string AddCategory(Product_Category obj)
        {
            return DProducts.AddCategory(obj);
        }

        public static string UpdateCategory(Product_Category obj)
        {
            return DProducts.UpdateCategory(obj);
        }

        public static List<CategoryDTO> ListCategories()
        { 
            return DProducts.ListCategory();
        }
    }
}