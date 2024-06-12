using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace LinkerBoard.API.Features.Common.CriteriaHelper;

internal static class ExpressionEvaluator
{
    internal static async Task<(long count, IEnumerable<T> data)> EvaluatePageQuery<T>(this IQueryable<T> query,
        FilterCriteria<T> criteria,
        CancellationToken cancellationToken = default) where T : class
    {
        query = query.IncludeExpressions(criteria.IncludeExpressions);
        query = query.FilterQuery(criteria.FiltersExpressions);
        long count = await query.CountAsync(cancellationToken);

        query = ApplyOrdering(query, criteria);

        if (criteria.IsPageRequest)
            query = query.ApplyPagination(criteria.PageNumber, criteria.PageSize);

        return (count, query.ApplySelect(criteria.Select));
    }

    internal static IQueryable<T> ApplyOrdering<T>(IQueryable<T> query,
        FilterCriteria<T> criteria)
        where T : class
    {
        if (criteria.OrderBy is not null)
            query = query.OrderBy(criteria.OrderBy);

        if (criteria.OrderByDescending is not null)
            query = query.OrderByDescending(criteria.OrderByDescending);

        return query;
    }

    internal static IEnumerable<T> ApplySelect<T>(this IQueryable<T> query,
        Expression<Func<T, T>>? select = null) where T : class
        => select is null ? query.AsEnumerable() : query.Select(select).AsEnumerable();


    internal static IQueryable<T> FilterQuery<T>(this IQueryable<T> query,
        Expression<Func<T, bool>>? filter = null) where T : class
    {
        if (filter is not null) query = query.Where(filter);
        return query;
    }
    
    internal static IQueryable<T> FilterQuery<T>(this IQueryable<T> query,
        List<Expression<Func<T, bool>>>? filterExpressions = null) where T : class
    {
        if(filterExpressions is null) return query;
        
        query = filterExpressions.Aggregate(query, (current, filter) => current.Where(filter));
        return query;
    }
    
    internal static IQueryable<T> IncludeExpressions<T>(this IQueryable<T> query,
        List<Expression<Func<T, object>>>? includeExpressions = null) where T : class
    {
        if (includeExpressions is null) return query;

        query = includeExpressions.Aggregate(query, (current, include) => current.Include(include));
        
        return query;
    }
    
    internal static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query,
        int pageNumber,
        int pageSize)
        where T : class
    {
        pageNumber = pageNumber < 0 ? 1 : pageNumber;
        pageSize = pageSize > AppConstant.MaxPageSize ? AppConstant.MaxPageSize : pageSize;
        int skip = (pageNumber - 1) * pageSize;
        return
            query
            .Skip(skip)
            .Take(pageSize);
    }
}