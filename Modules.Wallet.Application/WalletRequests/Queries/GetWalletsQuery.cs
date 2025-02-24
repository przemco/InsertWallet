using MediatR;
using Modules.Wallet.Domain;

namespace Modules.Wallet.Application.WalletRequests.Queries
{
    public class GetWalletsQuery : IRequest<List<Domain.Wallet>>
    {
        public GetWalletsQuery(TenantGuid tenantId)
        {
            TenantId = tenantId;
        }

        public TenantGuid TenantId { get; }
    }
}
