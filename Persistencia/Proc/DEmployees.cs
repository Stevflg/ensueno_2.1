using Dominio.Database;
using Dominio.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Proc
{
    public static class DEmployees
    {
        public static async Task<List<EmployeeDTO>> GetEmployeeList()
        {
            try
            {
                    using (var db = new EnsuenoContext())
                {
                    var listempl = await (from e in db.Employees
                                          where e.IsActive == true
                                          select new EmployeeDTO
                                          {
                                              Id = e.EmployeeId,
                                              Nombres = e.EmployeeName,
                                              Apellidos = e.EmployeeLastName,
                                              Cedula = e.EmployeeIdentification,
                                              Telefono = e.EmployeePhone,
                                              Direccion = e.EmployeeAddress,
                                              Correo = e.Email,
                                              Creado = e.Date_Time
                                          }).ToListAsync();
                    return listempl;
                }
            }
            catch { return null; }
        }

        public static async Task<List<EmployeeDTO>> SearchEmployee(Employees obj)
        {
            try
            {
               using(var db = new EnsuenoContext())
                {
                    var listempl = await (from e in db.Employees
                                          where (
                                              e.EmployeeId.ToString().Contains(obj.EmployeeName) ||
                                              e.EmployeeName.Contains(obj.EmployeeName) ||
                                              e.EmployeeLastName.Contains(obj.EmployeeName) ||
                                              e.EmployeeIdentification.Contains(obj.EmployeeName) ||
                                              e.EmployeePhone.Contains(obj.EmployeeName) ||
                                              e.EmployeeAddress.Contains(obj.EmployeeName) ||
                                              e.Email.Contains(obj.Email)) && e.IsActive == true
                                          select new EmployeeDTO
                                          {
                                              Id = e.EmployeeId,
                                              Nombres = e.EmployeeName,
                                              Apellidos = e.EmployeeLastName,
                                              Cedula = e.EmployeeIdentification,
                                              Telefono = e.EmployeePhone,
                                              Direccion = e.EmployeeAddress,
                                              Correo = e.Email,
                                              Creado = e.Date_Time
                                          }).ToListAsync();
                    return listempl;
                }          
            }
            catch { return null; }
        }

        public static async Task<Employees> GetEmployee(Users obj) {
            try
            {
                using(var db = new EnsuenoContext())
                {
                    var empId =await db.Users.Where(a => a.UserName == obj.UserName).Select(a => a).FirstOrDefaultAsync();
                    var employee = await db.Employees.FindAsync(empId.EmployeeId);
                    return employee;
                }
            }
            catch { return null; }

        }

        public static async Task<string> AddEmployee(Employees obj) {
            try
            {
                using(var db = new EnsuenoContext())
                {
                    db.Employees.Add(obj);
                    var query = await db.SaveChangesAsync();
                    if (query > 0)
                    {
                        return "Guardado Correctamente";
                    }
                    return "No se pudo guardar";
                }

            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public static async Task<Employees> GetEmployeebyFormEdit(Employees obj)
        {
            try
            {
               using(var db =new EnsuenoContext())
                {
                    var employe = await (from e in db.Employees
                                         where e.IsActive == true && e.EmployeeId == obj.EmployeeId
                                         select e).FirstOrDefaultAsync();
                    return employe;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<string> EditEmployee(Employees obj)
        {
            try
            {
              using(var db = new EnsuenoContext())
                {
                    var employee = await db.Employees.FindAsync(obj.EmployeeId);

                    if (employee != null)
                    {
                        employee.EmployeeName = obj.EmployeeName;
                        employee.EmployeeLastName = obj.EmployeeLastName;
                        employee.EmployeeIdentification = obj.EmployeeIdentification;
                        employee.EmployeePhone = obj.EmployeePhone;
                        employee.EmployeeAddress = obj.EmployeeAddress;
                        employee.Image = obj.Image;
                        employee.Email = obj.Email;
                        employee.UpdatedBy = obj.UpdatedBy;
                        employee.Date_Updated = obj.Date_Updated;
                        db.Entry(employee).State = EntityState.Modified;
                        var query = await db.SaveChangesAsync();
                        if (query > 0)
                        {
                            return "Guardado Correctamente";
                        }
                    }
                    return "No se pudo Guardar";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
    
        }

        public static async Task<string> DeleteEmployee(Employees obj)
        {
            try
            {
                using( var db = new EnsuenoContext())
                {
                    var employee = await db.Employees.FindAsync(obj.EmployeeId);
                    if (employee != null)
                    {
                        employee.IsActive = false;
                        employee.UpdatedBy = obj.UpdatedBy;
                        employee.Date_Updated = obj.Date_Updated;
                        db.Entry(employee).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return "Eliminado Correctamente";
                        }
                        return "No se pudo Eliminar";
                    }
                    return "Registro no existe";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
