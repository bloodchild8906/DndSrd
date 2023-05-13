namespace Dnd.Srd.Data.Models;

public class Effect
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Action Action { get; set; }
    public int ConditionId { get; set; }
    public Condition Condition { get; set; }
}