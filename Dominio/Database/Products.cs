﻿namespace Dominio.Database
{
    public class Products
    {
        public int ProdutId { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public int Stock { get; set; }
        public decimal Purchase_Price { get; set; }
        public decimal Unit_Price { get; set; }
        public byte[]? Image { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date_Time { get; set; }
        public ICollection<Invoice_Detail> InvoiceDetailCollections  { get; set; }=new List<Invoice_Detail>();
        public ICollection<StockMovement> StockMovementsCollections { get; set; }= new List<StockMovement>();
        public Product_Category? Product_CategoryNavigation { get; set; }
        public int? EmployeeId { get; set; }
        public int? UpdateBy { get; set; }
        public Employees? EmployeesNavigation { get; set; }
        public DateTime? Update_date_time { get; set; }
    }
}