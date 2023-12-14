using Dominio.Database;
using Dominio.DTO;
using Persistencia.Proc;

namespace Aplicacion.Negocio
{
    public static class ProcCustomers
    {
        public static async Task<List<CustomerDTO>> ListCustomers()
        {
            return await DCustomers.ListCustomers();
        }

        public static async Task<List<CustomerDTO>> SearchCustomers(Customers obj)
        {
            return await DCustomers.SearchCustomers(obj);
        }

        public static async Task<string> AddCustomer(Customers customer)
        {
            return await DCustomers.AddCustomer(customer);
        }

        public static async Task<string> DeleteCustomer(Customers obj)
        {
            return await DCustomers.DeleteCustomer(obj);
        }

        public static async Task<Customers> GetCustomerByEdit(Customers obj)
        {
            return await DCustomers.GetCustomerByEdit(obj);
        }

        public static async Task<string> EditCustomer(Customers obj)
        {
            return await DCustomers.EditCustomer(obj);
        }
    }
}
