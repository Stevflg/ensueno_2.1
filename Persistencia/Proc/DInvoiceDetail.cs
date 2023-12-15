using Dominio.Database;
using Dominio.DTO;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Persistencia.Proc
{
    public static class DInvoiceDetail
    {
        public static async Task<List<Products>> ListProducts()
        {
            using(var db = new EnsuenoContext())
            {
                var list = await db.Products.Where(a => a.IsActive.Equals(true)).ToListAsync();
                return list;
            }
        }

        public static async Task<Customers> getCustomerName(Invoices invoices)
        {
            try
            {
                using(var db = new EnsuenoContext())
                {
                    var Customer = await (from id in db.Invoices
                                          join c in db.Customers on id.CustomerId equals c.CustomerId
                                          select  c).FirstOrDefaultAsync();
                    return Customer;
                }
            }catch(Exception ex) { return null; }
        }

        public static async Task<List<InvoiceDetailDTO>> ListInvoiceDetail(Invoices invoice)
        {
            using(var db = new EnsuenoContext())
            {
                var list = await (from id in db.Invoices_Detail
                                  join p in db.Products on id.ProductId equals p.ProdutId
                                  where id.IsActive.Equals(true)
                                  select new InvoiceDetailDTO
                                  {
                                     Codigo = p.ProdutId,
                                     Producto = p.ProductName,
                                     Precio = id.Price,
                                     Unidades = id.Units,
                                     SubTotal = Math.Round((id.Price * id.Units),2),
                                     IVA = Math.Round(((id.Price * id.Units) * (decimal)0.15),2),
                                     Total = Math.Round((id.Price * id.Units)- ((id.Price * id.Units) * (decimal)0.15),2)
                                  }).ToListAsync();
                foreach(var item in list)
                {
                    item.Id += 1;
                }


                return list;
            }
        }

        public static async Task AddInvoiceDetail(Invoice_Detail invoiceDt,Username user)
        {
                using(var db = new EnsuenoContext())
                {
                    using(var transaction = db.Database.BeginTransaction())
                    {
                    try
                    {
                        var product = await db.Products.FindAsync(invoiceDt.ProductId);
                        if(product != null)
                        {
                            product.Stock -= invoiceDt.Units;
                            db.Entry(product).State = EntityState.Modified;
                            var stokmov = new StockMovement { 
                                ProductId = product.ProdutId,
                                Units = invoiceDt.Units,
                                Price = invoiceDt.Price,
                                InvoiceId = invoiceDt.InvoiceId,
                                EmployeeId = user.EmployeeId,
                                TypeStockMovement = 3
                            };

                            db.Add(stokmov);
                            db.Add(invoiceDt);
                            var query = await db.SaveChangesAsync();

                        }
                        transaction.Commit();

                    }
                    catch(Exception e)
                    {
                        transaction.Rollback();
                    }
                    }
                }
        }


        public static async Task VoidInvoiceDetail(Invoice_Detail invoiceDt, Username user)
        {
            using (var db = new EnsuenoContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var id = await db.Invoices_Detail.Where(a => a.InvoiceId.Equals(invoiceDt.InvoiceId)
                        && a.ProductId.Equals(invoiceDt.ProductId) && a.IsActive==true).FirstOrDefaultAsync();

                        if (id != null)
                        {
                            id.IsActive = false;
                            db.Entry(id).State = EntityState.Modified;

                            var product = await db.Products.FindAsync(invoiceDt.ProductId);
                            if (product != null)
                            {
                                product.Stock += invoiceDt.Units;
                                db.Entry(product).State = EntityState.Modified;
                                var stokmov = new StockMovement
                                {
                                    ProductId = product.ProdutId,
                                    Units = invoiceDt.Units,
                                    Price = invoiceDt.Price,
                                    InvoiceId = invoiceDt.InvoiceId,
                                    EmployeeId = user.EmployeeId,
                                    TypeStockMovement = 4
                                };

                                db.Add(stokmov);
                                var query = await db.SaveChangesAsync();

                            }
                        }
                        transaction.Commit();

                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }



    }
}
