using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Srd.Data.Models;

public class RaceMapping : IEntityTypeConfiguration<Race>
{
    public void Configure(EntityTypeBuilder<Race> builder)
    {
        builder.HasKey(race => race.Id);

        builder.Property(race => race.Name)
            .IsRequired();

        builder.Property(race => race.Description)
            .IsRequired();

        builder.HasOne(race => race.Feature)
            .WithOne(feature => feature.Race)
            .HasForeignKey<Feature>(feature => feature.RaceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}