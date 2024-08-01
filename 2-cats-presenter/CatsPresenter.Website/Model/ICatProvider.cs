namespace CatsPresenter.Website.Model;

public interface ICatProvider
{
    Task<CatInfo[]> GetRandomCatsAsync(int count);

    Task<CatInfo> GetRandomCatAsync();
}