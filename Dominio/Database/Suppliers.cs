using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Database
{
    public class Suppliers
    {
        public int SupplierId { get; set; }
        public string? SupplierName { get; set;}
        public string? SupplierAddress { get; set;}
        public string? SupplierRUC { get; set; }
        public string? SupplierPhone { get; set;}
        public string? SupplierEmail { get; set;}
        public bool IsActive {  get; set; }
        public int CreatedBy { get; set; }
        public Employees? Employee { get; set; }
        public ICollection<StockMovement> StockMovementsCollections { get; set; } = new List<StockMovement>();
        public DateTime Date_Time { get; set; }
    }
}
