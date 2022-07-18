using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Entities
{
    public class UserType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<User>? Users { get; set; }
    }
    public class UserTypeConfigurations : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.Property(f => f.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(f => f.Name).IsRequired().HasMaxLength(100);
        }
    }

}
