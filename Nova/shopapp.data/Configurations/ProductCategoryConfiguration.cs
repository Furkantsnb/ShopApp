using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopapp.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace shopapp.data.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {

        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(c => new { c.CategoryId, c.ProductId });
        }
    }
}
