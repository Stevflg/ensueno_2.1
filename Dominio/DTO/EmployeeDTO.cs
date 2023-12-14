namespace Dominio.DTO
{
    public class EmployeeDTO
    {
        public int? Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Cedula { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Correo { get; set; }
        //public byte[]? Imagen { get; set; }
        public DateTime? Creado { get; set; }
    }
}
