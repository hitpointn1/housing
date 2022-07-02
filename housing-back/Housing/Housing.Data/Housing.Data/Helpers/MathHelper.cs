namespace Housing.Data.Helpers
{
    public static class MathHelper
    {
        public static int? Diff(this int? current, int? previous)
        {
            if (!previous.HasValue)
                return 0;

            return (current ?? 0) - (previous ?? 0);
        }

        public static decimal? Diff(this decimal? current, decimal? previous)
        {
            if (!previous.HasValue)
                return 0;

            return (current ?? 0) - (previous ?? 0);
        }

        public static decimal Prediction(decimal? max, decimal? min, int countLeft, int countRight)
        {
            int count = countLeft + countRight;
            return ((max ?? 0) - (min ?? 0)) / (count == 0 ? 1 : count);
        }
    }
}
