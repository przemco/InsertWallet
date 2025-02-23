namespace Modules.Cantor.Application.Abstractions.Services
{
    public interface ICurrencyService
    {
        string ResultDownload { get; }
        Task FetchCurrencyRates(string tableName, int cycleByMinutes, CancellationToken cancellationToken);
    }
}
