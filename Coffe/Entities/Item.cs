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
        public string Name { get; set; }
        public string Price { get; set; }
        public string count { get; set; }
        public image img { get; set; }
        public Guid MerchantID { get; set; }
        public User User {get; set}

    }

}