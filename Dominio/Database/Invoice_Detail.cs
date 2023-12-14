﻿namespace Dominio.Database
{
    public class Invoice_Detail
    {
        public int InvoiceId { get; set; }
        public Invoices? InvoicesNavigation { get; set; }
        public int? ProductId  { get; set; }
        public Products? ProductsNavigation { get; set; }
        public int Units { get; set; }
        public decimal Price { get; set; }
    }
}
