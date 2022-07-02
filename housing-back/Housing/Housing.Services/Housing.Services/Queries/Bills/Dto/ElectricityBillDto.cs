namespace Housing.Services.Queries.Bills.Dto
{
    public class ElectricityBillDto : PaymentDto
    {
        public ValueDto? ConsumptionReadings { get; set; }
    }
}
