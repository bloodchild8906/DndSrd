using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Srd.Data.Models;

public class CharacterClassMapping:IEntityTypeConfiguration<CharacterClass>
{ 
    public void Configure(EntityTypeBuilder<CharacterClass> builder)
    {
        builder.HasKey(characterClass => characterClass.Id);

        builder.Property(characterClass => characterClass.Name)
            .IsRequired();

        builder.Property(characterClass => characterClass.Description)
            .IsRequired();

        builder.HasOne(characterClass => characterClass.Feature)
            .WithOne(feature => feature.CharacterClass)
            .HasForeignKey<Feature>(feature => feature.CharacterClassId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}