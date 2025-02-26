﻿using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Data.Config
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");

            builder.HasOne(p =>p.Brand).WithMany()
                .HasForeignKey(p => p.BrandId);

            builder.HasOne(p => p.ProductCategory).WithMany()
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
