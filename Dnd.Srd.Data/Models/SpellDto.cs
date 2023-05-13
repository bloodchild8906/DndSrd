namespace Dnd.Srd.Data.Models;

public class SpellDto
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int level { get; set; }
    public string casting_time { get; set; }
    public string range { get; set; }
    public string components { get; set; }
    public string duration { get; set; }
    public FeatureDto feature { get; set; }
}