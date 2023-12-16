using Dominio.Database;
using Dominio.DTO;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Persistencia.Proc
{
    public static class DRolesFormP
    {
        //public static async Task<string> 


        public static async Task<List<Formularios>> ListComboBoxForms() {

                using (var db = new EnsuenoContext())
                {
                    var list =await db.Forms.ToListAsync();
                    return list;
                }
        }


        public static async Task<List<Procedures>> ListComboBoxPermisions()
        {

                using(var db = new EnsuenoContext())
                {
                    var list =await db.Procedures.ToListAsync();
                    return list;
                }
        }


        public static async Task<List<FormsDTO>> ListFormRol(Rol r)
        {
            using( var db = new EnsuenoContext())
            {
                var list = await (from fr in db.FormRols
                                  join f in db.Forms on fr.FormId equals f.FormId
                                  where fr.RolId.Equals(r.RolId)
                                  orderby fr.IsActive descending
                                  select new FormsDTO
                                  {
                                     Id = f.FormId,
                                     Formulario = f.AliasForm,
                                     Estado = (fr.IsActive) ? "Habilitado" : "Deshabilitado"
                                  }).ToListAsync();
                return list;
            }
        }


        public static async Task<List<ProcedureDTO>> ListProcRol(Rol r)
        {
            using (var db = new EnsuenoContext())
            {
                var list = await (from pr in db.ProcedureRols
                                  join p in db.Procedures on pr.ProcedureId equals p.ProcedureId
                                  where pr.RolId.Equals(r.RolId)
                                  orderby pr.IsActive descending
                                  select new ProcedureDTO
                                  {
                                      Id = p.ProcedureId,
                                      Permisos = p.ProcedureName,
                                      Estado = (pr.IsActive) ? "Habilitado" : "Deshabilitado"
                                  }).ToListAsync();
                return list;
            }
        }


        public static async Task<List<RolDTO>> ListRol()
        {
           using(var db = new EnsuenoContext())
            {
                var listRol = await (from r in db.Rols
                                     where r.IsActive.Equals(true)
                                     select new RolDTO
                                     {
                                         Id = r.RolId,
                                         Rol = r.RolName,
                                         Estado = (r.IsActive)? "Activo":"Inactivo"
                                     }
                                     ).ToListAsync();
                return listRol;
            }
        }


        public static async Task<List<RolDTO>> SearchRol(Rol rol)
        {
            using (var db = new EnsuenoContext())
            {
                var listRol = await (from r in db.Rols
                                     where (r.RolName.Contains(rol.RolName) || 
                                     r.RolId.ToString().Contains(rol.RolName)) && r.IsActive.Equals(true)
                                     select new RolDTO
                                     {
                                         Id = r.RolId,
                                         Rol = r.RolName,
                                         Estado = (r.IsActive) ? "Activo" : "Inactivo"
                                     }
                                     ).ToListAsync();
                return listRol;
            }
        }

        public static async Task<string> AddRol(Rol rol)
        {
            try
            {
                using(var db = new EnsuenoContext())
                {
                    var r= await db.Rols.Where(a => a.RolName.Equals(rol.RolName)).FirstAsync();
                    if (r != null)
                    {
                        db.Add(rol);
                        var query = await db.SaveChangesAsync();
                        var result = (query > 0) ? "Guardado Correctamente" : "No se pudo Guardar";
                    }
                    return "Este Rol ya existe";
                }
            }catch(Exception ex) { return ex.Message; }
        }

        public static async Task<string> DisableRol(Rol rol)
        {
            try
            {
                using(var db = new EnsuenoContext())
                {
                    var rl = await (from r in db.Rols
                                    where r.RolId.Equals(rol.RolId) && r.IsActive.Equals(true)
                                    select r).FirstAsync();
                    if (rl != null)
                    {
                        rl.IsActive = false;
                        rl.UpdatedBy = rl.UpdatedBy;
                        rl.Date_Updated = DateTime.Now;
                        db.Entry(rl).State = EntityState.Modified;
                        var query =await db.SaveChangesAsync();
                        var result = (query > 0) ? "Deshabilitado Correctamente" : "No se pudo Deshabilitar";
                        return result;
                    }
                    return "Rol ya Deshabilitado";
                }
            }catch(Exception ex) { return ex.Message; }
        }

        public static async Task<string> EnableRol(Rol rol)
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    var rl = await (from r in db.Rols
                                    where r.RolId.Equals(rol.RolId) && r.IsActive.Equals(false)
                                    select r).FirstAsync();
                    if (rl != null)
                    {
                        rl.IsActive = true;
                        rl.UpdatedBy = rl.UpdatedBy;
                        rl.Date_Updated = DateTime.Now;
                        db.Entry(rl).State = EntityState.Modified;
                        var query = await db.SaveChangesAsync();
                        var result = (query > 0) ? "Habilitado Correctamente" : "No se pudo Habilitar";
                        return result;
                    }
                    return "Rol ya Habilitado";
                }
            }
            catch (Exception ex) { return ex.Message; }
        }

        public static async Task<string> EnableFormRol(FormRol FrmRol)
        {
            try
            {
                using(var db = new EnsuenoContext())
                {
                    var rolform = await (from fr in db.FormRols
                                                where fr.RolId.Equals(FrmRol.RolId)
                                                && fr.FormId.Equals(FrmRol.FormId)
                                                && fr.IsActive.Equals(false)
                                                select fr).FirstAsync();

                    if (rolform!=null)
                    {
                        rolform.IsActive = true;
                        rolform.UpdatedBy = FrmRol.UpdatedBy;
                        rolform.Date_Updated = FrmRol.Date_Updated;
                        var query = await db.SaveChangesAsync();
                        var result = (query > 0) ? "Habilitado Correctamente" : "No se pudo Hbilitar Permiso";
                        return result;
                    }
                    return "Formulario ya Habilitado";
                }
            }
            catch(Exception ex) 
            {
                return ex.Message;
            }
        }

        public static async Task<string> DisableFormRol(FormRol FrmRol)
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    var rolform = await (from fr in db.FormRols
                                         where fr.RolId.Equals(FrmRol.RolId)
                                         && fr.FormId.Equals(FrmRol.FormId)
                                         && fr.IsActive.Equals(true)
                                         select fr).FirstAsync();

                    if (rolform != null)
                    {
                        rolform.IsActive = true;
                        rolform.UpdatedBy = FrmRol.UpdatedBy;
                        rolform.Date_Updated = FrmRol.Date_Updated;
                        var query = await db.SaveChangesAsync();
                        var result = (query > 0) ? "Deshabilitado Correctamente" : "No se pudo Deshabilitar Permiso";
                        return result;
                    }
                    return "Formulario ya Heshabilitado";
                }
            }
             catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public static async Task<string> EnableProcedureRol(ProcedureRols prcRols)
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    var rolproc = await (from pr in db.ProcedureRols
                                         where pr.RolId.Equals(prcRols.RolId)
                                         && pr.ProcedureId.Equals(prcRols.ProcedureId)
                                         && pr.IsActive.Equals(false)
                                         select pr).FirstAsync();

                    if (rolproc != null)
                    {
                        rolproc.IsActive = true;
                        rolproc.UpdatedBy = prcRols.UpdatedBy;
                        rolproc.Date_Updated = prcRols.Date_Updated;
                        var query = await db.SaveChangesAsync();
                        var result = (query > 0) ? "Habilitado Correctamente" : "No se pudo Habilitar Permiso";
                        return result;
                    }
                    return "Permiso ya Habilitado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static async Task<string> DisableProcedureRol(ProcedureRols prcRols)
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    var rolproc = await (from pr in db.ProcedureRols
                                         where pr.RolId.Equals(prcRols.RolId)
                                         && pr.ProcedureId.Equals(prcRols.ProcedureId)
                                         && pr.IsActive.Equals(true)
                                         select pr).FirstAsync();

                    if (rolproc != null)
                    {
                        rolproc.IsActive = false;
                        rolproc.UpdatedBy = prcRols.UpdatedBy;
                        rolproc.Date_Updated = prcRols.Date_Updated;
                        var query = await db.SaveChangesAsync();
                        var result = (query > 0) ? "Dehabilitado Correctamente" : "No se pudo Deshaabilitar Permiso";
                        return result;
                    }
                    return "Permiso ya Deshabilitado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
