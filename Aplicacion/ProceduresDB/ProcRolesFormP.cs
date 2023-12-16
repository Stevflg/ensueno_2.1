using Dominio.Database;
using Dominio.DTO;
using Persistencia.Proc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aplicacion.ProceduresDB
{
    public class ProcRolesFormP
    {

        public static async Task<string> AddFormRol(FormRol FrmRol)
        {
            return await DRolesFormP.AddFormRol(FrmRol);
        }

        public static async Task<string> AddProcedureRol(ProcedureRols ProcRols)
        {
            return await DRolesFormP.AddProcedureRol(ProcRols);
        }


        public static async Task<string> UpdateRol(Rol rol)
        {
            return await DRolesFormP.UpdateRol(rol);
        }

        public static async Task<List<Formularios>> ListComboBoxForms()
        {
            return await DRolesFormP.ListComboBoxForms();
        }

        public static async Task<List<Procedures>> ListComboBoxPermisions()
        {
            return await DRolesFormP.ListComboBoxPermisions();
        }

        public static async Task<List<FormsDTO>> ListFormRol(Rol r)
        {
            return await DRolesFormP.ListFormRol(r);
        }

        public static async Task<List<ProcedureDTO>> ListProcRol(Rol r)
        {
            return await DRolesFormP.ListProcRol(r);
        }

        public static async Task<List<RolDTO>> ListRol()
        {
            return await DRolesFormP.ListRol();
        }

        public static async Task<List<RolDTO>> SearchRol(Rol rol)
        {
            return await DRolesFormP.SearchRol(rol);
        }

        public static async Task<string> AddRol(Rol rol)
        {
            return await DRolesFormP.AddRol(rol);
        }
        public static async Task<string> DisableRol(Rol rol)
        {
            return await DRolesFormP.DisableRol(rol);
        }

        public static async Task<string> EnableRol(Rol rol)
        {
            return await DRolesFormP.EnableRol(rol);
        }

        public static async Task<string> EnableFormRol(FormRol FrmRol)
        {
            return await DRolesFormP.EnableFormRol(FrmRol);
        }

        public static async Task<string> DisableFormRol(FormRol FrmRol)
        {
            return await DRolesFormP.DisableFormRol(FrmRol);
        }

        public static async Task<string> EnableProcedureRol(ProcedureRols prcRols)
        {
            return await DRolesFormP.EnableProcedureRol(prcRols);
        }

        public static async Task<string> DisableProcedureRol(ProcedureRols prcRols)
        {
            return await DRolesFormP.DisableProcedureRol(prcRols);
        }


    }
}
