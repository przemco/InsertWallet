using Modules.Cantor.Domain;

namespace Modules.Cantor.Application.Abstractions.Data
{
    public interface ICantorRepository
    {
        Task Save(CurrencyTable currencyTable, CancellationToken cancellationToken);

        Task<decimal> GetNewestRatebyCode(string code, CancellationToken cancellationToken);
    }
}
