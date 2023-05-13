using Dnd.Srd.Data.Models;
using Microsoft.EntityFrameworkCore;
using Action = Dnd.Srd.Data.Models.Action;

namespace Dnd.Srd.Infrastructure;

public class DndDbContext : DbContext
{
    public DbSet<AbilityScore> AbilityScores { get; set; }
    public DbSet<CharacterClass> CharacterClasses { get; set; }
    public DbSet<Creature> Creatures { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<Spell> Spells { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Action> Actions { get; set; }
    public DbSet<Condition> Conditions { get; set; }
    public DbSet<Effect> Effects { get; set; }

    // Other DbContext properties and methods

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the model relationships and constraints

        // Seed the database using the JsonToModelConverter
        var converter = new JsonToModelConverter();

        // Specify the JSON file URL for each model
        var abilityScoreJsonUrl = "https://raw.githubusercontent.com/palikhov/dnd-5e-srd-md-json/master/5esrd.json/ability_scores.json";
        var characterClassJsonUrl = "https://raw.githubusercontent.com/palikhov/dnd-5e-srd-md-json/master/5esrd.json/classes.json";
        var creatureJsonUrl = "https://raw.githubusercontent.com/palikhov/dnd-5e-srd-md-json/master/5esrd.json/monsters.json";
        var raceJsonUrl = "https://raw.githubusercontent.com/palikhov/dnd-5e-srd-md-json/master/5esrd.json/races.json";
        var spellJsonUrl = "https://raw.githubusercontent.com/palikhov/dnd-5e-srd-md-json/master/5esrd.json/spells.json";
        var featureJsonUrl = "https://raw.githubusercontent.com/palikhov/dnd-5e-srd-md-json/master/5esrd.json/features.json";
        var actionJsonUrl = "https://raw.githubusercontent.com/palikhov/dnd-5e-srd-md-json/master/5esrd.json/actions.json";
        var conditionJsonUrl = "https://raw.githubusercontent.com/palikhov/dnd-5e-srd-md-json/master/5esrd.json/conditions.json";
        var effectJsonUrl = "https://raw.githubusercontent.com/palikhov/dnd-5e-srd-md-json/master/5esrd.json/effects.json";

        // Fetch the JSON data from each URL and convert it to a list of model objects using the generic method
        var abilityScores = FetchAndConvertJsonData<AbilityScoreDto, AbilityScore>(abilityScoreJsonUrl, converter).Result;
        var characterClasses = FetchAndConvertJsonData<CharacterClassDto, CharacterClass>(characterClassJsonUrl, converter).Result;
        var creatures = FetchAndConvertJsonData<CreatureDto, Creature>(creatureJsonUrl, converter).Result;
        var races = FetchAndConvertJsonData<RaceDto, Race>(raceJsonUrl, converter).Result;
        var spells = FetchAndConvertJsonData<SpellDto, Spell>(spellJsonUrl, converter).Result;
        var features = FetchAndConvertJsonData<FeatureDto, Feature>(featureJsonUrl, converter).Result;
        var actions = FetchAndConvertJsonData<ActionDto, Action>(actionJsonUrl, converter).Result;
        var conditions = FetchAndConvertJsonData<ConditionDto, Condition>(conditionJsonUrl, converter).Result;
        var effects = FetchAndConvertJsonData<EffectDto, Effect>(effectJsonUrl, converter).Result;

        // Add the model objects to the database using the HasData method
        modelBuilder.Entity<AbilityScore>().HasData(abilityScores);
        modelBuilder.Entity<CharacterClass>().HasData(characterClasses);
        modelBuilder.Entity<Creature>().HasData(creatures);
        modelBuilder.Entity<Race>().HasData(races);
        modelBuilder.Entity<Spell>().HasData(spells);
        modelBuilder.Entity<Feature>().HasData(features);
        modelBuilder.Entity<Action>().HasData(actions);
        modelBuilder.Entity<Condition>().HasData(conditions);
        modelBuilder.Entity<Effect>().HasData(effects);
    }

    // A helper method to fetch the JSON data from a URL and convert it to a list of model objects using the generic method
    private async Task<List<TModel>> FetchAndConvertJsonData<TDto, TModel>(string jsonUrl, JsonToModelConverter converter)
    {
        // Create an HttpClient instance to send HTTP requests
        using (var client = new HttpClient())
        {
            // Get the JSON data from the URL as a string
            var json = await client.GetStringAsync(jsonUrl);

            // Convert the JSON data to a list of model objects using the generic method
            var modelList = converter.ConvertJsonToModels<TDto, TModel>(json);

            // Return the list of model objects
            return modelList;
        }
    }
}