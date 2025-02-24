using MediatR;
using Modules.Wallet.Application.Abstractions.Data;
using Modules.Wallet.Domain;

namespace Modules.Wallet.Application.WalletRequests.Commands
{
    public class TakeOutCashCommandHandler : IRequestHandler<TakeOutCashCommand>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TakeOutCashCommandHandler(IWalletRepository walletRepository, IUnitOfWork unitOfWork)
        {
            this._walletRepository = walletRepository;
            this._unitOfWork = unitOfWork;
        }
        public async Task Handle(TakeOutCashCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetWalletById(request.WalletId, cancellationToken);

            if (wallet == null)
                throw new NullReferenceException($"Cannot find wallet with Id {request.WalletId}");

            wallet.TakeOut(new Money(request.CurrencyCode, request.Amount));
            await _walletRepository.UpdateWallet(wallet, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
