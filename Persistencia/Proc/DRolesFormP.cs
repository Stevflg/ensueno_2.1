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
            try
            {
                using (var db = new EnsuenoContext())
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
            catch (Exception ex)
            {
                return null;
            }
        }


        public static async Task<List<ProcedureDTO>> ListProcRol(Rol r)
        {
            try
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
            catch (Exception ex)
            {
                return null;
            }
        }


        public static async Task<List<RolDTO>> ListRol()
        {
         try
            {
                using (var db = new EnsuenoContext())
                {
                    var listRol = await (from r in db.Rols
                                         orderby r.IsActive descending
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
            catch (Exception ex)
            {
                return null;
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
                    db.Add(rol);
                    var query = await db.SaveChangesAsync();
                    var result = (query > 0) ? "Guardado Correctamente" : "No se pudo Guardar";
                    return result;
                }
            }catch(Exception ex) { return "Este Rol ya existe"; }
        }


        public static async Task<string> AddFormRol(FormRol FrmRol)
        {
            try
            {
                using(var db = new EnsuenoContext())
                {
                    if (db.FormRols.Any())
                    {
                        var frmr = await db.FormRols.Where(a => a.FormId.Equals(FrmRol.FormId) &&
                         a.RolId.Equals(FrmRol.RolId)).FirstOrDefaultAsync();
                        if (frmr == null)
                        {
                            db.Add(FrmRol);
                            var q = await db.SaveChangesAsync();
                            var r = (q > 0) ? "Guardado Correctamente" : "No se pudo Guardar";
                            return r;
                        }
                        return "Este Permiso ya esta asignado";
                    }
                    db.Add(FrmRol);
                    var query = await db.SaveChangesAsync();
                    var result = (query > 0) ? "Guardado Correctamente" : "No se pudo Guardar";
                    return result;
                }
            }catch(Exception ex)
            {
                return "Seleccione un Rol";
            }
        }

        public static async Task<string> AddProcedureRol(ProcedureRols ProcRols)
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    if (db.ProcedureRols.Any())
                    {
                        var frmr = await db.ProcedureRols.Where(a => a.ProcedureId.Equals(ProcRols.ProcedureId) &&
                        a.RolId.Equals(ProcRols.RolId)).FirstOrDefaultAsync();

                        if (frmr == null)
                        {
                            db.Add(ProcRols);
                            var q = await db.SaveChangesAsync();
                            var r = (q > 0) ? "Guardado Correctamente" : "No se pudo Guardar";
                            return r;
                        }
                        return "Este Permiso ya esta asignado";
                    }
                    db.Add(ProcRols);
                    var query = await db.SaveChangesAsync();
                    var result = (query > 0) ? "Guardado Correctamente" : "No se pudo Guardar";
                    return result;
                }
            }
            catch (Exception ex){
                return "Seleccione un Rol";
            }
        }

        public static async Task<string> DisableRol(Rol rol)
        {
            try
            {
                using(var db = new EnsuenoContext())
                {
                    var rl = await (from r in db.Rols
                                    where r.RolId.Equals(rol.RolId)
                                    select r).FirstAsync();
                    if (rl != null && rl.IsActive.Equals(true))
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
                                    where r.RolId.Equals(rol.RolId)
                                    select r).FirstAsync();
                    if (rl != null && rl.IsActive.Equals(false))
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
                                                
                                                select fr).FirstAsync();

                    if (rolform != null && rolform.IsActive.Equals(false))
                    {
                        rolform.IsActive = true;
                        rolform.UpdatedBy = FrmRol.UpdatedBy;
                        rolform.Date_Updated = DateTime.Now;
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
                                         
                                         select fr).FirstAsync();

                    if (rolform != null && rolform.IsActive.Equals(true))
                    {
                        rolform.IsActive = false;
                        rolform.UpdatedBy = FrmRol.UpdatedBy;
                        rolform.Date_Updated = DateTime.Now;
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
                                         
                                         select pr).FirstAsync();

                    if (rolproc != null && rolproc.IsActive.Equals(false))
                    {
                        rolproc.IsActive = true;
                        rolproc.UpdatedBy = prcRols.UpdatedBy;
                        rolproc.Date_Updated = DateTime.Now;
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
                                         select pr).FirstAsync();

                    if (rolproc != null && rolproc.IsActive.Equals(true))
                    {
                        rolproc.IsActive = false;
                        rolproc.UpdatedBy = prcRols.UpdatedBy;
                        rolproc.Date_Updated = DateTime.Now;
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

        public static async Task<string> UpdateRol(Rol rol)
        {
            try
            {
                using (var db = new EnsuenoContext())
                {
                    var r = await db.Rols.FindAsync(rol.RolId);
                    if(r != null)
                    {
                        r.RolName = rol.RolName;
                        r.UpdatedBy = rol.UpdatedBy;
                        r.Date_Updated = DateTime.Now;
                        db.Entry(r).State = EntityState.Modified;
                        var query =await db.SaveChangesAsync();
                        var result = (query > 0) ? "Guardado Correctamente" : "No se pudo Guardar";
                        return result;
                    }
                    return "No se pudo Guardar";
                }
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
