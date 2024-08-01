using Refit;

namespace CatsPresenter.Website.Model;

public interface ICatApiClient
{
    [Get("/v1/images/search?limit={count}")]
    public Task<CatInfo[]> GetRandomCatsAsync(int count);
}