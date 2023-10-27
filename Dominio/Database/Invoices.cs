using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Database
{
    public class Invoices
    {
        public int InvoiceId { get; set; }
        public int EmployeeId { get; set; }
        public Employees? EmployeesNavigation { get; set; }
        public int CustomerId {  get; set; }
        public Customers? CustomersNavigation { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date_Time { get; set; }
        public ICollection<Invoice_Detail> InvoicesDetailsCollections { get; set; }= new List<Invoice_Detail>();
    }
}
