using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; }
        public Guid MerchantId { get; set; }
        public User? Merchant { get; set; }

        public ICollection<OrederItem>? Oreders { get; set; }
    }
}
