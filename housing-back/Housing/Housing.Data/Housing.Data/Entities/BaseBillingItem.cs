namespace Housing.Data.Entities
{
    public abstract class BaseBillingItem
    {
        public long BillingId { get; set; }
        public Billing Billing { get; set; }
        public decimal Payment { get; set; }
    }
}
