using Microsoft.EntityFrameworkCore;
using Modules.Wallet.Application.Abstractions.Data;
using Modules.Wallet.Domain;

namespace Modules.Wallet.Infrastructure.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly WalletAppDbContext _walletAppDbContext;

        public WalletRepository(WalletAppDbContext walletAppDbContext)
        {
            this._walletAppDbContext = walletAppDbContext;
        }
        public async Task AddWallet(Domain.Wallet wallet, CancellationToken cancellationToken)
        {
            var tenant = await this.GetTenantById(wallet.TenantId, cancellationToken);
            if (tenant != null)
            {
                tenant.Wallets.Add(wallet);
                await Task.FromResult(_walletAppDbContext.Tenants.Update(tenant));
            }
            else
            {
                throw new NullReferenceException("Cannot add wallet. Tenant is null.");
            }

            await _walletAppDbContext.SaveChangesAsync();
        }

        public async Task CreateTenant(Tenant tenant, CancellationToken cancellationToken)
        {
            await _walletAppDbContext.Tenants.AddAsync(tenant, cancellationToken);

            await _walletAppDbContext.SaveChangesAsync();
        }

        public async Task<Tenant?> GetTenantById(TenantGuid tenantId, CancellationToken cancellationToken)
        {
            return await _walletAppDbContext.Tenants
                .Include(t => t.Wallets)
                .ThenInclude(t => t.WalletItems)
                .SingleOrDefaultAsync(w => w.Id == tenantId);
        }

        public async Task<Domain.Wallet?> GetWalletById(WalletGuid walletId, CancellationToken cancellationToken)
        {
            return await _walletAppDbContext.Wallets
                .Include(w => w.WalletItems)
                .SingleOrDefaultAsync(wi => wi.Id == walletId);
        }

        public async Task<List<Domain.Wallet>> GetWallets(TenantGuid tenantId, CancellationToken cancellationToken)
        {
            return (await GetTenantById(tenantId, cancellationToken))?.Wallets ?? throw new NullReferenceException("Tenant is null");
        }

        public async Task UpdateWallet(Domain.Wallet wallet, CancellationToken cancellationToken)
        {
            var walletDb = await GetWalletById(wallet.Id, cancellationToken);
            if (walletDb != null)
            {
                await Task.FromResult(_walletAppDbContext.Wallets.Update(wallet));

                await _walletAppDbContext.SaveChangesAsync();
            }
            else
            {
                throw new NullReferenceException("Cannot update wallet. Wallet is null");
            }
        }
    }
}
