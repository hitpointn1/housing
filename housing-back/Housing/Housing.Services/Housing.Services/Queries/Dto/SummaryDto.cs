namespace Housing.Services.Queries.Dto
{
    public class SummaryDto
    {
        public decimal Total => TotalRent + TotalWithoutRent;
        public decimal TotalWithoutRent { get; set; }
        public decimal TotalRent { get; set; }
    }
}
