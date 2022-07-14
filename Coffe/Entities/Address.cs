using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Entities
{
    public class Address
    {
        public Guid? Id { get; set; }

        public double? Long { get; set; }
        public double? Lat { get; set; }
        public string? Street { get; set; }
        public string? Desc { get; set; }
        public Guid? UserID { get; set; }
        public User? User { get; set; }
        public ICollection<Order>? Order { get; set; }


        public class AddressConfigurasions : IEntityTypeConfiguration<Address>
        {
            public void Configure(EntityTypeBuilder<Address> builder)
            {
                builder.Property(f => f.Id).IsRequired();
                builder.Property(f => f.Long).IsRequired();
                builder.Property(f => f.Lat).IsRequired();
                builder.Property(f => f.Street).HasMaxLength(100);
                builder.Property(f => f.Desc).HasMaxLength(500);
                builder.Property(f => f.UserID).IsRequired();

                builder.HasOne(f => f.User)
                .WithMany(f => f.Address)
                .HasForeignKey(f => f.UserID);


            }
        }

    }

}
