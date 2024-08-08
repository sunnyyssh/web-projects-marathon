namespace SimpleShop.Model;

public interface IProductsProvider
{
    IQueryable<Product> Products { get; }
}