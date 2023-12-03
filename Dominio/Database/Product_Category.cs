using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Database
{
    public class Product_Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int CreatedBy { get; set; }
        public Employees? EmployeeNavigation { get; set; }
        public ICollection<Products> ProductNavigation {get; set; } = new List<Products>();
        public bool IsActive { get; set; }
        public DateTime Date_Time { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? Date_Updated { get; set;}
    }
}