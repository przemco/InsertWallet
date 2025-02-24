using MediatR;
using Modules.Wallet.Application.Abstractions.Data;

namespace Modules.Wallet.Application.CantorRequests.Queries
{
    public class ExchangeWalletQueryHandler : IRequestHandler<ExchangeWalletQuery, decimal>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly HttpClient _client;

        public ExchangeWalletQueryHandler(IWalletRepository walletRepository)
        {
            this._client = new HttpClient();
            this._walletRepository = walletRepository;
        }
        public async Task<decimal> Handle(ExchangeWalletQuery request, CancellationToken cancellationToken)
        {
            var walletItem = await _walletRepository.GetWalletItemById(request.WalletItemId, cancellationToken);
            if (walletItem == null)
                throw new NullReferenceException($"Cannot find wallItem with id {request.WalletItemId}");

            if (walletItem.Voulume.CurrencyCode == "PLN")
            {
                string url = $"https://localhost:4040/api/cantor/GetRateByCode/{request.CurrencyCode}";
                var requestHttp = new HttpRequestMessage(HttpMethod.Get, url);
                //string rateStr = await (await _client.SendAsync(requestHttp)).EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                string rateStr = await _client.GetStringAsync(url);
                if (decimal.TryParse(rateStr, out decimal rate))
                {
                    var amount = walletItem.Voulume.Amount / rate;

                    return amount;
                }
                {
                    throw new Exception("Cannot parese rate");
                }
            }
            else
            {
                string urlMyRate = $"https://localhost:4040/api/cantor/GetRateByCode/{walletItem.Voulume.CurrencyCode}";
                string urlNewRate = $"https://localhost:4040/api/cantor/GetRateByCode/{request.CurrencyCode}";
                string rateMyStr = await _client.GetStringAsync(urlMyRate);
                string rateNewStr = await _client.GetStringAsync(urlNewRate);

                if (decimal.TryParse(rateMyStr, out decimal myRate) &&
                    decimal.TryParse(rateNewStr, out decimal newRate))
                {
                    var amount = (walletItem.Voulume.Amount * myRate) / newRate;

                    return amount;
                }
                {
                    throw new Exception("Cannot parese rate");
                }
            }
        }
    }
}
