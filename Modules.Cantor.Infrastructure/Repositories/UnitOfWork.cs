using Modules.Cantor.Domain;

namespace Modules.Cantor.Infrastructure.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly CantorAppDbContext _cantorAppDbContext;

        public UnitOfWork(CantorAppDbContext cantorAppDbContext)
        {
            _cantorAppDbContext = cantorAppDbContext;
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var saves = await _cantorAppDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
