namespace Dominio.DTO
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        public string Proveedor { get; set; }
        public string Direccion { get; set; }
        public string RUC { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime Creado { get; set; }
    }
}