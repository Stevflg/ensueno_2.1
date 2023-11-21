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
        public async Task<List<EmployeeDTO>> GetEmployeeList()
        {
            try
            {
                using(var db =new EnsuenoContext())
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
            }
            catch { return null; }
        }

        public List<EmployeeDTO> SearchEmployee(Employees obj)
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    var listempl = (from e in db.Employees
                                          where e.IsActive == true && 
                                          
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
                                          }).ToList();
                    return listempl;
                }
            }
            catch { return null; }
        }

        public Employees GetEmployee(Users obj) {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    var empId = db.Users.Where(a => a.UserName==obj.UserName).Select(a => a).FirstOrDefault();
                    if (empId != null) return db.Employees.Find(empId.EmployeeId);
                    else return null;
                }
            }
            catch { return null; }

        }

        public async Task<string> AddEmployee(Employees obj) { 
            using(var db = new EnsuenoContext())
            {
                db.Employees.Add(obj);
                var query =await db.SaveChangesAsync();
                if (query > 0)
                {
                    return "Guardado Correctamente";
                }
                return "No se pudo guardar";
            }
        }
        public string EditEmployee(Employees obj)
        {
            using( var db = new EnsuenoContext())
            {
                var employee = db.Employees.Find(obj.EmployeeId);
                if (employee != null)
                {
                    employee.EmployeeName = obj.EmployeeName;
                    employee.EmployeeLastName = obj.EmployeeLastName;
                    employee.EmployeeIdentification = obj.EmployeeIdentification;
                    employee.EmployeePhone = obj.EmployeePhone;
                    employee.EmployeeAddress = obj.EmployeeAddress;
                    employee.Email = obj.Email;
                    db.Entry(employee).State = EntityState.Modified;
                    var query = db.SaveChanges();
                    if(query > 0)
                    {
                        return "Guardado Correctamente";
                    }
                }
                return "No se pudo Guardar";
            }
        }

    }
}
