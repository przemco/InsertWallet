namespace Modules.Cantor.Domain.JsonClass
{
    public class CurrencyTableJson
    {
        public string table { get; set; }
        public string no { get; set; }
        public DateTime effectiveDate { get; set; }
        public List<RateJson> rates { get; set; }
    }
}
