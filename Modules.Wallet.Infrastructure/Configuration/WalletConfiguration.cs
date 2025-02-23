using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Wallet.Domain;

namespace Modules.Wallet.Infrastructure.Configuration
{
    class WalletConfiguration : IEntityTypeConfiguration<Domain.Wallet>
    {
        public void Configure(EntityTypeBuilder<Domain.Wallet> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id).HasConversion(
                walletId => walletId.Value,
                value => new WalletGuid(value));

            builder.HasMany(w => w.WalletItems)
                .WithOne()
                .HasForeignKey(wi => wi.WalletId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
