namespace EzTrading.Shared.Domain
{
    public class Payment : BaseDomainModel
    {
        public string Name { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
    }
}
