using Dominio.Database;
using Dominio.DTO;
using Persistencia.Proc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ProceduresDB
{
    public static class ProcSupplier
    {
        public static async Task<string> AddSupplier(Suppliers supplier)
        {
            return await DSupplier.AddSupplier(supplier);
        }

        public static async Task<string> UpdateSupplier(Suppliers supplier)
        {

            return await DSupplier.UpdateSupplier(supplier);
        }

        public static async Task<string> DeleteSupplier(Suppliers supplier)
        {

            return await DSupplier.DeleteSupplier(supplier);
        }

        public static async Task<List<SupplierDTO>> GetListSuppliers()
        {

            return await DSupplier.GetListSuppliers();
        }

        public static async Task<List<SupplierDTO>> SearchSuppliers(Suppliers supplier)
        {

            return await DSupplier.SearchSuppliers(supplier);
        }

        public static async Task<Suppliers> GetSupplier(Suppliers supplier)
        {
            return await DSupplier.GetSupplier(supplier);
        }

    }
}
