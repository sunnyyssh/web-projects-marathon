﻿namespace ZooService.Model.Animals;

public sealed class AnimalInfo
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public AreaInfo? NaturalArea { get; set; }
}