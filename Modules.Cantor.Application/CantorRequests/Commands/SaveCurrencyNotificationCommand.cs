using MediatR;
using Modules.Cantor.Domain;

namespace Modules.Cantor.Application.CantorRequests.Commands
{
    public class SaveCurrencyNotificationCommand : INotification
    {
        public SaveCurrencyNotificationCommand(CurrencyTable currencyTable, CancellationToken cancellationToken)
        {
            CurrencyTable = currencyTable;
            CancellationToken = cancellationToken;
        }

        public CurrencyTable CurrencyTable { get; }
        public CancellationToken CancellationToken { get; }
    }
}
