using Housing.Data.Entities;
using Housing.Data.Intermediates;

namespace Housing.Data.Helpers
{
    public static class BillingQueryExtensions
    {
        public static IQueryable<Billing> WhereInRange(this IQueryable<Billing> query, DateOnly? start, DateOnly? end)
        {
            return query.WhereIf(start.HasValue && end.HasValue, v => v.Date >= start!.Value && v.Date <= end!.Value);
        }

        public static IQueryable<T> WhereInRange<T>(this IQueryable<T> query, DateOnly? start, DateOnly? end)
            where T : BaseBillingItem
        {
            return query.WhereIf(start.HasValue && end.HasValue, v => v.Billing.Date >= start!.Value && v.Billing.Date <= end!.Value);
        }

        public static IQueryable<Additionals> Aggregate(this IQueryable<AdditionalsBill> query, DateOnly? start, DateOnly? end)
        {
            return from q in query.WhereInRange(start, end)
                   group q by 1 into qGroup
                   select new Additionals
                   {
                       Internet = qGroup.Sum(v => v.Internet),
                       InternetAVG = Math.Round(qGroup.Average(v => v.Internet), 2),
                       Payment = qGroup.Sum(v => v.Payment),
                       PaymentAVG = Math.Round(qGroup.Average(v => v.Payment), 2)
                   };
        }

        public static IQueryable<Electricity> Aggregate(this IQueryable<ElectricityBill> query, DateOnly? start, DateOnly? end)
        {
            return from q in query.WhereInRange(start, end)
                   group q by 1 into qGroup
                   select new Electricity
                   {
                       Payment = qGroup.Sum(v => v.Payment),
                       PaymentAVG = Math.Round(qGroup.Average(v => v.Payment), 2),
                       ConsumptionReadings = qGroup.Max(v => v.ConsumptionReadings),
                       ConsumptionReadingsMin = qGroup.Min(v => v.ConsumptionReadings),
                       ConsumptionReadingsCount = qGroup.Count()
                   };
        }

        public static IQueryable<Water> Aggregate(this IQueryable<WaterBill> query, DateOnly? start, DateOnly? end)
        {
            return from q in query.WhereInRange(start, end)
                   group q by 1 into qGroup
                   select new Water
                   {
                       Payment = qGroup.Sum(v => v.Payment),
                       PaymentAVG = Math.Round(qGroup.Average(v => v.Payment), 2),
                       ColdReadings = qGroup.Max(v => v.ColdReadings),
                       ColdReadingsMin = qGroup.Min(v => v.ColdReadings),
                       HotReadings = qGroup.Max(v => v.HotReadings),
                       HotReadingsMin = qGroup.Min(v => v.HotReadings),
                       ReadingsCount = qGroup.Count()
                   };
        }

        public static IQueryable<PaymentAmount> Aggregate<T>(this IQueryable<T> query, DateOnly? start, DateOnly? end)
            where T : BaseBillingItem
        {
            return from q in query.WhereInRange(start, end)
                   group q by 1 into qGroup
                   select new PaymentAmount
                   {
                       Payment = qGroup.Sum(v => v.Payment),
                       PaymentAVG = Math.Round(qGroup.Average(v => v.Payment), 2)
                   };
        }
    }
}
