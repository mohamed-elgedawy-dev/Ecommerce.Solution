using Ecommerce.Core.Entities;
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

    }
}
