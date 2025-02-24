using MediatR;

namespace Modules.Wallet.Application.WalletRequests.Commands
{
    public class AddWalletCommad : IRequest
    {
        public AddWalletCommad(Domain.Wallet wallet)
        {
            Wallet = wallet;
        }

        public Domain.Wallet Wallet { get; }
    }
}
