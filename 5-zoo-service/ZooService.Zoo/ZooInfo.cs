namespace ZooService.Model.Zoo;

public class ZooInfo
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public long LocationId { get; set; }

    public Location? Location { get; set; }
}
