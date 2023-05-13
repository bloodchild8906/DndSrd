namespace Dnd.Srd.Data.Models;

public class CreatureDto
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int challenge_rating { get; set; }
    public int armor_class { get; set; }
    public int hit_points { get; set; }
    public int speed { get; set; }
    public AbilityScoreDto ability_scores { get; set; }
    public List<ActionDto> actions { get; set; }
    public List<ConditionDto> conditions { get; set; }
}