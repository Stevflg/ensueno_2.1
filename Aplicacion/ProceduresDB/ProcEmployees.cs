using Dominio.Database;
using Dominio.DTO;
using Persistencia.Proc;

namespace Aplicacion.ProceduresDB
{
    public static class ProcEmployees
    {
        public static async Task<List<EmployeeDTO>> GetEmployeeList()
        {
            return await DEmployees.GetEmployeeList();
        }

        public static async Task<List<EmployeeDTO>> SearchEmployee(Employees obj)
        {
            return await DEmployees.SearchEmployee(obj);
        }

        public static async Task<Employees> GetEmployee(Users obj)
        {
            return await DEmployees.GetEmployee(obj);
        }

        public static async Task<string> AddEmployee(Employees obj)
        {
            return await DEmployees.AddEmployee(obj);
        }

        public static async Task<Employees> GetEmployeebyFormEdit(Employees obj)
        {
            return await DEmployees.GetEmployeebyFormEdit(obj);
        }

        public static async Task<string> EditEmployee(Employees obj)
        {
            return await DEmployees.EditEmployee(obj);
        }

        public static async Task<string> DeleteEmployee(Employees obj)
        {
            return await DEmployees.DeleteEmployee(obj);
        }
    }
}
