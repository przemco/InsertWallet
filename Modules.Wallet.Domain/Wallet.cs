namespace Modules.Wallet.Domain
{
    public record Wallet(WalletGuid Id, TenantGuid TenantId, string Name)
    {
        private readonly HashSet<WalletItem> _items = new HashSet<WalletItem>();
        public IReadOnlyList<WalletItem> WalletItems => _items.ToList();

        public static Wallet Create(TenantGuid tenantId, string name)
        {
            var wallet = new Wallet(Id: new WalletGuid(Guid.NewGuid()), TenantId: tenantId, Name: name);

            return wallet;
        }

        public void PutOn(Money money)
        {
            var walletItem = new WalletItem(
                new WalletItemGuid(Guid.NewGuid()),
                Id)
            { Voulume = money };

            _items.Add(walletItem);
        }
        public void TakeOut(WalletItem item)
        {
            _items.Remove(item);            
        }
    }
}
