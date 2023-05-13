namespace Dnd.Srd.Data.Models;

public class Feature
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Action Action { get; set; }
    public Condition Condition { get; set; }
    public CharacterClass CharacterClass { get; set; }
    public Race Race { get; set; }
    public Spell Spell { get; set; }
    public object CharacterClassId { get; set; }
    public int RaceId { get; set; }
    public int SpellId { get; set; }
    public object ActionId { get; set; }
}