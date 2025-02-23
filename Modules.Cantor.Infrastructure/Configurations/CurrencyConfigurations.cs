using Microsoft.EntityFrameworkCore;
using Modules.Cantor.Domain;

namespace Modules.Cantor.Infrastructure.Configurations
{
    class CurrencyConfigurations : IEntityTypeConfiguration<CurrencyTable>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CurrencyTable> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasConversion(
                currencId => currencId.Value,
                value => new CurrencyTableGuid(value));
            builder.HasMany(t => t.Rates)
                .WithOne()
                .HasForeignKey(r => r.CurrencyTablId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
