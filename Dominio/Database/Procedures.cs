namespace Dominio.Database
{
    public class Procedures
    {
        public int ProcedureId { get; set; }
        public string? ProcedureName { get; set; }
        public ICollection<ProcedureRols> ProceduresRolsCollections { get; set; } = new List<ProcedureRols>();
    }
}