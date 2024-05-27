using Digitall.Warehouse.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Digitall.Persistance.EF.Specifications
{
    internal static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> GetQuery<TEntity>(
            IQueryable<TEntity> inputQueryable,
            Specification<TEntity> specification)
            where TEntity : Entity
        {
            var queryable = inputQueryable.AsQueryable();

            if (specification.Criteria is not null)
            {
                queryable = queryable.Where(specification.Criteria);
            }

            queryable = specification.Includes.Aggregate(queryable, (current, include) =>
            {
               return current.Include(include);
            });

            if (specification.OrderByExpression is not null)
            {
                queryable = queryable.OrderBy(specification.OrderByExpression);
            }
            else if (specification.OrderByDescendingExpression is not null)
            {
                queryable = inputQueryable.OrderByDescending(specification.OrderByDescendingExpression);
            }

            if (specification.AsNoTracking)
            {
                queryable = queryable.AsNoTracking();
            }

            return queryable;
        }
    }
}
