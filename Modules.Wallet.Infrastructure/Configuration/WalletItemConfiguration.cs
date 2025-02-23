using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Wallet.Domain;

namespace Modules.Wallet.Infrastructure.Configuration
{
    class WalletItemConfiguration : IEntityTypeConfiguration<WalletItem>
    {
        public void Configure(EntityTypeBuilder<WalletItem> builder)
        {
            builder.HasKey(wi => wi.Id);

            builder.Property(p => p.Id).HasConversion(
                wi => wi.Value,
                value => new WalletItemGuid(value));

            builder.ComplexProperty(p => p.Voulume).IsRequired();
        }
    }
}
