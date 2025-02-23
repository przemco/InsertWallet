using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Wallet.Domain;

namespace Modules.Wallet.Infrastructure.Configuration
{
    class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id).HasConversion(
                tenantId => tenantId.Value,
                value => new TenantGuid(value));

            builder.HasIndex(i => i.Email).IsUnique();

            builder.HasMany(w => w.Wallets)
                .WithOne()
                .HasForeignKey(wi => wi.TenantId);
        }
    }
}
