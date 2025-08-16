using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>>? criteria { get ; set ; }
        public List<Expression<Func<T, object>>> includes { get; set ; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> orderBy { get ; set ; }
        public Expression<Func<T, object>> orderByDesc { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPagingEnabled { get; set; }

        public BaseSpecification()
        {
            
        }

        public BaseSpecification( Expression <Func<T,bool>>  expression)
        {
             criteria = expression;
        }

        public void AddOrderBy( Expression<Func<T, object>> orderByExpression)
        {
             orderBy = orderByExpression;
        }

        public void AddOrderByDesc(Expression<Func<T, object>> orderByExpression)
        {
            orderByDesc = orderByExpression;
        }

        public void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

    }
}
