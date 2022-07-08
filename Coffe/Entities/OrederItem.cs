using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Entities
{
    public class OrederItem
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public Item? Item { get; set; }
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string? Note { get; set; }
    }
}
