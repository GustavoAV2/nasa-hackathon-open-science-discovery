﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenScienceProjects.API.Domain.Entities;

namespace OpenScienceProjects.API.Data.Configurations;

public class DiscussionConfiguration : IEntityTypeConfiguration<Discussion>
{
    public void Configure(EntityTypeBuilder<Discussion> builder)
    {
        builder.ToTable("discussion");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id").IsRequired();
        builder.Property(x => x.Title).HasColumnName("title").IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").IsRequired();
        builder.Property(x => x.ProjectId).HasColumnName("project_id").IsRequired();

        builder
            .HasOne(x => x.Project)
            .WithMany(x => x.ProjectDiscussions)
            .HasForeignKey(x => x.ProjectId)
            .HasPrincipalKey(x => x.Id);
    }
}