using MediatR;
using Modules.Wallet.Domain;

namespace Modules.Wallet.Application.WalletRequests.Commands
{
    public class PutCashCommand : IRequest
    {
        public PutCashCommand(WalletGuid walletId, decimal amount, string currencyCode)
        {
            WalletId = walletId;
            Amount = amount;
            CurrencyCode = currencyCode;
        }

        public WalletGuid WalletId { get; }
        public decimal Amount { get; }
        public string CurrencyCode { get; }
    }
}
