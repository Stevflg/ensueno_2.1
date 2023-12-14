namespace Dominio.Database
{
    public class Formularios
    {
        public int FormId { get; set; }
        public string? Name { get; set; }
        public string AliasForm { get; set; }
        public ICollection<FormRol> FormRolCollections { get; set; } = new List<FormRol>();
        public  int? UpdatedBy { get; set; }
        public Employees? EmployeeNavigation { get; set; }
    }
}