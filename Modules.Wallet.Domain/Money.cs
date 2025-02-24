namespace Modules.Wallet.Domain
{
    public record Money
    {
        public Money(string currencyCode, decimal amount)
        {
            CurrencyCode = currencyCode;
            Amount = amount;
        }
        public string? CurrencyName { get; set; }
        public decimal Amount { get; set; }
        public char? CurrencySign { get; set; }
        public string CurrencyCode { get; init; }
    }
}