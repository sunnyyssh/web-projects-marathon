namespace StonesStore.Model;

public interface IStoneRepository
{
    IEnumerable<Stone> GetStones();
}
