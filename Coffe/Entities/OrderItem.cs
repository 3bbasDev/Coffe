using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public decimal Price { get; set; }
        public Order? Order { get; set; }
        public Item? Item { get; set; }

    }
    public class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
    {

        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(f => f.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(f => f.OrderId).IsRequired();
            builder.Property(f => f.ItemId).IsRequired();
            builder.Property(f => f.Price).IsRequired();

            builder.HasOne(f => f.Order)
            .WithMany(f => f.Item)
            .HasForeignKey(f => f.OrderId);

            builder.HasOne(f => f.Item)
                .WithMany(f => f.Orders)
                .HasForeignKey(f => f.ItemId);
        }
    }

}
