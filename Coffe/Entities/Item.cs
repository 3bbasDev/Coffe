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


    }

}