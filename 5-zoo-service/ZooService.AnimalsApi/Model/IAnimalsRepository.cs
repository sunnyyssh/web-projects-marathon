using ZooService.Model.Animals;

namespace ZooService.AnimalsApi;

public interface IAnimalsRepository
{
    Task<IEnumerable<AnimalInfo>> GetAllAsync(bool loadAdditionalInfo = false);

    Task<AnimalInfo?> GetByIdAsync(long id, bool loadAdditionalInfo = false);

    Task<bool> UpdateAsync(AnimalInfo animal);

    Task CreateAsync(AnimalInfo animal);

    Task<bool> DeleteAsync(long id);
}
