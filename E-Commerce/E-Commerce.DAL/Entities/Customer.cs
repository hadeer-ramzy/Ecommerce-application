using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Entities
{
    public class Customer:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } 
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
