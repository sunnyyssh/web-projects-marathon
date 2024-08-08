namespace SimpleShop.Model;

public interface ICategoriesProvider
{
    IQueryable<Category> Categories { get; }
}