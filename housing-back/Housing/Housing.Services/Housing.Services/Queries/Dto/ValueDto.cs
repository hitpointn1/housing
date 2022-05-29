namespace Housing.Services.Queries.Dto
{
    public struct ValueDto
    {
        public ValueDto(decimal? value)
            :this(value ?? 0, 0, null)
        { }

        public ValueDto(decimal? value, decimal? diff)
            :this(value ?? 0, diff ?? 0, null)
        { }

        public ValueDto(decimal? value, decimal? diff, decimal? predictedValue)
        {
            Value = value;
            Diff = diff;
            PredictedValue = predictedValue;
        }

        public decimal? Value { get; set; }
        public decimal? Diff { get; set; }
        public decimal? PredictedValue { get; set; }

        public static ValueDto operator +(ValueDto? a, ValueDto? b)
        {
            var aV = a?.Value ?? 0;
            var bV = b?.Value ?? 0;
            var aDiff = a?.Diff ?? 0;
            var bDiff = b?.Diff ?? 0;
            return new(aV + bV, aDiff + bDiff);
        }
    }
}
