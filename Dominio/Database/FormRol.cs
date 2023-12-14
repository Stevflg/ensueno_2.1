namespace Dominio.Database
{
    public class FormRol
    {
        public int? FormRolId { get; set; }
        public int RolId { get; set; }
        public Rol RolNavigation { get; set; }
        public int PermissionsId { get; set; }
        public int CreatedBy { get; set; }
        public Employees EmployeeNavigation{ get; set; }
        public Formularios FormsNavigation { get; set; }
        public  bool IsActive { get; set; }
        public DateTime Date_Time { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? Date_Updated{ get; set; }
    }
}
