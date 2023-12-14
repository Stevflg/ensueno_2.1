using Dominio.Database;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Proc
{
    public static class DInvoice
    {

        public static async Task<Invoices> AddInvoice(Invoices invoice)
        {
            try
            {
                using(var db = new EnsuenoContext())
                {
                    db.Add(invoice);
                   await db.SaveChangesAsync();
                    return invoice;
                }
            }catch
            {
                return null;
            }
        }


    }
}
