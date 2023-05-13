using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Srd.Data.Models;

public class ConditionMapping : IEntityTypeConfiguration<Condition>
{
    public void Configure(EntityTypeBuilder<Condition> builder)
    {
        builder.HasKey(condition => condition.Id);

        builder.Property(condition => condition.Name)
            .IsRequired();

        builder.Property(condition => condition.Description)
            .IsRequired();

        builder.HasOne(condition => condition.Effect)
            .WithOne(effect => effect.Condition)
            .HasForeignKey<Effect>(effect => effect.ConditionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}