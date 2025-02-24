using MediatR;
using Modules.Wallet.Domain;

namespace Modules.Wallet.Application.WalletRequests.Commands
{
    public class CreateTenantCommand : IRequest
    {
        public CreateTenantCommand(Tenant tenant)
        {
            Tenant = tenant;
        }

        public Tenant Tenant { get; }
    }
}
