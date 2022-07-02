using Housing.Data.Helpers;

namespace Housing.Services.Queries.Graph.Dto
{
    public class GraphRequestDto
    {
        public DateOnly Start { get; }
        public DateOnly PreviousMonthToStart { get; }
        public DateOnly End { get; }

        protected GraphRequestDto(int year)
        {
            Start = DateHelper.GetYear(year);
            PreviousMonthToStart = Start.AddMonths(-1);
            End = DateHelper.GetYearEnd(year);
        }
    }
}
