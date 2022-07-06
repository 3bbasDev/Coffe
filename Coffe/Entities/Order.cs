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
        public Item OrderItem {get; set}
        public User User {get; set}
        public Address Address {get; set}
        
    }

}
