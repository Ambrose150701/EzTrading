namespace EzTrading.Shared.Domain
{
    public class Item : BaseDomainModel
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }
    }
}
