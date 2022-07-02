using Housing.Data.Helpers;
using Housing.Services.Enums;
using System.ComponentModel.DataAnnotations;

namespace Housing.Services.Queries.Bills.Dto
{
    public class RequestDto
    {
        public RequestDto(int year, int month, ReportType? type)
        {
            Type = type ?? ReportType.Monthly;
            Date = Get(year, month, Type);
            EndDate = GetEnd(Date, Type);

            if (Date.HasValue)
            {
                PreviousDate = Get(Date.Value.AddMonths(-1), Type);
                PreviousEndDate = GetEnd(PreviousDate, Type);
            }
        }

        [EnumDataType(typeof(ReportType))]
        private ReportType Type { get; }

        public DateOnly? Date { get; }
        public DateOnly? EndDate { get; }
        public DateOnly? PreviousDate { get; }
        public DateOnly? PreviousEndDate { get; }

        private static DateOnly? Get(int year, int month, ReportType type)
        {
            return type switch
            {
                ReportType.Monthly => DateHelper.GetMonth(year, month),
                ReportType.Quaterly => DateHelper.GetQuarter(year, month),
                ReportType.Yearly => DateHelper.GetYear(year),
                ReportType.All => null,
                _ => throw new ArgumentOutOfRangeException(nameof(Date))
            };
        }

        private static DateOnly? Get(DateOnly date, ReportType type)
        {
            return Get(date.Year, date.Month, type);
        }

        private static DateOnly? GetEnd(DateOnly? startDate, ReportType type)
        {
            var start = startDate.GetValueOrDefault();
            return type switch
            {
                ReportType.Monthly => DateHelper.GetNextMonth(start),
                ReportType.Quaterly => DateHelper.GetNextQuarter(start),
                ReportType.Yearly => DateHelper.GetNextYear(start),
                ReportType.All => null,
                _ => throw new ArgumentOutOfRangeException(nameof(Date))
            };
        }
    }
}
