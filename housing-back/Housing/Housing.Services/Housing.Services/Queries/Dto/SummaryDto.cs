namespace Housing.Services.Queries.Dto
{
    public class SummaryDto
    {
        public ValueDto Total => TotalRent + TotalWithoutRent;
        public ValueDto? TotalWithoutRent { get; set; }
        public ValueDto? TotalRent { get; set; }
    }
}
