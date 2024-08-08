using Microsoft.EntityFrameworkCore;
using SimpleShop.Database;

namespace SimpleShop.Model;

public sealed class DbCategoriesProvider : ICategoriesProvider
{
    private readonly ShopDbContext _shopDbContext;

    public DbCategoriesProvider(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public IQueryable<Category> Categories => _shopDbContext.Categories;
}