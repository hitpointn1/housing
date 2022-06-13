using System.Linq.Expressions;

namespace Housing.Data.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> expression) where T : class
        {
            return condition ? query.Where(expression) : query;
        }
    }
}
