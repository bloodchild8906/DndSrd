﻿namespace Dnd.Srd.Data.Models;

public class Spell
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Level { get; set; }
    public string CastingTime { get; set; }
    public string Range { get; set; }
    public string Components { get; set; }
    public string Duration { get; set; }
    public Feature Feature { get; set; }
    public int FeatureId { get; set; }
}