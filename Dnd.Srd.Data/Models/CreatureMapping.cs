using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Srd.Data.Models;

public class CreatureMapping : IEntityTypeConfiguration<Creature>
{
    public void Configure(EntityTypeBuilder<Creature> builder)
    {
        builder.HasKey(creature => creature.Id);

        builder.Property(creature => creature.Name)
            .IsRequired();

        builder.Property(creature => creature.Description)
            .IsRequired();

        builder.Property(creature => creature.ChallengeRating)
            .IsRequired();

        builder.Property(creature => creature.ArmorClass)
            .IsRequired();

        builder.Property(creature => creature.HitPoints)
            .IsRequired();

        builder.Property(creature => creature.Speed)
            .IsRequired();

        builder.HasOne(creature => creature.AbilityScore)
            .WithOne(abilityScore => abilityScore.Creature)
            .HasForeignKey<Creature>(creature => creature.AbilityScoreId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(creature => creature.Actions)
            .WithOne(action => action.Creature)
            .HasForeignKey(action => action.CreatureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(creature => creature.Conditions)
            .WithOne(condition => condition.Creature)
            .HasForeignKey(condition => condition.CreatureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}