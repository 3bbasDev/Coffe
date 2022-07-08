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
        public Guid CustomerId { get; set; }
        public User? Customer { get; set; }
        public Guid DelievaryId { get; set; }
        public User? Delievary { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreationDate { get; set; }
        public int Status { get; set; }
        public Guid AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<OrederItem>? Items { get; set; }
    }
}
