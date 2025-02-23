using MediatR;
using Modules.Cantor.Application.Abstractions.Data;

namespace Modules.Cantor.Application.CantorRequests.Commands
{
    public class SaveCurrencyNotificationCommandHandler : INotificationHandler<SaveCurrencyNotificationCommand>
    {
        private readonly ICantorRepository _cantorRepository;

        public SaveCurrencyNotificationCommandHandler(ICantorRepository cantorRepository)
        {
            this._cantorRepository = cantorRepository;
        }
        public async Task Handle(SaveCurrencyNotificationCommand notification, CancellationToken cancellationToken)
        {
            await _cantorRepository.Save(notification.CurrencyTable, notification.CancellationToken);
        }
    }
}
