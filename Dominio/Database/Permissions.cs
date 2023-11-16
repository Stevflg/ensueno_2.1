using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Database
{
     public class Permissions
    {
        public int PermissionsId { get; set; }
        public string? PermissionsName { get; set; }
        public ICollection<PermissionsRol> PermissionsRolCollections { get; set; } = new List<PermissionsRol>();
        public  int? UpdatedBy { get; set; }
        public Employees? EmployeeNavigation { get; set; }
    }
}