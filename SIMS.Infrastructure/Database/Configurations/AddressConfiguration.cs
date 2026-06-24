using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIMS.Core;

namespace SIMS.Infrastructure.Database.Configurations
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.Street).IsRequired().HasMaxLength(200);
            builder.Property(x => x.City).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PostCode).IsRequired().HasMaxLength(10);
            builder.HasOne(x => x.Country).WithMany().HasForeignKey(x => x.CountryId).IsRequired();
        }
    }
}
