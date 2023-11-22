using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO
{
    public class Username
    {
        public  int UserId { get; set; }
        public int EmployeeId { get; set; }
        public string UserName { get; set; }
        public string RolName { get; set; }
        public byte[] Image { get; set; }
    }
}
