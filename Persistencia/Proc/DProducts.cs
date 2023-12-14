using Dominio.Database;
using Dominio.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using Persistencia.Context;

namespace Persistencia.Proc
{
    public static class DProducts
    {

        public static async Task<List<ProductsDTO>> ListProducts()
        {
         using(var db = new EnsuenoContext())
            {
                var list = await (from p in db.Products
                                  join pc in db.Product_Category on p.ProductCategoryId equals pc.CategoryId
                                 
                                  select new ProductsDTO
                                  {
                                      ProdutId = p.ProdutId,
                                      ProductName = p.ProductName,
                                      CategoryId = p.ProductCategoryId,
                                      Categoria = pc.CategoryName,
                                      Stock = p.Stock,
                                      Purchace_Price = p.Purchase_Price,
                                      Unit_Price = p.Unit_Price,
                                      Estado = (p.IsActive) ? "Disponible":"No Disponible",
                                      Creado = p.Date_Time
                                  }).ToListAsync();
                return list;
            }
        }

        public static async Task<List<ProductsDTO>> SearchProducts(ProductsDTO obj)
        {
            using (var db = new EnsuenoContext())
            {
                var state = (obj.ProductName.Contains("no disponible")) ? false : true; 
                var list = await (from p in db.Products
                                  join pc in db.Product_Category on p.ProductCategoryId equals pc.CategoryId
                             
                                  where (p.ProdutId.ToString().Contains(obj.ProductName) || p.ProductName.Contains(obj.ProductName)
                                  || pc.CategoryName.Contains(obj.ProductName) 
                                  || p.IsActive.Equals(state) || p.Date_Time.ToString().Contains(obj.ProductName))

                                  orderby p.IsActive ascending
                                  select new ProductsDTO
                                  {
                                      ProdutId = p.ProdutId,
                                      ProductName = p.ProductName,
                                      CategoryId = p.ProductCategoryId,
                                      Categoria = pc.CategoryName,
                                      Stock = p.Stock,
                                      Purchace_Price = p.Purchase_Price,
                                      Unit_Price = p.Unit_Price,
                                      Estado = (p.IsActive) ? "Disponible" : "No Disponible",
                                      Creado = p.Date_Time
                                  }).ToListAsync();
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
            catch(Exception e) { string s= e.InnerException.Message; }
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
                        product.ProductCategoryId = obj.ProductCategoryId;
                        product.Stock += obj.Stock;
                        product.Unit_Price = obj.Unit_Price;
                        product.Purchase_Price = obj.Purchase_Price;
                        product.UpdateBy = obj.UpdateBy;
                        product.Update_date_time = obj.Update_date_time;
                        product.IsActive = true;
                        db.Entry(product).State = EntityState.Modified;
                        var query = await db.SaveChangesAsync();

                        var suppl = await db.Suppliers.Where(a => a.SupplierName.Equals(supplier.SupplierName)).FirstOrDefaultAsync();
                        await AddStockMovement(new StockMovement
                        {
                            SupplierId = (supplier.SupplierId.Equals(0) ? suppl.SupplierId : supplier.SupplierId),
                            ProductId = product.ProdutId,
                            Units = obj.Stock,
                            Price = obj.Purchase_Price,
                            EmployeeId = obj.UpdateBy,
                            TypeStockMovement = 1
                        });

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
                        product.ProductCategoryId = (obj.ProductCategoryId.Equals(0)) ? product.ProductCategoryId:obj.ProductCategoryId ;
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
                        await AddStockMovement(new StockMovement
                        {
                            SupplierId = supplier.SupplierId,
                            ProductId = product.ProdutId,
                            Units = product.Stock,
                            EmployeeId = obj.EmployeeId,
                            TypeStockMovement = 2
                        }) ;

                        product.Stock = 0;
                        product.IsActive = false;
                        product.UpdateBy = obj.UpdateBy;
                        product.Update_date_time = obj.Update_date_time;
                        db.Entry(product).State = EntityState.Modified;
                        var query = await db.SaveChangesAsync();
                       
                        var result = (query > 0) ? "Eliminado Correctamente" : "No se pudo Eliminar";
                        return result;
                    }
                    return "Parametro Id no Recibido por el usuario";
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


        //Prcedimientos Category'
        public static string AddCategory(Product_Category obj)
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                   
                        db.Add(obj);
                        var query = db.SaveChanges();
                        var result = (query > 0) ? "Guardado Correctamente" : "No se pudo Guardar";
                        return result;
                }
            }
            catch(Exception ex) {return ex.Message;  }
        }

        public static string UpdateCategory(Product_Category obj)
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    var category = db.Product_Category.Find(obj.CategoryId);

                    if (category != null)
                    {
                        category.CategoryName = obj.CategoryName;
                        category.UpdatedBy = obj.CreatedBy;
                        category.Date_Updated = DateTime.Now;
                        db.Entry(category).State = EntityState.Modified;
                        var query = db.SaveChanges();
                        var result = (query > 0) ? "Guardado Correctamente" : "No se pudo Guardar";
                        return result;
                    }
                    return "No se pudo Guardar";
                }
            }
            catch (Exception ex) { return ex.Message; }
        }

        public static List<CategoryDTO> ListCategory()
        {
            using(var db = new EnsuenoContext())
            {
                var list = (from c in db.Product_Category
                           select new CategoryDTO
                           {
                               Id = c.CategoryId,
                               Nombre = c.CategoryName
                           }).ToList();
                return list;
            }
        }

    }
}