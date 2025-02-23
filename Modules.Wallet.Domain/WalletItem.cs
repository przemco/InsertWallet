namespace Modules.Wallet.Domain
{
    public record WalletItem(WalletItemGuid Id, WalletGuid WalletId) 
    {
        public Money Voulume { get; set; }
    };
}
