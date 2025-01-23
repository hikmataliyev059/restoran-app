using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using restoran_app.Models;

namespace restoran_app.DAL.Context.Configurations.Positions;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("Positions");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}
