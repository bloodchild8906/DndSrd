using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Srd.Data.Models;

public class EffectMapping : IEntityTypeConfiguration<Effect>
{
    public void Configure(EntityTypeBuilder<Effect> builder)
    {
        builder.HasKey(effect => effect.Id);

        builder.Property(effect => effect.Name)
            .IsRequired();

        builder.Property(effect => effect.Description)
            .IsRequired();

        builder.HasOne(effect => effect.Action)
            .WithOne(action => action.Effect)
            .HasForeignKey<Action>(action => action.EffectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}