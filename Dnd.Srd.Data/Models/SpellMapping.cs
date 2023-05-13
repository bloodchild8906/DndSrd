using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Srd.Data.Models;

public class SpellMapping : IEntityTypeConfiguration<Spell>
{
    public void Configure(EntityTypeBuilder<Spell> builder)
    {
        builder.HasKey(spell => spell.Id);

        builder.Property(spell => spell.Name)
            .IsRequired();

        builder.Property(spell => spell.Description)
            .IsRequired();

        builder.Property(spell => spell.Level)
            .IsRequired();

        builder.Property(spell => spell.CastingTime)
            .IsRequired();

        builder.Property(spell => spell.Range)
            .IsRequired();

        builder.Property(spell => spell.Components)
            .IsRequired();

        builder.Property(spell => spell.Duration)
            .IsRequired();

        builder.HasOne(spell => spell.Feature)
            .WithOne(feature => feature.Spell)
            .HasForeignKey<Feature>(feature => feature.SpellId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}