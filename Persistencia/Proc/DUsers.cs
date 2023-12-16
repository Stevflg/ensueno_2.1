using Dominio.Database;
using Dominio.DTO;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;
using System.Security.Cryptography;
using System.Text;

namespace Persistencia.Proc
{
    public static class DUsers
    {
        public static byte[] Encrypt(string pass)
        {
            SHA256 sHA256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sHA256.ComputeHash(encoding.GetBytes(pass));
            return stream;
        }
        public static string EncryptUser(string pass)
        {
            SHA256 sHA256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sHA256.ComputeHash(encoding.GetBytes(pass));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        public static async Task<bool> UserLogin(Users obj)
        {
            using (var context = new EnsuenoContext())
            {
                try
                {
                    var usuario = await (from u in context.Users
                                         where u.UserName.Equals(u.UserName)
                                         && u.IsActive.Equals(true) && u.Locked.Equals(false)
                                         select u).FirstAsync();
                    if (usuario != null)
                    {
                        if (EncryptUser(usuario.UserName).SequenceEqual(EncryptUser(obj.UserName)))
                        {
                            var result = (usuario.Password.SequenceEqual(obj.Password)) ? true : false;
                            if (!result)
                            {
                                usuario.Counter += 1;
                                usuario.Locked = (usuario.Counter > 2) ? true : false;
                                context.Entry(usuario).State = EntityState.Modified;
                                await context.SaveChangesAsync();
                                return result;
                            }
                            return result;
                        }
                        else
                        {
                            usuario.Counter += 1;
                            usuario.Locked = (usuario.Counter > 2) ? true : false;
                            context.Entry(usuario).State = EntityState.Modified;
                            await context.SaveChangesAsync();
                            return false;
                        }
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static string AddUsers(Users obj)
        {
            try
            {
                using (var _context = new EnsuenoContext())
                {
                    _context.Add(obj);
                    _context.SaveChanges();
                    return "Guardado Correctamente";
                }
            }
            catch (Exception ex) { return ex.InnerException.Message; }
        }

        public static async Task<Username> UserName(Users obj)
        {
            try
            {
                using (var _context = new EnsuenoContext())
                {
                    var username =await (from u in _context.Users
                                    join b in _context.Rols on u.RolId equals b.RolId
                                    join e in _context.Employees on u.EmployeeId equals e.EmployeeId
                                    where u.UserName == obj.UserName
                                    select new Username
                                    {
                                        UserId = u.UserId,
                                        EmployeeId = e.EmployeeId,
                                        UserName = e.EmployeeName + " " + e.EmployeeLastName,
                                        RolName = b.RolName,
                                        Image = e.Image
                                    }
                                   ).FirstOrDefaultAsync();
                    if (username != null)
                    {
                        return username;
                    }
                    return null;
                }
            }
            catch { return null; }
        }
    }
}
