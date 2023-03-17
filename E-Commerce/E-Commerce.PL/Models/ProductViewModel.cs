using E_Commerce.DAL.Entities;
using System.Collections.Generic;

namespace E_Commerce.PL.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string ProductUser { get; set; }
    }
}
