namespace ZooService.Model.Animals;

/// <summary>
/// Seven-continent model is used.
/// </summary>
[Flags]
public enum Continents
{
    Africa = 1,
    Europe = 1 << 1,
    Asia = 1 << 2,
    Australia = 1 << 3,
    NorthAmerica = 1 << 4,
    SouthAmerica = 1 << 5,
    Antarctica = 1 << 6
}
