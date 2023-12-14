namespace Dominio.Database
{
    public class StockMovementType
    {
        public int MovementId { get; set; }
        public string? Type { get; set; }
        public ICollection<StockMovement> StockMovementCollections { get; set; } 
            = new List<StockMovement>();
    }
}
