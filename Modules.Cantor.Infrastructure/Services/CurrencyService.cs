using MediatR;
using Modules.Cantor.Application.Abstractions.Data;
using Modules.Cantor.Application.Abstractions.Services;
using Modules.Cantor.Application.CantorRequests.Commands;
using Modules.Cantor.Domain;
using Modules.Cantor.Domain.JsonClass;
using System.Text.Json;

namespace Modules.Cantor.Infrastructure.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _client;
        private readonly IMediator _mediator;

        public CurrencyService(ICantorRepository cantorRepository, IMediator miediator)
        {
            this._client = new HttpClient();
            this._mediator = miediator;
        }

        public string ResultDownload { get; private set; }

        public async Task GetCurrencyRates(string tableName, CancellationToken cancellationToken)
        {
            string url = $"https://api.nbp.pl/api/exchangerates/tables/{tableName}?format=json";
            string json = await _client.GetStringAsync(url);
            json = json.Substring(1, json.Length - 2);

            if (json != null)
            {
                var currencyTable = JsonSerializer.Deserialize<CurrencyTableJson>(json) ?? throw new NullReferenceException("Not supported json");
                var currencyTableId = new CurrencyTableGuid(Guid.NewGuid());

                await _mediator.Publish(new SaveCurrencyNotificationCommand(
                    new CurrencyTable(currencyTableId,
                            currencyTable.table,
                            currencyTable.no,
                            currencyTable.effectiveDate
                        )
                    {
                        Rates = currencyTable.rates.Select(z =>
                        new Rate(new RateGuid(Guid.NewGuid()), currencyTableId, z.currency, z.code, z.mid)).ToList()
                    }, cancellationToken));
            }

        }

        public async Task FetchCurrencyRates(string tableName, int cycleByMinutes, CancellationToken cancellationToken)
        {
            //Zamiast Timer można użyć biblioteki Qartz lub Hangfire
            await RunJob(async () => await GetCurrencyRates(tableName, cancellationToken), TimeSpan.FromMinutes(cycleByMinutes), cancellationToken);
        }

        private async Task RunJob(Func<Task> task, TimeSpan interval, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await task();
                await Task.Delay(interval, cancellationToken);
            }
        }
    }
}
