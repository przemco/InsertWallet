using MediatR;
using Modules.Wallet.Application.Abstractions.Data;

namespace Modules.Wallet.Application.WalletRequests.Queries
{
    public class GetWalletsQueryHandler : IRequestHandler<GetWalletsQuery, List<Domain.Wallet>>
    {
        private readonly IWalletRepository _walletRepository;

        public GetWalletsQueryHandler(IWalletRepository walletRepository)
        {
            this._walletRepository = walletRepository;
        }
        public async Task<List<Domain.Wallet>> Handle(GetWalletsQuery request, CancellationToken cancellationToken)
        {
            return await _walletRepository.GetWallets(request.TenantId, cancellationToken);
        }
    }
}
