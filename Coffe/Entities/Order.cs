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
        public Guid AddressId { get; set; }
        public Item? OrderItem { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public User? Customer { get; set; }
        public User? Delevery { get; set; }
        public Address? Address { get; set; }

        public ICollection<OrderItem>? Item { get; set; }

    }

}
