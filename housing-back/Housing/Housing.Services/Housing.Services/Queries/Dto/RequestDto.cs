using Housing.Data.Helpers;
using Housing.Services.Queries.Enums;
using System.ComponentModel.DataAnnotations;

namespace Housing.Services.Queries.Dto
{
    public class RequestDto
    {
        public RequestDto()
        {
            Date = DateHelper.CurrentMonth;
            Type = ReportType.Monthly;
        }

        public RequestDto(ReportType? type)
        {
            var reportType = type ?? ReportType.Monthly;

            Date = Get(DateHelper.CurrentMonth, reportType);
            Type = reportType;
        }

        public RequestDto(string year, string month, ReportType? type)
        {
            var reportType = type ?? ReportType.Monthly;
            var yearParsed = int.Parse(year);
            var monthParsed = int.Parse(month);

            Date = Get(yearParsed, monthParsed, reportType);
            Type = reportType;
        }

        public DateTime Date { get; set; }
        [EnumDataType(typeof(ReportType))]
        public ReportType Type { get; set; }

        private static DateTime Get(DateTime date, ReportType type)
        {
            return Get(date.Year, date.Month, type);
        }

        private static DateTime Get(int year, int month, ReportType type)
        {
            return type switch
            {
                ReportType.Monthly => DateHelper.GetMonth(year, month),
                ReportType.Quaterly => DateHelper.GetQuarter(year, month),
                ReportType.Yearly => DateHelper.GetYear(year),
                _ => throw new ArgumentOutOfRangeException(nameof(Date))
            };
        }
    }
}
