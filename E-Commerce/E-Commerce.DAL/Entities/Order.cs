using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Entities
{
    public class Order:BaseEntity
    {
        public int Id { get; set; } 
        public DateTime OrderDate { get; set; }= DateTime.Now;
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }=new HashSet<ProductOrder>();
    }
}
