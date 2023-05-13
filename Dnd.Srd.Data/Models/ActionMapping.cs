using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Srd.Data.Models;

public class ActionMapping : IEntityTypeConfiguration<Action>
{
    public void Configure(EntityTypeBuilder<Action> builder)
    {
        builder.HasKey(action => action.Id);

        builder.Property(action => action.Name)
            .IsRequired();

        builder.Property(action => action.Description)
            .IsRequired();

        builder.HasOne(action => action.Feature)
            .WithOne(feature => feature.Action)
            .HasForeignKey<Feature>(feature => feature.ActionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}