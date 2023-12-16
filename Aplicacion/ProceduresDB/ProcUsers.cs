using Dominio.Database;
using Dominio.DTO;
using Persistencia.Proc;

namespace Aplicacion.ProceduresDB
{
    public static class ProcUsers
    {
        public static byte[] Encrypt(string pass)
        {
            return  DUsers.Encrypt(pass);
        }
        public static string EncryptUser(string pass)
        {
            return DUsers.EncryptUser(pass);
        }
        public static async Task<bool> UserLogin(Users obj)
        {
            return await DUsers.UserLogin(obj);
        }

        public static string AddUsers(Users obj)
        {
            return DUsers.AddUsers(obj);
        }

        public static async Task<Username> UserName(Users obj)
        {
            return await DUsers.UserName(obj);
        }

    }
}
