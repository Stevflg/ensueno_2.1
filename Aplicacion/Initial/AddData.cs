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
                lp.Add(new Procedures { ProcedureName = "Restore" });

                db.AddRange(lp);
                db.SaveChanges();
            }
        }
        private void AddDataPermissions()
        {
            using(var db =new EnsuenoContext())
            {
               List<Permissions> lp = new();
                lp.Add(new Permissions {PermissionsName = "Form Main"});
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
                    EmployeeLastName=" ",
                    EmployeeIdentification= " ",
                    EmployeePhone= " ",
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
                var per = (from p in db.Permissions
                           select new Permissions {PermissionsId = p.PermissionsId}).ToList();
                List<PermissionsRol> PR= new List<PermissionsRol>();
                foreach(var p in per)
                {
                    PR.Add(new PermissionsRol {RolId=1,PermissionsId=p.PermissionsId});
                }
                db.AddRange(PR);
                db.SaveChanges();
            }
        }

        private void AddUser() {
            using(var db =new EnsuenoContext())
            {
                ProcUsers pUser = new ProcUsers();
                Users users = new Users {
                    EmployeeId = 1,
                    UserName = "Admin",
                    Password = pUser.Encrypt("admin"),
                    RolId= 1                                        
                };
                db.Add(users);
                db.SaveChanges();
            }
        }

    }
}
