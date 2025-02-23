namespace Modules.Cantor.Domain
{
    public record Rate(RateGuid Id, CurrencyTableGuid CurrencyTablId, string Name, string Code, decimal Amount);
}
