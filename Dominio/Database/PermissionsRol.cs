using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Database
{
    public class PermissionsRol
    {
        public int PermissionsRolId { get; set; }
        public int RolId { get; set; }
        public Rol RolNavigation { get; set; }
        public int PermissionsId { get; set; }
        public Permissions PermissionsNavigation { get; set; }
        public  bool IsActive { get; set; }
        public DateTime Date_Time { get; set; }
    }
}
