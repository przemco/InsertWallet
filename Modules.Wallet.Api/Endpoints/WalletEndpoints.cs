
using MediatR;
using Modules.Wallet.Application.CantorRequests.Queries;
using Modules.Wallet.Application.WalletRequests.Commands;
using Modules.Wallet.Application.WalletRequests.Queries;
using Modules.Wallet.Domain;

namespace Modules.Wallet.Api.Endpoints
{
    public static class WalletEndpoints
    {
        public static void MapWalletEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/wallet/creatTenant", CreateTenant);
            app.MapPost("api/wallet/addWallet", AddWallet);
            app.MapGet("api/wallet/getWallets", GetWallets);
            app.MapPost("api/wallet/putCash", PutCash);
            app.MapPost("api/wallet/takeOutCash", TakeOutCash);
            app.MapGet("api/wallet/exchangeWallet", ExchangeWallet);
        }

        private static async Task<decimal> ExchangeWallet(Guid walletItemId, string curencyCode, ISender sender, CancellationToken cancellationToken)
        {
            var query = new ExchangeWalletQuery(new WalletItemGuid(walletItemId), curencyCode);
            return await sender.Send(query,cancellationToken);
        }

        private static async Task<IResult> TakeOutCash(Guid walletId, decimal amount, string currencyCode, ISender sender, CancellationToken cancellationToken)
        {
            var command = new TakeOutCashCommand(new WalletGuid(walletId), amount, currencyCode);
            await sender.Send(command,cancellationToken);

            return Results.Ok();
        }

        private static async Task<IResult> PutCash(Guid walletId, decimal amount, string currencyCode, ISender sender, CancellationToken cancellationToken)
        {
            var command = new PutCashCommand(new WalletGuid(walletId), amount, currencyCode);
            await sender.Send(command, cancellationToken);

            return Results.Ok();
        }

        private static async Task<List<Domain.Wallet>> GetWallets(Guid tenantId, ISender sender, CancellationToken cancellationToken)
        {
            var query = new GetWalletsQuery(new TenantGuid(tenantId));
            List<Domain.Wallet> list = await sender.Send(query, cancellationToken);

            return list;
        }

        private static async Task<IResult> AddWallet(Guid tenantId, string name, ISender sender, CancellationToken cancellationToken)
        {
            var wallet = Domain.Wallet.Create(new TenantGuid(tenantId), name);
            var command = new AddWalletCommad(wallet);
            await sender.Send(command, cancellationToken);

            return Results.Ok();
        }

        private static async Task<IResult> CreateTenant(string name, string email, ISender sender, CancellationToken cancellationToken)
        {
            var tenant = Tenant.Create(name, email);
            var command = new CreateTenantCommand(tenant);
            await sender.Send(command, cancellationToken);

            return Results.Ok();
        }
    }
}
