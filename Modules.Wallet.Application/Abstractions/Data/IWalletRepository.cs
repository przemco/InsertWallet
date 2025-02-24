using Modules.Wallet.Domain;

namespace Modules.Wallet.Application.Abstractions.Data
{
    public interface IWalletRepository
    {
        Task<Tenant?> GetTenantById(TenantGuid tenantId, CancellationToken cancellationToken);
        Task CreateTenant(Tenant tenant, CancellationToken cancellationToken);
        Task AddWallet(Domain.Wallet wallet, CancellationToken cancellationToken);
        Task<Domain.Wallet?> GetWalletById(WalletGuid walletId, CancellationToken cancellationToken);
        Task<List<Domain.Wallet>> GetWallets(TenantGuid tenantId, CancellationToken cancellationToken);
        Task UpdateWallet(Domain.Wallet wallet, CancellationToken cancellationToken);
        Task<WalletItem?> GetWalletItemById(WalletItemGuid walletItemId, CancellationToken cancellationToken);
    }
}

