using Ecommerce.Core.Entities;
using Ecommerce.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.RepositoriesContract
{
    public interface IGenericRepositories<T> where T : BaseEntity
    {

        Task<T?> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec);
        Task<T?> GetByIdWithSpecAsync( ISpecification<T> spec);
    
    }
}
