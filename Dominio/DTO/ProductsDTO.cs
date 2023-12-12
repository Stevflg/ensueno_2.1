using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO
{
    public class ProductsDTO
    {
        public int ProdutId { get; set; }

        public string ProductName { get; set; }

        public string Categoria { get; set; }
        public string Proveedor { get; set; }
        public int Stock { get; set; }

        public decimal Purchace_Price { get; set; }

        public decimal Unit_Price { get; set; }

        public string Estado {  get; set; }
        public DateTime Creado { get; set; }
    }
}
