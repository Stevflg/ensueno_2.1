using Dominio.Database;
using Persistencia.Context;
using Persistencia.Proc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ProceduresDB
{
    public static class ProcProducts
    {
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
    }
}
