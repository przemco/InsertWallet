using Modules.Wallet.Domain;

namespace Modules.Wallet.Infrastructure.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly WalletAppDbContext _walletAppDbContext;

        public UnitOfWork(WalletAppDbContext walletAppDbContext)
        {
            _walletAppDbContext = walletAppDbContext;
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var saves = await _walletAppDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
