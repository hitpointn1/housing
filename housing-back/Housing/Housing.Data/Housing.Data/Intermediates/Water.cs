using Housing.Data.Helpers;

namespace Housing.Data.Intermediates
{
    public struct Water
    {
        public decimal? Payment;
        public decimal? PaymentAVG;
        public int? ColdReadings;
        public int? ColdReadingsMin;
        public int? HotReadings;
        public int? HotReadingsMin;
        public int ReadingsCount;

        public decimal ColdPrediction(Water previous)
        {
            return MathHelper.Prediction(ColdReadings, previous.ColdReadingsMin, ReadingsCount, previous.ReadingsCount);
        }

        public decimal HotPrediction(Water previous)
        {
            return MathHelper.Prediction(HotReadings, previous.HotReadingsMin, ReadingsCount, previous.ReadingsCount);
        }
    }
}
