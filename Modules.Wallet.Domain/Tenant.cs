namespace Modules.Wallet.Domain
{
    public record Tenant(TenantGuid Id, string Name, string Email)
    {
        public List<Wallet> Wallets { get; set; } = new();

        public static Tenant Create(string name, string email)
        {
            var tenant = new Tenant(Id: new TenantGuid(Guid.NewGuid()), name, email);

            return tenant;
        }
    }
}
