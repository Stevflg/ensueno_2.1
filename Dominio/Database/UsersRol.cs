namespace Dominio.Database
{
    public class UsersRol
    {
        public int Id { get; set; }
        public int IdUser {  get; set; }
        public int IdRol { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set;}
        public DateTime? UpdatedDate { get; set; }
        public Rol? RolNavigation { get; set; }
        public Users? UsersNavigation { get; set; }

    }
}
