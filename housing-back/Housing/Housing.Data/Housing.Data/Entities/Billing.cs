namespace Housing.Data.Entities
{
    public class Billing
    {
        public long Id { get; set; }
        public DateOnly Date { get; set; }
        public string Appartments { get; set; }

        public AdditionalsBill Additionals { get; set; }
        public ElectricityBill ElectricityBill { get; set; }
        public WaterBill WaterBill { get; set; }
        public Rent Rent { get; set; }
        public HeatingBill HeatingBill { get; set; }
        public RepairsBill RepairsBill { get; set; }
    }
}
