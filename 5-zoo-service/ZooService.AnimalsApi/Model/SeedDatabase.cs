using ZooService.Model.Animals;

namespace ZooService.AnimalsApi;

public static class SeedDatabase
{
    public static void AddSomeAnimals(this AnimalsDbContext animalsDbContext)
    {
        if (animalsDbContext.Animals.Any())
        {
            return;
        }

        AreaInfo[] areas =
        [
            new() { Continent = Continents.Europe },
            new() { Continent = Continents.Africa | Continents.Asia },
            new() { Continent = Continents.NorthAmerica | Continents.Europe | Continents.Asia },
        ];

        AnimalInfo[] animals = 
        [
            new() { Name = "Elephant", NaturalArea = areas[1] },
            new() { Name = "Wolf", NaturalArea = areas[2] },
            new() { Name = "Owl", NaturalArea = areas[1] },
        ];

        animalsDbContext.Areas.AddRange(areas);
        animalsDbContext.Animals.AddRange(animals);

        animalsDbContext.SaveChanges();
    }
}
