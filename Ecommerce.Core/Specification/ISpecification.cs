using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Specification
{
    public interface ISpecification <T> where T : BaseEntity
    {
        public Expression<Func<T,bool>>? criteria { set; get; }

        public List<Expression<Func<T, object>>> includes { set; get; }

        public Expression<Func <T, object>> orderBy { set; get; }
        public Expression<Func<T, object>> orderByDesc { set; get; }

        public int Skip { get; set; }

        public int Take { get; set; }


        public bool IsPagingEnabled { get; set; }








    }
}
