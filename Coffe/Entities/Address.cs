using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public string? Stret { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
