using MediatR;
using Modules.Cantor.Application.Abstractions.Data;

namespace Modules.Cantor.Application.CantorRequests.Queries
{
    public class GetRateByCodeQueryHandler : IRequestHandler<GetRateByCodeQuery, decimal>
    {
        private readonly ICantorRepository _cantorRepository;

        public GetRateByCodeQueryHandler(ICantorRepository cantorRepository)
        {
            this._cantorRepository = cantorRepository;
        }

        public async Task<decimal> Handle(GetRateByCodeQuery request, CancellationToken cancellationToken)
        {
            return await _cantorRepository.GetNewestRatebyCode(request.CurrencyCode, cancellationToken);
        }
    }
}
