namespace Housing.Services.Queries.Graph.Dto
{
    public struct ConsumptionVerticeDto
    {
        public DateOnly Date { get; set; }
        public int? Cold { get; set; }
        public int? Hot { get; set; }
        public int? Electricity { get; set; }
    }
}
