using Dominio.Database;
using Dominio.DTO;
using Persistencia.Proc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ProceduresDB
{
    public static class ProcInvoiceDetail
    {

        public static async Task<Customers> getCustomerName(Invoices invoices)
        {
            return await DInvoiceDetail.getCustomerName(invoices);
        }

        public static async Task<List<InvoiceDetailDTO>> ListInvoiceDetail(Invoices invoice) { 
        
            return await DInvoiceDetail.ListInvoiceDetail(invoice);
        }

        public static async Task<List<Products>> ListProducts()
        {
            return await DInvoiceDetail.ListProducts();
        }

        public static async Task AddInvoiceDetail(Invoice_Detail invoiceDt, Username user)
        {
            await DInvoiceDetail.AddInvoiceDetail(invoiceDt, user);
        }

        public static async Task VoidInvoiceDetail(Invoice_Detail invoiceDt, Username user)
        {
            await DInvoiceDetail.VoidInvoiceDetail(invoiceDt, user);
        }

    }
}
