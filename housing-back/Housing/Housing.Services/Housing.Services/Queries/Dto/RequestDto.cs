using Housing.Data.Helpers;
using Housing.Services.Pipes;
using Housing.Services.Queries.Enums;
using System.ComponentModel.DataAnnotations;

namespace Housing.Services.Queries.Dto
{
    public class RequestDto : IEnsureRecordExists
    {
        public RequestDto(string year, string month, ReportType? type)
        {
            var yearParsed = int.Parse(year);
            var monthParsed = int.Parse(month);

            Type = type ?? ReportType.Monthly;
            Date = Get(yearParsed, monthParsed, Type);
            EndDate = GetEnd(Date, Type);
        }

        public DateTime? Date { get; set; }
        public DateTime? EndDate { get; set; }
        [EnumDataType(typeof(ReportType))]
        public ReportType Type { get; set; }

        private static DateTime? Get(int year, int month, ReportType type)
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

        private static DateTime? GetEnd(DateTime? startDate, ReportType type)
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
