using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        public byte[]? Image { get; set; }
        public int? CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date_Time { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? Date_Updated { get; set; }
        public ICollection<Users> UserCollections { get; set; }=new List<Users>();
        public ICollection<Invoices> InvoiceCollectionsEmpl { get; set; }= new List<Invoices>();
        public ICollection<Customers> CustomersNavigation { get; set; }=new List<Customers>();
        public ICollection<Suppliers> SuppliersNavigation { get; set; }=new List<Suppliers>();
        public ICollection<Formularios> FormsCollections { get; set; } = new List<Formularios>();
        public ICollection<Products> ProductsCollections { get; set; }=new List<Products>();
        public ICollection<Rol> RolCollections { get; set; } = new List<Rol>();
        public ICollection<Product_Category> Product_CategoriesCollections { get; set; } = new List<Product_Category>();
        public ICollection<FormRol> FormRolCollectios { get; set; } = new List<FormRol>();
        public  ICollection<ProcedureRols> ProcedureRolCollections { get; set; } = new List<ProcedureRols>();
    }
}
