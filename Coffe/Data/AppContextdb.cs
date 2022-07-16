using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffe.Entities;

namespace Coffe.Data
{
    public class AppContextdb : DbContext
    {
        public AppContextdb(DbContextOptions options) : base(options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
        }


        public DbSet<Address>? Addresses { get; set; }
        public DbSet<Item>? Items { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderItem>? OrederItems { get; set; }
        public DbSet<User>? Users { get; set; }

        public DbSet<UserType>? UserTypes { get; set; }
    }
}