using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Data
{
    public static class StoreContextSeeding
    {

        public static async Task SeedAsync (StoreContext _dbContext)
        {

             

           

            
                if(_dbContext.Brands.Count()==0)
                {
                    var brandsData = File.ReadAllText("../Ecommerce.Repository/Data/DataSeeding/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    if (brands?.Count > 0)
                    {
                        foreach (var brand in brands)
                        {
                            _dbContext.Set<ProductBrand>().Add(brand);
                        }

                        await _dbContext.SaveChangesAsync();
                    }

                

            }


            if (_dbContext.Categories.Count()==0)
            {
                var categoriesData = File.ReadAllText("../Ecommerce.Repository/Data/DataSeeding/categories.json");


                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);

                if (categories?.Count>0)
                {
                    foreach (var category in categories)
                    {
                        _dbContext.Set<ProductCategory>().Add(category);
                    }

                    await _dbContext.SaveChangesAsync();  
                }
            }




            if (_dbContext.Products.Count()==0)
            {
                var productsData = File.ReadAllText("../Ecommerce.Repository/Data/DataSeeding/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products?.Count>0)
                {
                    foreach (var product in products)
                    {
                        _dbContext.Set<Product>().Add(product);
                    }

                    await _dbContext.SaveChangesAsync();  
                }
            }





        }



















    }
}
