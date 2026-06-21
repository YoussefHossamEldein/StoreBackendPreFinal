using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("NOW()");
            builder.HasOne(x => x.Customer).WithMany(c => c.CustomerOrders).HasForeignKey(x => x.CustomerId);
            builder.HasMany(x => x.OrderItems).WithOne(oi => oi.Order).HasForeignKey(oi => oi.OrderId);
        }
    }
}
