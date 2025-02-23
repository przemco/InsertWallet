using MediatR;
using Modules.Cantor.Application.Abstractions.Services;

namespace Modules.Cantor.Application.CantorRequests.Commands
{
    public sealed class DownloadRatesCommandHandler : IRequestHandler<DownloadRatesCommand>
    {
        private readonly ICurrencyService _currencyService;

        public DownloadRatesCommandHandler(ICurrencyService currencyService)
        {
            this._currencyService = currencyService;
        }

        public async Task Handle(DownloadRatesCommand request, CancellationToken cancellationToken)
        {
            await _currencyService.FetchCurrencyRates(request.TableName, request.CycleByMinutes, cancellationToken);
        }
    }


}
