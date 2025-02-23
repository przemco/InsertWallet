using Microsoft.EntityFrameworkCore;
using Modules.Cantor.Domain;
using SQLitePCL;

namespace Modules.Wallet.Infrastructure
{
    public class CantorAppDbContext : DbContext
    {
        public CantorAppDbContext()
        {
            Batteries.Init();
            string path = Environment.CurrentDirectory;
            DBPath = Path.Join(path, "cantor.db");
        }

        public string DBPath { get; }

        public DbSet<CurrencyTable> CurrencyTables { get; set; }

        public DbSet<Rate> Rates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DBPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CantorAppDbContext).Assembly);
        }
    }
}
