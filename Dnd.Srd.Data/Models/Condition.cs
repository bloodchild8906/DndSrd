namespace Dnd.Srd.Data.Models;

public class Condition
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Effect Effect { get; set; }
    public Creature Creature { get; set; }
    public Feature Feature { get; set; }
    public int CreatureId { get; set; }
    public int FeatureId { get; set; }
}