using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO
{
    public class InvoiceCTO
    {
        public int Id { get; set; }
        public string Empleado { get; set; }
        public string Cliente { get; set;}
        public DateTime Creado { get; set;}
    }
}
