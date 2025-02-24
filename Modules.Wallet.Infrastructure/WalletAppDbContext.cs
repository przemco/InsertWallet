using Microsoft.EntityFrameworkCore;
using Modules.Wallet.Domain;
using SQLitePCL;

namespace Modules.Wallet.Infrastructure
{
    public class WalletAppDbContext : DbContext
    {
        public WalletAppDbContext()
        {
            Batteries.Init();
            string path = Environment.CurrentDirectory;
            DBPath = Path.Join(path, "wallet.db");
            this.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Domain.Wallet> Wallets { get; set; }
        public DbSet<WalletItem> WalletItems { get; set; }

        public string DBPath { get; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DBPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WalletAppDbContext).Assembly);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.ChangeTracker.DetectChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
