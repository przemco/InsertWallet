using MediatR;
using Modules.Wallet.Application.Abstractions.Data;
using Modules.Wallet.Domain;

namespace Modules.Wallet.Application.WalletRequests.Commands
{
    public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTenantCommandHandler(IWalletRepository walletRepository, IUnitOfWork unitOfWork)
        {
            this._walletRepository = walletRepository;
            this._unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateTenantCommand request, CancellationToken cancellationToken)
        {
            await _walletRepository.CreateTenant(request.Tenant, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
