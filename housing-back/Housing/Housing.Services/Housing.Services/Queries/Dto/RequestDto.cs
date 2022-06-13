using Housing.Data.Helpers;
using Housing.Services.Queries.Enums;
using System.ComponentModel.DataAnnotations;

namespace Housing.Services.Queries.Dto
{
    public class RequestDto
    {
        public RequestDto(string year, string month, ReportType? type)
        {
            var yearParsed = int.Parse(year);
            var monthParsed = int.Parse(month);

            Type = type ?? ReportType.Monthly;
            Date = Get(yearParsed, monthParsed, Type);
            EndDate = GetEnd(Date, Type);

            if (Date.HasValue)
            {
                PreviousDate = Get(Date.Value.AddMonths(-1), Type);
                PreviousEndDate = GetEnd(PreviousDate, Type);
            }
        }

        [EnumDataType(typeof(ReportType))]
        private ReportType Type { get; set; }

        public DateOnly? Date { get; set; }
        public DateOnly? EndDate { get; set; }
        public DateOnly? PreviousDate { get; set; }
        public DateOnly? PreviousEndDate { get; set; }

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
