namespace EzTrading.Shared.Domain
{
    public class Cart : BaseDomainModel
    {
        public string TotalPrice { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public int PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }


    }
}
