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
    }
}
