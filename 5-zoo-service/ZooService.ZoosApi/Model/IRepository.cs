namespace ZooService.ZoosApi;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync(bool loadAdditionalInfo = false);

    Task<T?> GetByIdAsync(long id, bool loadAdditionalInfo = false);

    Task<bool> UpdateAsync(T value);

    Task CreateAsync(T value);

    Task<bool> DeleteAsync(long id);
}
