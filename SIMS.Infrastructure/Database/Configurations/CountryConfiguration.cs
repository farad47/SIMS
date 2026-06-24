using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIMS.Core;

namespace SIMS.Infrastructure.Database.Configurations
{
    internal class CountryConfiguration : BaseEntityConfiguration<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Continent).HasConversion<int>().IsRequired();
            builder.Property(x => x.CountryCode).IsRequired().HasMaxLength(10);
        }
    }
}
