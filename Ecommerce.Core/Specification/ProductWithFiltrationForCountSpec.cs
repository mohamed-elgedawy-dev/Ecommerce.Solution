﻿using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Specification
{
    public class ProductWithFiltrationForCountSpec:BaseSpecification<Product>
    {

        public ProductWithFiltrationForCountSpec(ProductSpecParams specParams) : base(p => 
            (!specParams.BrandId.HasValue || p.BrandId == specParams.BrandId.Value) &&
            (!specParams.CategoryId.HasValue || p.CategoryId == specParams.CategoryId.Value))
     
        {
            
        }


    }
}
