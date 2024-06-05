using Digitall.Warehouse.Domain.Abstraction;
using System.Linq.Expressions;

namespace Digitall.Persistance.EF.Specifications
{
    public abstract class Specification<TEntity>(Expression<Func<TEntity, bool>>? criteria)
        where TEntity : Entity
    {

        public Expression<Func<TEntity, bool>>? Criteria { get; } = criteria;

        public List<Expression<Func<TEntity, object?>>> Includes { get; private set; } = [];

        public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }

        public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }

        public bool AsNoTracking { get; set; }

        public int? Take { get; set; }

        public int? Skip { get; set; }

        public bool AsSplitQuery { get; set; }

        protected void AddInclude(Expression<Func<TEntity, object?>> include)
            => Includes.Add(include);

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderBy)
            => OrderByExpression = orderBy;

        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescending)
            => OrderByDescendingExpression = orderByDescending;

    }
}
