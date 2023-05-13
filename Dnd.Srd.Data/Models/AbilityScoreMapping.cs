using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Srd.Data.Models;

public class AbilityScoreMapping : IEntityTypeConfiguration<AbilityScore>
{
    public void Configure(EntityTypeBuilder<AbilityScore> builder)
    {
        builder.HasKey(abilityScore => abilityScore.Id);

        builder.Property(abilityScore => abilityScore.Name)
            .IsRequired();

        builder.Property(abilityScore => abilityScore.Score)
            .IsRequired();

        builder.HasOne(abilityScore => abilityScore.Creature)
            .WithOne(creature => creature.AbilityScore)
            .HasForeignKey<Creature>(creature => creature.AbilityScoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}