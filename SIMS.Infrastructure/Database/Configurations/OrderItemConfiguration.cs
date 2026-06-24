using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIMS.Core;

namespace SIMS.Infrastructure.Database.Configurations
{
    internal class OrderItemConfiguration : BaseEntityConfiguration<OrderItem>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Unit).IsRequired();
            builder.Property(x => x.Price).HasPrecision(18, 2);
            builder.HasOne(x => x.Product)
                   .WithMany()
                   .HasForeignKey(x => x.ProductId)
                   .IsRequired();
        }
    }
}
