using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIMS.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS.Infrastructure.Database.Configurations
{
    internal abstract class BaseEntityConfiguration<TEntity>
        : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnOrder(0);
            builder.Property(x => x.DateCreated).IsRequired().HasColumnOrder(1);
            builder.Property(x => x.DateUpdated).IsRequired(false).HasColumnOrder(2);
        }
    }
}
