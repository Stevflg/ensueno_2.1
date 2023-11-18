﻿using Dominio.Database;
using Dominio.DTO;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ProceduresDB
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
            catch (Exception ex) { return ex.InnerException.Message; }
        }
        public string UserName(Users obj)
        {
            try
            {
                using (var _context = new EnsuenoContext())
                {
                    var username = (from u in _context.Users
                                    join b in _context.Rols on u.RolId equals b.RolId
                                    join e in _context.Employees on u.EmployeeId equals e.EmployeeId
                                    where u.UserName == obj.UserName
                                    select new Username
                                    {
                                        UserId = u.UserId,
                                        UserName = e.EmployeeName + " " + e.EmployeeLastName,
                                        RolName = b.RolName
                                    }
                                   ).FirstOrDefault();
                    if (username != null)
                    {
                        return $"{username.UserName} : {username.RolName}";
                    }
                    return " ";
                }
            }
            catch { return " "; }
        }
    }
}
