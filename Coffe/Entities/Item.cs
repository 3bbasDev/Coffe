using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Entities
{
    public class Item
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Count { get; set; }
        public string? Desc { get; set; }
        public string? Img { get; set; }
        public Guid? MerchantID { get; set; }
        public User? Merchent { get; set; }
        public ICollection<OrderItem>? Orders { get; set; }

        public class ItemConfigurations : IEntityTypeConfiguration<Item>
        {

            public void Configure(EntityTypeBuilder<Item> builder)
            {
                builder.Property(f => f.Id).ValueGeneratedOnAdd().IsRequired();
                builder.Property(f => f.Name).HasMaxLength(100);
                builder.Property(f => f.Price).IsRequired();
                builder.Property(f => f.Count).IsRequired();
                builder.Property(f => f.Desc).HasMaxLength(500);
                builder.Property(f => f.Img);
                builder.Property(f => f.MerchantID).IsRequired();

                builder.HasOne(f => f.Merchent)
                .WithMany(f => f.Item)
                .HasForeignKey(f => f.MerchantID);
            }
        }


    }

}