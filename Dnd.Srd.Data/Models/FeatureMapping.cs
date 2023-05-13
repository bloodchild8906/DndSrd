using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Srd.Data.Models;

public class FeatureMapping : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.HasKey(feature => feature.Id);

        builder.Property(feature => feature.Name)
            .IsRequired();

        builder.Property(feature => feature.Description)
            .IsRequired();

        builder.HasOne(feature => feature.Action)
            .WithOne(action => action.Feature)
            .HasForeignKey<Action>(action => action.FeatureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(feature => feature.Condition)
            .WithOne(condition => condition.Feature)
            .HasForeignKey<Condition>(condition => condition.FeatureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(feature => feature.CharacterClass)
            .WithOne(characterClass => characterClass.Feature)
            .HasForeignKey<CharacterClass>(characterClass => characterClass.FeatureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(feature => feature.Race)
            .WithOne(race => race.Feature)
            .HasForeignKey<Race>(race => race.FeatureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(feature => feature.Spell)
            .WithOne(spell => spell.Feature)
            .HasForeignKey<Spell>(spell => spell.FeatureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}