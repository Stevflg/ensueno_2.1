using Dominio.Database;
using Dominio.DTO;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
        public static bool UserLogin(Users obj)
        {
            using (var _context = new EnsuenoContext())
            {
                var user = (from u in _context.Users
                            where u.UserName == obj.UserName && u.Password == obj.Password
                            && u.IsActive == true
                            select u).FirstOrDefault();
                if (user != null)
                {
                    if (EncryptUser(user.UserName)==EncryptUser(obj.UserName)) return true;
                    else return false;
                }
                else return false;
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
