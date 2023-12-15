using Dominio.Database;
using Dominio.DTO;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Persistencia.Proc
{
    public static class DInvoice
    {

        public static async Task<List<CustomerDTO>> ListCustomers()
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    var customers = await (from c in db.Customers
                                           where c.IsActive == true
                                           select new CustomerDTO
                                           {
                                               Id = c.CustomerId,
                                               Nombres = c.CustomerName+ " " +c.CustomerLastName,
                                               Cedula = c.CustomerIdentification,
                                               Direccion = c.CustomerAddress,
                                               Telefono = c.CustomerPhone,
                                               Correo = c.Email,
                                               Creado = c.Date_Time
                                           }).ToListAsync();
                    return customers;
                }
            }
            catch { return null; }
        }



        public static async Task<List<InvoiceDTO>> ListInvoice()
        {
            using(var db = new EnsuenoContext())
            {
                var list = await (from i in db.Invoices
                                  join e in db.Employees on i.EmployeeId equals e.EmployeeId
                                  join c in db.Customers on i.CustomerId equals c.CustomerId
                                  where i.IsActive.Equals(true)
                                  select new InvoiceDTO
                                  {
                                      Id = i.InvoiceId,
                                      Empleado = e.EmployeeName + " "+e.EmployeeLastName,
                                      Cliente = c.CustomerName+ " "+c.CustomerLastName,
                                      Creado = i.Date_Time
                                  }).ToListAsync();
                return list;
            }
        }

        public static async Task<List<InvoiceDTO>> SearchInvoice(string obj)
        {
            using (var db = new EnsuenoContext())
            {
                var list = await (from i in db.Invoices
                                  join e in db.Employees on i.EmployeeId equals e.EmployeeId
                                  join c in db.Customers on i.CustomerId equals c.CustomerId
                                  where (i.IsActive.ToString().Contains(obj) || e.EmployeeName.Contains(obj)
                                  || e.EmployeeLastName.Contains(obj) || c.CustomerName.Contains(obj)
                                  || c.CustomerLastName.Contains(obj))&&
                                  i.IsActive.Equals(true)
                                  select new InvoiceDTO
                                  {
                                      Id = i.InvoiceId,
                                      Empleado = e.EmployeeName + " " + e.EmployeeLastName,
                                      Cliente = c.CustomerName + " " + c.CustomerLastName,
                                      Creado = i.Date_Time
                                  }).ToListAsync();
                return list;
            }
        }

        public static async Task<Invoices> AddInvoice(Invoices invoice)
        {
            try
            {
                using(var db = new EnsuenoContext())
                {
                    db.Add(invoice);
                   await db.SaveChangesAsync();
                    return invoice;
                }
            }catch
            {
                return null;
            }
        }

        public static async Task<string> VoidInvoice(Invoices invoices)
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    var invoice = await db.Invoices.FindAsync(invoices.InvoiceId);
                    if(invoice != null) {

                        invoice.UpdateBy = invoices.UpdateBy;
                        invoice.UpdateDate = invoices.UpdateDate;
                        invoice.IsActive = false;
                        db.Entry(invoice).State = EntityState.Modified;
                        var query = await db.SaveChangesAsync();
                        var result = await VoidInvoiceDetail(invoice);
                        return result;
                    }
                    return "No se pudo anular";
                }
            }
            catch(Exception ex) { return ex.Message; }
        }

        private static async Task<string> VoidInvoiceDetail(Invoices invoice)
        {
                using(var db = new EnsuenoContext())
                {
                    using (var transactions = db.Database.BeginTransaction())
                    {
                    try
                    {
                        List<Invoice_Detail> list = await (from id in db.Invoices_Detail
                                                           join i in db.Invoices on id.InvoiceId equals i.InvoiceId
                                                           where id.InvoiceId.Equals(invoice.InvoiceId) &&
                                                           id.IsActive.Equals(true)
                                                           select id).ToListAsync();
                        List<StockMovement> sm = new List<StockMovement>();
                        List<Products> products = new List<Products>();
                        if (list != null)
                        {
                            foreach (var item in list)
                            {
                                sm.Add(new StockMovement
                                {
                                    InvoiceId = item.InvoiceId,
                                    ProductId = item.ProductId,
                                    Units = item.Units,
                                    Price = item.Price,
                                    EmployeeId = invoice.UpdateBy,
                                    TypeStockMovement = 4
                                });
                                var p = await db.Products.FindAsync(item.ProductId);
                                p.Stock += item.Units;
                                products.Add(p);
                                item.IsActive = false;
                            }
                        }
                        db.AddRange(sm);
                        var query = await db.SaveChangesAsync();
                        transactions.Commit();
                        var result = (query>0)? "Anulacion Correcta":"No se pudo anular";
                        return result;
                    }
                    catch (Exception ex)
                    {
                        transactions.Rollback();
                        return ex.Message;
                    }                
                    }
                    
                }

        }
    }
}
