using Dominio.Database;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Procedures
{
    public class ProcUsers
    {

        public byte[] Encrypt(string pass)
        {
            SHA256 sHA256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sHA256.ComputeHash(encoding.GetBytes(pass));
            //for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return stream;
        }
        public string EncryptUser(string pass)
        {
            SHA256 sHA256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sHA256.ComputeHash(encoding.GetBytes(pass));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        public bool UserLogin(Users obj)
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

        public string AddUsers(Users obj)
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
            catch (Exception ex) { return ex.Message; }
        }
    }
}
