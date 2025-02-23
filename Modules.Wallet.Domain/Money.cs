namespace Modules.Wallet.Domain
{
    public record Money(string CurrencyCode, string CurrencyName)
    {
        public decimal Amount { get; set; }
        public char? CurrencySign { get; set; }
    }
}