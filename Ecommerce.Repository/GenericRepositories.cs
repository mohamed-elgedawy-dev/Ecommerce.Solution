using Ecommerce.Core.Entities;
using Ecommerce.Core.RepositoriesContract;
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
            return await _dbcontext.Set<T>().ToListAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }
    }

}

