namespace Housing.Services.Queries.Bills.Dto
{
    public class WaterBillDto : PaymentDto
    {
        public ValueDto? HotReadings { get; set; }
        public ValueDto? ColdReadings { get; set; }
    }
}
