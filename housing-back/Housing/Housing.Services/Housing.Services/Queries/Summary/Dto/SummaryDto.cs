using Housing.Services.Queries.Bills.Dto;

namespace Housing.Services.Queries.Summary.Dto
{
    public class SummaryDto
    {
        public ValueDto Total => TotalRent + TotalWithoutRent;
        public ValueDto? TotalWithoutRent { get; set; }
        public ValueDto? TotalRent { get; set; }
    }
}
