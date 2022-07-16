using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public Guid UserTypeId { get; set; }
        public UserType? UserType { get; set; }
        public ICollection<Address>? Address { get; set; }
        public ICollection<Item>? Item { get; set; }
        public ICollection<Order>? OrderCustomer { get; set; }
        public ICollection<Order>? OrderDelever { get; set; }
    }

    public class UserConfigurations : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property( f => f.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property( f => f.FullName).IsRequired().HasMaxLength(100); 
            builder.Property( f => f.UserName).IsRequired().HasMaxLength(50);
            builder.Property( f => f.Password).IsRequired().HasMaxLength(50);
            builder.Property(f => f.UserTypeId).IsRequired();

            builder.HasOne(f => f.UserType)
                .WithMany(f => f.Users)
                .HasForeignKey(f => f.UserTypeId);
        }
    }

}
