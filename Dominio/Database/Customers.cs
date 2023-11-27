using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Database
{
    public class Customers
    {
        public int CustomerId { get; set; }
        public string CustomerIdentification { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public string Email {  get; set; }
        public int? CreatedBy { get; set; }
        public Employees EmployeesNavigation { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date_Time { get; set; }
        public ICollection<Invoices> InvoicesCollections { get; set; } = new List<Invoices>();
        /// <summary>
        /// ////
        /// </summary>
        public int? UpdateBy { get; set; }
        public DateTime? Update_date_time { get; set; }
    }
}
