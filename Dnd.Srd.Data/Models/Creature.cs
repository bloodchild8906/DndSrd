namespace Dnd.Srd.Data.Models;

public class Creature
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ChallengeRating { get; set; }
    public int ArmorClass { get; set; }
    public int HitPoints { get; set; }
    public int Speed { get; set; }
    public AbilityScore AbilityScore { get; set; }
    public ICollection<Action> Actions { get; set; }
    public ICollection<Condition> Conditions { get; set; }
    public int AbilityScoreId { get; set; }
}