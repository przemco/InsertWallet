using MediatR;

namespace Modules.Cantor.Application.CantorRequests.Commands
{
    public sealed class DownloadRatesCommand : IRequest
    {
        public DownloadRatesCommand(string tableName, int cycleByMinutes)
        {
            TableName = tableName;
            CycleByMinutes = cycleByMinutes;
        }

        public string TableName { get; init; }
        public int CycleByMinutes { get; }
    }
}
