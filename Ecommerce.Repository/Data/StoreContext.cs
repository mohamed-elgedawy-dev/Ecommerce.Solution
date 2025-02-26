﻿using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Data
{
    public class StoreContext:DbContext
    {


        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

     public   DbSet<Product> Products { get; set; }

      public  DbSet<ProductCategory> Categories { get; set; }

      public  DbSet<ProductBrand> Brands { get; set; }

    }
}
