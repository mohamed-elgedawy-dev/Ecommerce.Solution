using Ecommerce.Core.Entities;
using Ecommerce.Core.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository
{
    public static class SpecificationEvaluator <T> where T : BaseEntity
    {


        public static IQueryable<T> GetQuery( IQueryable<T> entry , ISpecification<T> spec )
        {

            var query  = entry;

            if (spec.criteria is not null)
            { 
            
                  query = query.Where(spec.criteria);

            }

            query= spec.includes.Aggregate(query ,(startQuery, nextQuery) => startQuery.Include(nextQuery));

            return query;

             
        }




    }
}
