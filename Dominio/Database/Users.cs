﻿namespace Dominio.Database
{
    public class Users
    {
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public Employees? EmployeesNavigation { get; set; }
        public string? UserName { get; set; }
        public byte[]? Password { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int Counter { get; set; }
        public bool Locked { get; set; }
        public DateTime Date_Time { get; set; }
        public ICollection<Sessions> SessionsCollection { get; set; } = new List<Sessions>();
        public ICollection<UsersRol> UserRolCollections { get; set; } = new List<UsersRol>();
        public int  RolId { get; set; }
        public Rol? RolNavigation { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? Update_date_time { get; set; }
    }
}
