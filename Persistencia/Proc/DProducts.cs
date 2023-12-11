using Dominio.Database;
using Dominio.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Proc
{
    public static class DProducts
    {

        public static async Task<List<ProductsDTO>> ListProducts()
        {
         using(var db = new EnsuenoContext())
            {
                var list = await (from p in db.Products
                                  join sm in db.StockMovement on p.ProdutId equals sm.ProductId
                                  join s in db.Suppliers on sm.SupplierId equals s.SupplierId
                                  join pc in db.Product_Category on p.ProductCategoryId equals pc.CategoryId
                                  where sm.Date_Time.Equals(db.StockMovement.Max(x => x.Date_Time))
                                  orderby p.IsActive ascending
                                  select new ProductsDTO
                                  {
                                      ProdutId = p.ProdutId,
                                      ProductName = p.ProductName,
                                      Categoria = pc.CategoryName,
                                      Proveedor = s.SupplierName,
                                      Stock = p.Stock,
                                      Purchace_Price = p.Purchase_Price,
                                      Unit_Price = p.Unit_Price,
                                      Estado = (p.IsActive) ? "Disponible":"No Disponible",
                                      Creado = p.Date_Time
                                  }).Distinct().ToListAsync();
                return list;
            }
        }

        public static async Task<List<ProductsDTO>> SearchProducts(ProductsDTO obj)
        {
            using (var db = new EnsuenoContext())
            {
                var state = (obj.ProductName.Equals("Disponible")) ? true : false; 
                var list = await (from p in db.Products
                                  join sm in db.StockMovement on p.ProdutId equals sm.ProductId
                                  join s in db.Suppliers on sm.SupplierId equals s.SupplierId
                                  join pc in db.Product_Category on p.ProductCategoryId equals pc.CategoryId
                                  where sm.Date_Time.Equals(db.StockMovement.Max(x => x.Date_Time))

                                  &&(p.ProdutId.ToString().Contains(obj.ProductName) || p.ProductName.Contains(obj.ProductName)
                                  || pc.CategoryName.Contains(obj.ProductName) || s.SupplierName.Contains(obj.ProductName)
                                  || p.IsActive.Equals(state) || p.Date_Time.ToString().Contains(obj.ProductName))

                                  orderby p.IsActive ascending
                                  select new ProductsDTO
                                  {
                                      ProdutId = p.ProdutId,
                                      ProductName = p.ProductName,
                                      Categoria = pc.CategoryName,
                                      Proveedor = s.SupplierName,
                                      Stock = p.Stock,
                                      Purchace_Price = p.Purchase_Price,
                                      Unit_Price = p.Unit_Price,
                                      Estado = (p.IsActive) ? "Disponible" : "No Disponible",
                                      Creado = p.Date_Time
                                  }).Distinct().ToListAsync();
                return list;
            }
        }

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
                        product.Image = obj.Image ?? product.Image;
                        product.UpdateBy = obj.UpdateBy;
                        product.Update_date_time = obj.Update_date_time;
                        db.Entry(product).State = EntityState.Modified;
                        var query = await db.SaveChangesAsync();
                        
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

        public static async Task<string> Delete(Products obj, Suppliers supplier)
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    var product = await db.Products.FindAsync(obj.ProdutId);
                    if (product != null)
                    {
                        db.Add(new StockMovement
                        {
                            SupplierId = supplier.SupplierId,
                            ProductId = product.ProdutId,
                            Units = product.Stock,
                            EmployeeId = obj.EmployeeId,
                            TypeStockMovement = 2
                        });
                        await db.SaveChangesAsync();

                        product.Stock = 0;
                        product.IsActive = false;
                        product.UpdateBy = obj.UpdateBy;
                        product.Update_date_time = obj.Update_date_time;
                        db.Entry(product).State = EntityState.Modified;
                        var query = await db.SaveChangesAsync();
                       

                        var result = (query > 0) ? "Guardado Correctamente" : "No se pudo Guardar";
                        return result;
                    }
                    return "No se pudo guardar";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }


        //Procedimientos para obtener datos de la db
        public static async Task<List<Product_Category>> ListCategoryP()
        {
            using (var db = new EnsuenoContext())
            {
                var list =await db.Product_Category.Where(a => a.IsActive.Equals(true)).ToListAsync();
                return list;
            }
        }

        public static async Task<List<Suppliers>> ListSuppliers()
        {
            using(var db = new EnsuenoContext())
            {
                var list = await db.Suppliers.Where(a => a.IsActive.Equals(true)).ToListAsync();
                return list;
            }
        }
    }
}