namespace Dnd.Srd.Data.Models;

public class AbilityScore
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public Creature Creature { get; set; }
}

// Data Transfer Objects (DTOs) for the JSON data