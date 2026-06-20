using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
            builder.Property(p => p.IsAvailable).HasDefaultValue(true).IsRequired();
            builder.Property(p => p.Price).HasPrecision(18, 2).IsRequired();
            builder.Property(p => p.Category).HasMaxLength(100).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.HasMany(x => x.OrderItems).WithOne(oi => oi.Product).HasForeignKey(oi => oi.ProductId);
        }
    }
}
