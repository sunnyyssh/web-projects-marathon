using Microsoft.EntityFrameworkCore;
using SimpleShop.Database;

namespace SimpleShop.Model;

public sealed class DbProductProvider : IProductsProvider
{
    private readonly ShopDbContext _shopDbContext;

    public DbProductProvider(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }


    public IQueryable<Product> Products => _shopDbContext.Products;
}