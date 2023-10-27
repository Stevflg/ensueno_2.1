using Dominio.Database;
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

    }
}
