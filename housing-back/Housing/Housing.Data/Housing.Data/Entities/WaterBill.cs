namespace Housing.Data.Entities
{
    public class WaterBill : BaseBillingItem
    {
        public int HotReadings { get; set; }
        public int ColdReadings { get; set; }
    }
}
