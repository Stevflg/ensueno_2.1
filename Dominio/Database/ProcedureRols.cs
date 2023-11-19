using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Database
{
    public class ProcedureRols
    {
        public int ProceduresRolsId { get; set; }
        public int? ProcedureId {get; set; }
        public int? RolId { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date_Time { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? Date_Updated { get; set; }
        public  Employees? EmployeeNavigation { get; set; }
        public Procedures? ProcedureNavigation{ get; set; }
        public Rol? RolNavigation { get; set; }
    }
}
