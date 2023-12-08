using Aplicacion.ProceduresDB;
using Dominio.Database;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Aplicacion.Initial
{
    public class AddData
    {
        public bool validarDb()
        {
            using(var db = new EnsuenoContext())
            {
                var consulta = db.Users.FirstOrDefault();
                if (consulta != null)
                    return false;

                return true;
            }
        }
        public string CargarDatos()
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    var consulta = db.Users.FirstOrDefault();
                
                        AddDataProcedures();
                        AddDataPermissions();
                        AddDataEmployee();
                        AddDataRol();
                        AddDataRolProcedures();
                        AddPermissionsRol();
                        AddUser();
                        AddMovimientos();
                        return "Base de Datos Creada Correctamente";
                }
            }
            catch(Exception ex) { return ex.InnerException.Message; } 
        }



        private void AddDataProcedures()
        {
            using(var db =new EnsuenoContext())
            {
              List<Procedures> lp = new();
                lp.Add(new Procedures { ProcedureName= "Create"});
                lp.Add(new Procedures { ProcedureName = "Read" });
                lp.Add(new Procedures { ProcedureName = "Delete" });
                lp.Add(new Procedures { ProcedureName = "Update" });

                db.AddRange(lp);
                db.SaveChanges();
            }
        }
        private void AddDataPermissions()
        {
            using(var db =new EnsuenoContext())
            {
               List<Formularios> lp = new();

                lp.Add(new Formularios {Name = "Form_Main",AliasForm = "Form Main"});
                db.AddRange(lp);
                db.SaveChanges();
            }
        }
        private void AddDataEmployee()
        {
           using(var db =new EnsuenoContext())
            {
                Employees employees = new Employees { 
                    EmployeeName= "Admin",
                    EmployeeLastName="System",
                    EmployeeIdentification= "00000",
                    EmployeePhone= "88888888",
                    EmployeeAddress= "Administrator",
                    Email = " ",
                    CreatedBy = 0
                };
                db.Add(employees);
                db.SaveChanges();
            }
        }
        private void AddDataRol() {
            using( var db =new EnsuenoContext()) { 
                Rol rol = new Rol { 
                RolName="Administrador",
                EmployeeId = 1,
                };
                db.Add(rol);
                db.SaveChanges();
            };
        }
        private void AddDataRolProcedures() {
            using (var db = new EnsuenoContext())
            {
                var proc = (from p in db.Procedures
                            select new Procedures { ProcedureId = p.ProcedureId }).ToList();
                List<ProcedureRols> procedureRols = new List<ProcedureRols>();
                foreach (var p in proc)
                {
                    procedureRols.Add(new ProcedureRols { ProcedureId = p.ProcedureId, RolId = 1 });
                }
                db.AddRange(procedureRols);
                db.SaveChanges();
            }
        }
        private void AddPermissionsRol()
        {
            using(var db =new EnsuenoContext())
            {
                var per = (from p in db.Forms
                           select new Formularios {FormId = p.FormId}).ToList();
                List<FormRol> PR= new List<FormRol>();
                foreach(var p in per)
                {
                    PR.Add(new FormRol {RolId=1,PermissionsId=p.FormId});
                }
                db.AddRange(PR);
                db.SaveChanges();
            }
        }

        private void AddUser() {
            using(var db =new EnsuenoContext())
            {
                Users users = new Users {
                    EmployeeId = 1,
                    UserName = "Admin",
                    Password = ProcUsers.Encrypt("admin"),
                    RolId= 1                                        
                };
                db.Add(users);
                db.SaveChanges();
            }
        }
        private void AddMovimientos()
        {
            using (var db =new EnsuenoContext())
            {
                List<StockMovementType> types = new List<StockMovementType>();
                types.Add(new StockMovementType {Type = "Ingreso Inventarios" });
                types.Add(new StockMovementType {Type = "Recusado Inventarios" });
                types.Add(new StockMovementType {Type = "Egreso en Factura" });
                types.Add(new StockMovementType {Type = "Anulación en Factura" });
                db.AddRange(types);
                db.SaveChanges();
            }
        }
    }
}
