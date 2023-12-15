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
    public static class ProcInvoice
    {

        public static async Task<List<CustomerDTO>> ListCustomers()
        {
            return await DInvoice.ListCustomers();
        }

        public static async Task<List<InvoiceDTO>> ListInvoice()
        {
            return await DInvoice.ListInvoice();
        }

        public static async Task<List<InvoiceDTO>> SearchInvoice(string obj)
        {
            return await DInvoice.SearchInvoice(obj);
        }

        public static async Task<Invoices> AddInvoice(Invoices invoice)
        {
            return await DInvoice.AddInvoice(invoice);
        }

        public static async Task<string> VoidInvoice(Invoices invoices)
        {
            return await DInvoice.VoidInvoice(invoices);
        }

    }
}
