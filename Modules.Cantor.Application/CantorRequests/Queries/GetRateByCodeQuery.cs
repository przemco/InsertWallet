using MediatR;

namespace Modules.Cantor.Application.CantorRequests.Queries
{
    public class GetRateByCodeQuery : IRequest<decimal>
    {
        public GetRateByCodeQuery(string currencyCode)
        {
            CurrencyCode = currencyCode;
        }

        public string CurrencyCode { get; }
    }
}
