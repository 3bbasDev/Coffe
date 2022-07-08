using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public Guid UserTypeId { get; set; }
        public UserType? UserType { get; set; }
        public ICollection<Item>? Items { get; set; }
        public ICollection<Address>? Addresses { get; set; }
    }

}
