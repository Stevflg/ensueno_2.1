using Dominio.Database;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Procedures
{
    public class ProcEmployees
    {
        public List<Employees> GetEmployeeList()
        {
            try
            {
                using(var db =new EnsuenoContext())
                {
                    var listempl = (from e in db.Employees
                                    where e.IsActive == true
                                    select new Employees {
                                    EmployeeId = e.EmployeeId,
                                    EmployeeName = e.EmployeeName+" "+e.EmployeeLastName,
                                    }).ToList();
                    return listempl;
                }
            }
            catch { return null; }
        }
        public Employees GetEmployeeByUserName(Users obj) {
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

        public string AddEmployee(Employees obj) { 
            using(var db = new EnsuenoContext())
            {
                db.Employees.Add(obj);
                var query = db.SaveChanges();
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
