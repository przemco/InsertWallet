using MediatR;
using Modules.Cantor.Application.CantorRequests.Commands;
using Modules.Cantor.Application.CantorRequests.Queries;

namespace Modules.Cantor.Presentation.Endpoints
{
    public static class CantorEndpoints
    {
        public static void MapCantorEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/cantor/DownloadStart", DownloadStart);
            app.MapGet("api/cantor/GetRateByCode/{currencyCode}", GetRateByCode);
        }

        private static async Task<decimal> GetRateByCode(string currencyCode, ISender sender)
        {
            var query = new GetRateByCodeQuery(currencyCode);

            decimal result = await sender.Send(query);

            return result;
        }

        private static async Task<IResult> DownloadStart(string tableName, int cycleByMinutes, ISender sender)
        {
            var command = new DownloadRatesCommand(tableName, cycleByMinutes);

            await sender.Send(command);

            return Results.Ok();
        }
    }
}
