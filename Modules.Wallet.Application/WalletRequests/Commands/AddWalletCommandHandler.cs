using MediatR;
using Modules.Wallet.Application.Abstractions.Data;
using Modules.Wallet.Domain;

namespace Modules.Wallet.Application.WalletRequests.Commands
{
    public class AddWalletCommandHandler : IRequestHandler<AddWalletCommad>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddWalletCommandHandler(IWalletRepository walletRepository, IUnitOfWork unitOfWork)
        {
            this._walletRepository = walletRepository;
            this._unitOfWork = unitOfWork;
        }
        public async Task Handle(AddWalletCommad request, CancellationToken cancellationToken)
        {
            await _walletRepository.AddWallet(request.Wallet, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
