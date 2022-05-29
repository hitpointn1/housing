namespace Housing.Services.Queries.Dto
{
    public class ElectricityBillDto : PaymentDto
    {
        public ValueDto? ConsumptionReadings { get; set; }
        public ValueDto? PreviousConsumptionReadings { get; set; }
    }
}
