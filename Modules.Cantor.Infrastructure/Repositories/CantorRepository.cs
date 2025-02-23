using Microsoft.EntityFrameworkCore;
using Modules.Cantor.Application.Abstractions.Data;
using Modules.Cantor.Domain;
using Modules.Wallet.Infrastructure;

namespace Modules.Cantor.Infrastructure.Repositories
{
    public class CantorRepository : ICantorRepository
    {
        private readonly CantorAppDbContext _cantorAppDbContext;

        public CantorRepository(CantorAppDbContext cantorAppDbContext)
        {
            this._cantorAppDbContext = cantorAppDbContext;
        }
        public async Task<decimal> GetNewestRatebyCode(string code, CancellationToken cancellationToken)
        {
            var currencyTbale = await _cantorAppDbContext.CurrencyTables
                .Include(ct => ct.Rates)
                .OrderBy(ct => ct.EffectiveDate)
                .FirstAsync();

            var rate = currencyTbale?.Rates?.Find(r => r.Code == code) ?? throw new Exception("Cannot find newest rate.");

            return rate.Amount;
        }

        public async Task Save(CurrencyTable currencyTable, CancellationToken cancellationToken)
        {
            using (var newContext = new CantorAppDbContext())
            {
                var fromDb = await newContext.CurrencyTables.FindAsync(currencyTable.Id);
                if (fromDb == null)
                {
                    await newContext.CurrencyTables.AddAsync(currencyTable);
                }

                await newContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
