using Housing.Services.Queries.Enums;

namespace Housing.Services.Pipes
{
    public interface IEnsureRecordExists
    {
        public DateTime? Date { get; set; }
        public DateTime? EndDate { get; set; }
        public ReportType Type { get; set; }
    }
}
