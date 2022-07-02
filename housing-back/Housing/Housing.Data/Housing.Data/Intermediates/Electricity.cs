using Housing.Data.Helpers;

namespace Housing.Data.Intermediates
{
    public struct Electricity
    {
        public decimal? Payment;
        public decimal? PaymentAVG;
        public int? ConsumptionReadings;
        public int? ConsumptionReadingsMin;
        public int ConsumptionReadingsCount;

        public decimal ConsumptionPrediction(Electricity previous)
        {
            return MathHelper.Prediction(ConsumptionReadings, previous.ConsumptionReadingsMin, ConsumptionReadingsCount, previous.ConsumptionReadingsCount);
        }
    }
}
