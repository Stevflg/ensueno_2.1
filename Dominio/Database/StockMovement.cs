using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Database
{
    public class StockMovement
    {
        public int MovementId { get; set; }
        public int SupplierId { get; set; }
        public Suppliers? SuppliersNavigation { get; set; }
        public int ProductId { get; set; }
        public Products? ProductsNavigation { get; set; }
        public int TypeStockMovement { get; set; }
        public StockMovementType? StockMovementTypeNavigation { get; set; }
        public int Units { get; set; }
        public decimal Price { get; set; }
        public DateTime Date_Time { get; set; }
        public int? InvoiceId { get; set; }
        public int? EmployeeId { get; set; }
        public Invoices? InvoicesNavigation { get; set; }
    }
}