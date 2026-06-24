using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIMS.Core;

namespace SIMS.Infrastructure.Database.Configurations
{
    internal class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(50);
            builder.Property(x => x.Price).HasPrecision(18, 2);
            builder.Property<int>(x => x.Stock).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            //builder.HasOne(x => x.Category)
            //       .WithMany()
            //       .HasForeignKey(x => x.CategoryId)
            //       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
