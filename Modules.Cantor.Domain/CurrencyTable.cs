namespace Modules.Cantor.Domain
{
    public record CurrencyTable(CurrencyTableGuid Id, string Name, string No, DateTime EffectiveDate)
    {
        public List<Rate>? Rates { get; set; }
    }

}
