namespace Modules.Wallet.Domain
{
    public record Wallet
    {
        public Wallet(WalletGuid id, TenantGuid tenantId, string name)
        {
            Id = id;
            TenantId = tenantId;
            Name = name;
        }

        public HashSet<WalletItem> WalletItems { get; set; }

        public string Name { get; set; }
        public WalletGuid Id { get; init; }
        public TenantGuid TenantId { get; init; }

        public static Wallet Create(TenantGuid tenantId, string name)
        {
            var wallet = new Wallet(id: new WalletGuid(Guid.NewGuid()), tenantId: tenantId, name: name);

            return wallet;
        }

        public void PutOn(Money money)
        {


            if (!WalletItems.Any(i => i.Voulume.CurrencyCode == money.CurrencyCode))
            {
                var walletItem = new WalletItem(new WalletItemGuid(Guid.NewGuid()), Id){ Voulume = money };
                WalletItems.Add(walletItem);
            }
            else
            {
                var walletItem = WalletItems.Single(i => i.Voulume.CurrencyCode == money.CurrencyCode);
                walletItem.Voulume.Amount += money.Amount;
            }
        }
        public void TakeOut(Money money)
        {
            var walletItem = WalletItems.SingleOrDefault(i => i.Voulume.CurrencyCode == money.CurrencyCode);

            if (walletItem != null)
            {
                if (walletItem.Voulume.Amount >= money.Amount)
                {
                    walletItem.Voulume.Amount -= money.Amount;
                }
                else
                {
                    throw new Exception($"Insufficient funds in currency {money.CurrencyCode}");
                }
            }
            else
            {
                throw new NullReferenceException($"Cannot find wallet item with code {money.CurrencyCode}");
            }
        }
    }
}
