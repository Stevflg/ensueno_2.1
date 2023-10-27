using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Database
{
    public class Employees
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeLastName { get; set; }
        public string? EmployeeIdentification { get; set; }
        public string? EmployeePhone { get; set; }
        public string? EmployeeAddress { get; set; }
        public string? Email { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date_Time { get; set; }
        public ICollection<Users> UserCollections { get; set; }=new List<Users>();
        public ICollection<Invoices> InvoiceCollectionsEmpl { get; set; }= new List<Invoices>();
        public ICollection<Customers>? CustomersNavigation { get; set; }=new List<Customers>();
        public ICollection<Suppliers>? SuppliersNavigation { get; set; }=new List<Suppliers>();
    }
}
