using Dominio.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
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

                    var stock = new StockMovement
                    {
                        SupplierId = supplier.SupplierId,
                        ProductId = obj.ProdutId,
                        Units = obj.Stock,
                        Price = obj.Purchase_Price,
                        EmployeeId = obj.EmployeeId,
                        TypeStockMovement = 1
                    };

                    await AddStockMovement(stock);

                    var result = (query > 0) ? "Guardado Correctamente" : "No se pudo Guardar";
                    return result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static async Task AddStockMovement(StockMovement stockmov)
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    db.Add(stockmov);
                    await db.SaveChangesAsync();
                }
            }
            catch { }
        }

        public static async Task <string> UpdateStockProducts(Products obj, Suppliers supplier)
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    var product = await db.Products.FindAsync(obj.ProdutId);
                    if(product != null)
                    {
                        product.Stock += obj.Stock;
                        product.Unit_Price = obj.Unit_Price;
                        product.Purchase_Price = obj.Purchase_Price;
                        product.UpdateBy = obj.UpdateBy;
                        product.Update_date_time = obj.Update_date_time;
                        db.Entry(product).State = EntityState.Modified;
                        var query = await db.SaveChangesAsync();
                        db.Add(new StockMovement
                        {
                            SupplierId = supplier.SupplierId,
                            ProductId = obj.ProdutId,
                            Units = obj.Stock,
                            EmployeeId = obj.UpdateBy,
                            TypeStockMovement = 1
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

        public static async Task<string> UpdateProducts(Products obj, Suppliers supplier)
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    var product = await db.Products.FindAsync(obj.ProdutId);
                    if (product != null)
                    {
                        product.ProductName = obj.ProductName;
                        product.ProductCategoryId = obj.ProductCategoryId;
                        product.Unit_Price = obj.Unit_Price;
                        product.Purchase_Price = obj.Purchase_Price;
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
                            EmployeeId = obj.EmployeeId,
                            TypeStockMovement = 1
                        });
                        await db.SaveChangesAsync();

                        var result = (query > 0) ? "Guardado Correctamente" : "No se pudo Guardar";
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



        //Procedimientos para obtener datos de la db
        public static async Task<List<Product_Category>> ListCategoryP()
        {
            using (var db = new EnsuenoContext())
            {
                var list =await db.Product_Category.ToListAsync();
                return list;
            }
        }

        public static async Task<List<Suppliers>> ListSuppliers()
        {
            using(var db = new EnsuenoContext())
            {
                var list = await db.Suppliers.ToListAsync();
                return list;
            }
        }
    }
}