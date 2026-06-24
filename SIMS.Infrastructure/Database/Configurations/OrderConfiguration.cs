using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIMS.Core;

namespace SIMS.Infrastructure.Database.Configurations
{
    internal class OrderConfiguration : BaseEntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.TotalAmount).HasPrecision(18, 2);
            builder.Property(x => x.PurchaseDate);

            builder.HasOne(x => x.Address)
                   .WithMany()
                   .HasForeignKey(x => x.AddressId)
                   .IsRequired();

            builder.HasMany(x => x.OrderItems)
                   .WithOne(x => x.Order)
                   .HasForeignKey(x => x.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
