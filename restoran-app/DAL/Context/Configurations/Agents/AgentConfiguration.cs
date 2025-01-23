﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using restoran_app.Models;

namespace restoran_app.DAL.Context.Configurations.Agents;

public class AgentConfiguration : IEntityTypeConfiguration<Agent>
{
    public void Configure(EntityTypeBuilder<Agent> builder)
    {
        builder.ToTable("Agents");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Position)
            .WithMany(x => x.Agents)
            .HasForeignKey(x => x.PositionId);

        builder.Ignore(x => x.File);
    }
}
