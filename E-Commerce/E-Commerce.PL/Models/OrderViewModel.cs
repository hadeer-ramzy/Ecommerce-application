using E_Commerce.DAL.Entities;
using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.PL.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<int> ProductId { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
