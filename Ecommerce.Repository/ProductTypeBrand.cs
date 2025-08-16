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
        public ProductTypeBrand(ProductSpecParams specParams) 
            :base(p => 
            
            (!specParams.BrandId.HasValue||p.BrandId== specParams.BrandId.Value)&&
            (!specParams.CategoryId.HasValue||p.CategoryId== specParams.CategoryId.Value)
            
            )
        {
            addInclude();

            if (!string.IsNullOrEmpty( specParams.sort))
            {

                switch ( specParams.sort) 
                {
                    case "priceAce":

                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":

                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        orderBy = p => p.Name;
                        break;





                }
            }
            else
                AddOrderBy(p => p.Name);


            ApplyPaging((specParams.PageIndex - 1) * specParams.PageSize, specParams.PageSize);

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
