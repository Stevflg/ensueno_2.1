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
        public ICollection<StockMovement> StockMovementsColletions { get; set; } = new List<StockMovement>();
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set;}
    }
}
