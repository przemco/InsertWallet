using MediatR;
using Modules.Wallet.Domain;

namespace Modules.Wallet.Application.CantorRequests.Queries
{
    public class ExchangeWalletQuery : IRequest<decimal>
    {
        public ExchangeWalletQuery(WalletItemGuid walletItemId, string currencyCode)
        {
            WalletItemId = walletItemId;
            CurrencyCode = currencyCode;
        }

        public WalletItemGuid WalletItemId { get; }
        public string CurrencyCode { get; }
    }
}
