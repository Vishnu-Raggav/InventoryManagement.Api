namespace InventoryManagement.Api.Domain;

public class Product
{
    public int Id { get; set; }
    public string Sku { get; set; }
    public string Name { get; set; }
    public double UnitPrice { get; set; }
    public int ReorderThreshold { get; set; }
    public int Quantity { get; set; }
}
