using Dominio.Database;
using Dominio.DTO;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ProceduresDB
{
    public class ProcCustomers
    {
        private readonly EnsuenoContext db;
         public ProcCustomers() { 
            this.db = new EnsuenoContext();
        }
        public async Task<List<CustomerDTO>> ListCustomers()
        {
            try
            {
                var customers = await (from c in db.Customers
                                       where c.IsActive == true
                                       select new CustomerDTO
                                       {
                                           Id = c.CustomerId,
                                           Nombres = c.CustomerName,
                                           Apellidos = c.CustomerLastName,
                                           Cedula = c.CustomerIdentification,
                                           Direccion = c.CustomerAddress,
                                           Telefono = c.CustomerPhone,
                                           Correo = c.Email,
                                           Creado = c.Date_Time
                                       }).ToListAsync();
                return customers;
            }
            catch { return null; }
        }
        public async Task<List<CustomerDTO>> SearchCustomers(Customers obj)
        {
            try
            {
                var customers = await (from c in db.Customers
                                       where (
                                       c.CustomerId.ToString().Contains(obj.CustomerName) ||
                                       c.CustomerName.Contains(obj.CustomerName)||
                                       c.CustomerLastName.Contains(obj.CustomerName) ||
                                       c.CustomerIdentification.Contains(obj.CustomerName) ||
                                       c.CustomerPhone.Contains(obj.CustomerName) ||
                                       c.CustomerAddress.Contains(obj.CustomerName) ||
                                       c.Email.Contains(obj.CustomerName)
                                       )
                                       && c.IsActive== true
                                       select new CustomerDTO
                                       {
                                           Id = c.CustomerId,
                                           Nombres = c.CustomerName,
                                           Apellidos = c.CustomerLastName,
                                           Cedula = c.CustomerIdentification,
                                           Direccion = c.CustomerAddress,
                                           Telefono = c.CustomerPhone,
                                           Correo = c.Email,
                                           Creado = c.Date_Time
                                       }).ToListAsync();
                return customers;
            }
            catch
            {
                return null;
            }
        }
        public async Task<string> AddCustomer(Customers customer)
        {
            try
            {
                db.Add(customer);
                var query = await db.SaveChangesAsync();
                if (query > 0)
                {
                    return "Guardado Correctamente";
                }
                return "No se pudo guardar";
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }
        public async Task<string> DeleteCustomer(Customers obj)
        {
            try
            {
                var customers = await db.Employees.FindAsync(obj.CustomerId);
                if (customers != null)
                {
                    customers.IsActive = false;
                    customers.UpdatedBy = obj.UpdateBy;
                    customers.Date_Updated = obj.Update_date_time;
                    db.Entry(customers).State = EntityState.Modified;
                    var result = await db.SaveChangesAsync();
                    if (result > 0)
                    {
                        return "Eliminado Correctamente";
                    }
                    return "No se pudo Eliminar";
                }
                return "Registro no existe";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<Customers> GetCustomerByEdit(Customers obj)
        {
            try
            {
                var customer = await db.Customers.FindAsync(obj.CustomerId);
                return customer;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> EditCustomer(Customers obj)
        {
            try
            {
                var customer = await db.Customers.FindAsync(obj.CustomerId);

                if (customer != null)
                {
                    customer.CustomerName = obj.CustomerName;
                    customer.CustomerLastName = obj.CustomerLastName;
                    customer.CustomerIdentification = obj.CustomerIdentification;
                    customer.CustomerPhone = obj.CustomerPhone;
                    customer.CustomerAddress = obj.CustomerAddress;
                    customer.Email = obj.Email;
                    customer.UpdateBy = obj.UpdateBy;
                    customer.Update_date_time = obj.Update_date_time;
                    db.Entry(customer).State = EntityState.Modified;
                    var query = await db.SaveChangesAsync();
                    if (query > 0)
                    {
                        return "Guardado Correctamente";
                    }
                }
                return "No se pudo Guardar";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
