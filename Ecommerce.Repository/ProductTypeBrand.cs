using Ecommerce.Core.Entities;
using Ecommerce.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository
{
    public class ProductTypeBrand : BaseSpecification<Product>
    {
        public ProductTypeBrand():base()
        {
            addInclude();
        }


        public ProductTypeBrand(int id) : base(p => p.Id == id)
        {
            
            addInclude();

        }
        
        private void addInclude()
        {
            includes.Add(p =>p.Brand);
            includes.Add(p => p.ProductCategory);

        }

    }
}
