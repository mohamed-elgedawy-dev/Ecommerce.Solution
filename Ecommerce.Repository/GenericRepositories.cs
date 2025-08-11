using Ecommerce.Core.Entities;
using Ecommerce.Core.RepositoriesContract;
using Ecommerce.Core.Specification;
using Ecommerce.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository
{
    public class GenericRepositories<T> : IGenericRepositories<T> where T : BaseEntity
    {
        private readonly StoreContext _dbcontext;

        public GenericRepositories(StoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbcontext.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }



        public async Task <IEnumerable <T>> GetAllWithSpecAsync( ISpecification<T> spec )
        {
            return await ApplySpecification(spec).ToListAsync();
        }


        //public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        //{
        //    return await ApplySpecification(spec).ToListAsync();
        //}




        public async Task<T?> GetByIdWithSpecAsync( ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }


        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        { 
           return SpecificationEvaluator<T>.GetQuery(_dbcontext.Set<T>(), spec);


        }

      

     
    }

}

