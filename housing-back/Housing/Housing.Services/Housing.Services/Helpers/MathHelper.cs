namespace Housing.Services.Helpers
{
    public static class MathHelper
    {
        public static decimal Diff(decimal? current, decimal? previous)
        {
            return (current ?? 0) - (previous ?? 0);
        }

        public static decimal Prediction(decimal? max, decimal? min, int countLeft, int countRight)
        {
            int count = countLeft + countRight;
            return ((max ?? 0) - (min ?? 0)) / (count == 0 ? 1 : count);
        }
    }
}
