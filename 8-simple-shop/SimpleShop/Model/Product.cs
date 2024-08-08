namespace SimpleShop.Model;

public sealed class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? SupplierId { get; set; }

    public long CategoryId { get; set; }

    public Category? Category { get; set; }
}