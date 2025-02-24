using MediatR;
using Modules.Wallet.Application.Abstractions.Data;
using Modules.Wallet.Domain;

namespace Modules.Wallet.Application.WalletRequests.Commands
{
    public class PutCashCommandHandler : IRequestHandler<PutCashCommand>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PutCashCommandHandler(IWalletRepository walletRepository, IUnitOfWork unitOfWork)
        {
            this._walletRepository = walletRepository;
            this._unitOfWork = unitOfWork;
        }
        public async Task Handle(PutCashCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetWalletById(request.WalletId, cancellationToken);
            
            if (wallet == null) 
                throw new NullReferenceException($"Cannot find wallet wit Id {request.WalletId}");
            
            wallet.PutOn(new Money(request.CurrencyCode, request.Amount));
            await _walletRepository.UpdateWallet(wallet, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
