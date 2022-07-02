namespace Housing.Services.Queries.Graph.Dto
{
    public struct PaymentsVerticeDto
    {
        public DateOnly Date { get; set; }
        public decimal? Electricity { get; set; }
        public decimal? Additionals { get; set; }
        public decimal? Internet { get; set; }
        public decimal? Water { get; set; }
        public decimal? Rent { get; set; }
        public decimal? Repairs { get; set; }
        public decimal? Heating { get; set; }
    }
}
