namespace Dnd.Srd.Data.Models;

public class FeatureDto
{
    public int id { get; set; }
    public string name { get; set;}
    public string description{get;set;}
    public ActionDto action{get;set;}
    public ConditionDto condition{get;set;}
    public CharacterClassDto character_class{get;set;}
    public RaceDto race{get;set;}
    public SpellDto spell{get;set;}
}