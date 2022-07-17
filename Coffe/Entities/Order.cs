

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coffe.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CusID { get; set; }
        public User Customer { get; set; }
        public Guid DelId { get; set; }
        public User Delevery { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid AddressId { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }

        public Address? Address { get; set; }

        public ICollection<OrderItem>? Item { get; set; }

    }
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(f => f.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(f => f.CusID).IsRequired();
            builder.Property(f => f.DelId).IsRequired();
            builder.Property(f => f.CreationDate);
            builder.Property(f => f.AddressId).IsRequired();
            builder.Property(f => f.TotalAmount).IsRequired();
            builder.Property(f => f.Status).IsRequired();



            builder.HasOne(f => f.Customer)
                .WithMany(f => f.OrderCustomer)
                .HasForeignKey(f => f.CusID);


            builder.HasOne(f => f.Delevery)
                .WithMany(f => f.OrderDelever)
                .HasForeignKey(f => f.DelId);

            builder.HasOne(f => f.Address)
                .WithMany(f => f.Order)
                .HasForeignKey(f => f.AddressId);

        }
    }

}
