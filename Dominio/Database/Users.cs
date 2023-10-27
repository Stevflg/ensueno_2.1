using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Database
{
    public class Users
    {
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public Employees? EmployeesNavigation { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date_Time { get; set; }
        public ICollection<Sessions> SessionsCollection { get; set; }= new List<Sessions>();
    }
}
