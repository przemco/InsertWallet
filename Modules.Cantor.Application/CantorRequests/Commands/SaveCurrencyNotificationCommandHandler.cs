using MediatR;
using Modules.Cantor.Application.Abstractions.Data;
using Modules.Cantor.Domain;

namespace Modules.Cantor.Application.CantorRequests.Commands
{
    public class SaveCurrencyNotificationCommandHandler : INotificationHandler<SaveCurrencyNotificationCommand>
    {
        private readonly ICantorRepository _cantorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SaveCurrencyNotificationCommandHandler(ICantorRepository cantorRepository, IUnitOfWork unitOfWork)
        {
            this._cantorRepository = cantorRepository;
            this._unitOfWork = unitOfWork;
        }
        public async Task Handle(SaveCurrencyNotificationCommand notification, CancellationToken cancellationToken)
        {
            await _cantorRepository.Save(notification.CurrencyTable, notification.CancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
