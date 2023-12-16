namespace Dominio.Database
{
    public class Rol
    {
        public int RolId { get; set; }
        public string? RolName { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date_Time { get; set; }
        public Employees? EmployeeNavigation { get; set; }
        public ICollection<FormRol> FormRolCollections { get; set; } = new List<FormRol>();
        public ICollection<UsersRol> UserRolCollections { get; set; } = new List<UsersRol>();
        public ICollection<ProcedureRols> ProceduresRolsCollections { get; set; } = new List<ProcedureRols>();
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set;}
        public DateTime? Date_Updated { get; set; }

    }
}