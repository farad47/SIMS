using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIMS.Core;

namespace SIMS.Infrastructure.Database.Configurations
{
    internal class AddressConfiguration : BaseEntityConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Street).IsRequired().HasMaxLength(200);
            builder.Property(x => x.City).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PostCode).IsRequired().HasMaxLength(10);
            builder.HasOne(x => x.Country)
                   .WithMany()
                   .HasForeignKey(x => x.CountryId)
                   .IsRequired();
        }
    }
}
