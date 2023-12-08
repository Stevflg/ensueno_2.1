using Dominio.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Proc
{
    public static class DProducts
    {
        public static async Task<string> AddProducts(Products obj,Suppliers supplier)
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    db.Add(obj);
                    var query = await db.SaveChangesAsync();

                    db.Add(new StockMovement{SupplierId = supplier.SupplierId,
                        ProductId = obj.ProdutId,
                        Units=obj.Stock,
                        EmployeeId = obj.EmployeeId
                    });
                    await db.SaveChangesAsync();

                    var result = (query > 0) ? "Guardado Correctamente" : "No se pudo Guardar";
                    return result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static async Task <string> UpdateProducts(Products obj, Suppliers supplier)
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    var product = await db.Products.FindAsync(obj.ProdutId);
                    if(product != null)
                    {
                        product.ProductName=obj.ProductName;
                        product.ProductCategoryId =obj.ProductCategoryId;
                        product.ProductCategoryId = obj.ProductCategoryId;
                        product.Stock += obj.Stock;
                        product.Unit_Price = obj.Unit_Price;
                        product.Image = obj.Image ?? product.Image;
                        product.UpdateBy = obj.UpdateBy;
                        product.Update_date_time = obj.Update_date_time;
                         db.Entry(product).State = EntityState.Modified;
                        var query = await db.SaveChangesAsync();
                        db.Add(new StockMovement
                        {
                            SupplierId = supplier.SupplierId,
                            ProductId = obj.ProdutId,
                            Units = obj.Stock,
                            EmployeeId = obj.EmployeeId
                        });
                        await db.SaveChangesAsync();

                        var result = (query>0) ? "Guardado Correctamente" : "No se pudo Guardar";
                        return result;
                    }
                    return "No se pudo guardar";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}