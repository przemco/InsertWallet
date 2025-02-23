using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Cantor.Domain;

namespace Modules.Cantor.Infrastructure.Configurations
{
    class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasConversion(
                rateId => rateId.Value,
                value => new RateGuid(value));
        }
    }
}
