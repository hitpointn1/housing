using Housing.Data.Programmability;
using Microsoft.EntityFrameworkCore;

namespace Housing.Data
{
    public partial class HousingContext
    {
        public IQueryable<DetailedSummary> GetSummary(DateOnly? start, DateOnly? end, DateOnly? prevStart, DateOnly? prevEnd)
        {
            return Set<DetailedSummary>().FromSqlRaw("SELECT * FROM bills.get_summary({0}, {1}, {2}, {3})", start, end, prevStart, prevEnd);
        }

        public IQueryable<Summary> GetSummary(DateOnly? start, DateOnly? end)
        {
            return Set<DetailedSummary>().FromSqlRaw("SELECT * FROM bills.get_total({0}, {1})", start, end);
        }
    }
}
