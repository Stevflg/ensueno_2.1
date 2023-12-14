using Dominio.Database;
using Persistencia.Context;
using System.Data;

namespace Aplicacion.Reporting
{
    public class EmployeeReport
    {
        private readonly EnsuenoContext db;
        public EmployeeReport() {
            this.db= new EnsuenoContext();
        }
        public DataTable ListEmployee()
        {
                var query = (from c in db.Employees
                            where c.IsActive == true
                            select new Employees {
                            EmployeeId= c.EmployeeId,
                            EmployeeName = c.EmployeeName+" "+c.EmployeeLastName,
                            EmployeeIdentification = c.EmployeeIdentification,
                            EmployeePhone = c.EmployeePhone,
                            EmployeeAddress = c.EmployeeAddress,
                            Email = c.Email
                            }).ToList();

                var dataTable = new DataTable();
                dataTable.Columns.Add("ID", typeof(int));
                dataTable.Columns.Add("Nombre y apellido", typeof(string));
                dataTable.Columns.Add("Cédula", typeof(string));
                dataTable.Columns.Add("Telefono", typeof(string));
                dataTable.Columns.Add("Direccion", typeof(string));
                dataTable.Columns.Add("Correo Electrónico", typeof(string));

            foreach (var item in query)
                {
                    var row = dataTable.NewRow();
                    row["ID"] = item.EmployeeId;
                    row["Nombre y apellido"] = item.EmployeeName;
                    row["Cédula"] = item.EmployeeIdentification;
                    row["Telefono"] = item.EmployeePhone;
                    row["Direccion"] = item.EmployeeAddress;
                    row["Correo Electrónico"] = item.Email;

                dataTable.Rows.Add(row);
                }

                //var dataSet = new DataSet();
                //dataSet.Tables.Add(dataTable);
            return dataTable;
        }
    }
}
