using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CusID { get; set; }
        public Guid DelId { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid AddressId { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public User? Customer { get; set; }
        public User? Delevery { get; set; }
        public Address? Address { get; set; }

        public ICollection<OrderItem>? Item { get; set; }




        public class OrderConfigurations : IEntityTypeConfiguration<Order>
        {
            public void Configure(EntityTypeBuilder<Order> builder)
            {
                builder.Property(f => f.Id).IsRequired();
                builder.Property(f => f.CusID).IsRequired();
                builder.Property(f => f.DelId).IsRequired();
                builder.Property(f => f.CreationDate);
                builder.Property(f => f.AddressId).IsRequired();
                builder.Property(f => f.TotalAmount).IsRequired();
                builder.Property(f => f.Status).IsRequired();



                builder.HasOne(f => f.Customer)
                    .WithMany(f => f.Order)
                    .HasForeignKey(f => f.CusID);


                builder.HasOne(f => f.Delevery)
                    .WithMany(f => f.Order)
                    .HasForeignKey(f => f.DelId);

                builder.HasOne(f => f.Address)
                    .WithMany(f => f.Order)
                    .HasForeignKey(f => f.AddressId);

            }
        }

    }

}
