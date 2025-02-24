using Microsoft.EntityFrameworkCore;
using Modules.Cantor.Domain;
using SQLitePCL;

namespace Modules.Cantor.Infrastructure
{
    public class CantorAppDbContext : DbContext
    {
        public CantorAppDbContext()
        {
            Batteries.Init();
            string path = Environment.CurrentDirectory;
            DBPath = Path.Join(path, "cantor.db");
            this.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public string DBPath { get; }

        public DbSet<CurrencyTable> CurrencyTables { get; set; }

        public DbSet<Rate> Rates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DBPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CantorAppDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.ChangeTracker.DetectChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
