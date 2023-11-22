using Dominio.Database;
using Dominio.DTO;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ProceduresDB
{
    public class ProcEmployees
    {
        private readonly EnsuenoContext db;
        public ProcEmployees()
        {
            db= new EnsuenoContext();
        }


        public async Task<List<EmployeeDTO>> GetEmployeeList()
        {
            try
            {
                    var listempl = await(from e in db.Employees
                                    where e.IsActive == true
                                    select new EmployeeDTO {
                                    Id=e.EmployeeId,
                                    Nombres=e.EmployeeName,
                                    Apellidos=e.EmployeeLastName,
                                    Cedula=e.EmployeeIdentification,
                                    Telefono=e.EmployeePhone,
                                    Direccion=e.EmployeeAddress,
                                    Correo=e.Email,
                                    Creado = e.Date_Time
                                    }).ToListAsync();
                    return listempl;
            }
            catch { return null; }
        }

        public async Task<List<EmployeeDTO>> SearchEmployee(Employees obj)
        {
            try
            {
                var listempl = await (from e in db.Employees
                                      where e.IsActive == true &&
                                          e.EmployeeId.ToString().Contains(obj.EmployeeName)||
                                          e.EmployeeName.Contains(obj.EmployeeName)||
                                          e.EmployeeLastName.Contains(obj.EmployeeLastName)||
                                          e.EmployeeIdentification.Contains(obj.EmployeeIdentification) ||
                                          e.EmployeePhone.Contains(obj.EmployeePhone) ||
                                          e.EmployeeAddress.Contains(obj.EmployeeAddress) ||
                                          e.Email.Contains(obj.Email)
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
            catch { return null; }
        }

        public Employees GetEmployee(Users obj) {
            try
            {
                    var empId = db.Users.Where(a => a.UserName==obj.UserName).Select(a => a).FirstOrDefault();
                    if (empId != null) return db.Employees.Find(empId.EmployeeId);
                    else return null;
            }
            catch { return null; }

        }

        public async Task<string> AddEmployee(Employees obj) { 
 
                db.Employees.Add(obj);
                var query =await db.SaveChangesAsync();
                if (query > 0)
                {
                    return "Guardado Correctamente";
                }
                return "No se pudo guardar";
        }

        //Metodo para llenar el formulario de edicion de empleados
        public async Task<Employees> GetEmployeebyFormEdit(Employees obj)
        {
            try
            {
                var employe = await (from e in db.Employees
                                     where e.IsActive == true && e.EmployeeId == obj.EmployeeId
                                     select e).FirstOrDefaultAsync();
                return employe;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> EditEmployee(Employees obj)
        {
            try
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
            catch (Exception ex)
            {
                return ex.Message;
            }
    
        }

        public async Task<string> DeleteEmployee(Employees obj)
        {
            try
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
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
