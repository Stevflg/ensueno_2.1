using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO
{
    public class InvoiceDetailDTO
    {
        public  int Id { get; set; }
        public int Codigo { get; set; }
        public string Producto { get; set; }
        public decimal Precio { get; set; }
        public int Unidades { get; set;}
        public decimal SubTotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
    }
}
