namespace Dnd.Srd.Data.Models;

public class Race
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Feature Feature { get; set; }
    public int FeatureId { get; set; }
}