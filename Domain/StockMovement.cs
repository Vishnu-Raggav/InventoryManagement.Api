namespace InventoryManagement.Api.Domain;

public class StockMovement
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public int ProductId { get; set; }
    public int ChangeAmount { get; set; }
    public DateTime MovedAt { get; set; }
    public StockMovementType Type { get; set; }
    public StockMovementReason Reason { get; set; }
}

public enum StockMovementType
{
    Add,
    Reduce,
}

public enum StockMovementReason
{
    Sale,
    Restock,
    Correction,
    Damaged,
}