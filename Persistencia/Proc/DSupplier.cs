using Dominio.Database;
using Dominio.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Proc
{
    public static class DSupplier
    {
        public static async Task<string> AddSupplier(Suppliers supplier)
        {
            try
            {
               using (var context = new EnsuenoContext())
                {
                    context.Suppliers.Add(supplier);
                    var query = await context.SaveChangesAsync();
                    var result = (query > 0) ? "Guardado Correctamente" : "No se pudo Guardar";
                    return result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static async Task<string> UpdateSupplier(Suppliers supplier)
        {
            try
            {
                using(var context = new EnsuenoContext())
                {
                    var suppli = await context.Suppliers.FindAsync(supplier.SupplierId);
                    if (supplier != null)
                    {
                        suppli.SupplierName = supplier.SupplierName;
                        suppli.SupplierAddress = supplier.SupplierAddress;
                        suppli.SupplierRUC = supplier.SupplierRUC;
                        suppli.SupplierPhone = supplier.SupplierPhone;
                        suppli.SupplierEmail = supplier.SupplierEmail;
                        suppli.UpdateBy = supplier.UpdateBy;
                        suppli.Date_Updated = suppli.Date_Updated;
                        context.Entry(suppli).State = EntityState.Modified;
                        var query = await context.SaveChangesAsync();
                        var result = (query > 0) ? "Eliminado Correctamente" : "No se pudo Eliminar";
                        return result;
                    }
                    return "No se pudo Eliminar";
                }
            }
            catch
            (Exception ex)
            { return ex.Message; }
        }
        public static async Task<string> DeleteSupplier(Suppliers supplier)
        {
            try
            {
                using (var context = new EnsuenoContext())
                {
                    var suppli = await context.Suppliers.FindAsync(supplier.SupplierId);
                    if (supplier != null)
                    {
                        suppli.IsActive = false;
                        suppli.UpdateBy = supplier.UpdateBy;
                        suppli.Date_Updated = suppli.Date_Updated;
                        context.Entry(suppli).State = EntityState.Modified;
                        var query = await context.SaveChangesAsync();
                        var result = (query > 0) ? "Guardado Correctamente" : "No se pudo Guardar";
                        return result;
                    }
                    return "No se pudo Guardar";
                } 
            }
            catch (Exception ex) { return ex.Message; }
        }
        public static async Task<List<SupplierDTO>> GetListSuppliers()
        {
            try
            {
               using(var context = new EnsuenoContext())
                {
                    var supplierList = await (from s in context.Suppliers
                                              where s.IsActive == true
                                              select new SupplierDTO
                                              {
                                                  Id = s.SupplierId,
                                                  Proveedor = s.SupplierName,
                                                  Direccion = s.SupplierAddress,
                                                  RUC = s.SupplierRUC,
                                                  Telefono = s.SupplierPhone,
                                                  Email = s.SupplierEmail,
                                                  Creado = s.Date_Time
                                              }).ToListAsync();
                    return supplierList;
                }
            }
            catch
            {
                return null;
            }
        }
        public static async Task<List<SupplierDTO>> SearchSuppliers(Suppliers supplier)
        {
            try
            {
                using(var context = new EnsuenoContext())
                {
                    var supplierList = await (from s in context.Suppliers
                                              where (
                                                s.SupplierId.ToString().Contains(supplier.SupplierName) ||
                                                s.SupplierName.Contains(supplier.SupplierName) ||
                                                s.SupplierAddress.Contains(supplier.SupplierAddress) ||
                                                s.SupplierRUC.Contains(supplier.SupplierRUC) ||
                                                s.SupplierPhone.Contains(supplier.SupplierPhone) ||
                                                s.SupplierEmail.Contains(supplier.SupplierEmail)
                                              ) && s.IsActive.Equals(true)
                                              select new SupplierDTO
                                              {
                                                  Id = s.SupplierId,
                                                  Proveedor = s.SupplierName,
                                                  Direccion = s.SupplierAddress,
                                                  RUC = supplier.SupplierRUC,
                                                  Telefono = supplier.SupplierPhone,
                                                  Email = supplier.SupplierEmail,
                                                  Creado = supplier.Date_Time
                                              }
                                          ).ToListAsync();
                    return supplierList;
                }
            }
            catch
            {
                return null;
            }
        }
        public static async Task<Suppliers> GetSupplier(Suppliers supplier)
        {
            try
            {
                using (var context = new EnsuenoContext())
                {
                    var suppli = await context.Suppliers.FindAsync(supplier.SupplierId);
                    return suppli;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}