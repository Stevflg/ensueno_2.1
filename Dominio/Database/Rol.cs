using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Database
{
    public class Rol
    {
        public int RolId { get; set; }
        public string? RolName { get; set; }
        public int? EmployeeId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime Date_Time { get; set; }
        public Employees? EmployeeNavigation { get; set; }
        public ICollection<PermissionsRol> PermissionsCollections { get; set; } = new List<PermissionsRol>();
        public ICollection<Users> UserCollections { get; set; } = new List<Users>();
        public ICollection<ProcedureRols> ProceduresRolsCollections { get; set; } = new List<ProcedureRols>();

    }
}