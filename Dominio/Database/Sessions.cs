using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Database
{
    public class Sessions
    {
        public int SesionId { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date_Time { get; set; }
        public virtual Users? UsersNavigation { get; set; }
    }
}
