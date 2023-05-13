namespace Dnd.Srd.Data.Models;

public class ConditionDto
{
    public int id{get;set;}
    public string name{get;set;}
    public string description{get;set;}
    public EffectDto effect{get;set;}
    public FeatureDto feature{get;set;}
}