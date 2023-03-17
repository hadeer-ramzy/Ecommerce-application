using E_Commerce.BLL.Interfaces;
using E_Commerce.DAL.Context;
using E_Commerce.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly eCommerceContext context;

        public ProductRepository(eCommerceContext context) : base(context)
        {
            this.context = context;
        }

        public  async Task<int> QuantityInStock(int? id)
        {
            return await context.Products.Where(p=>p.Id == id).Select(p => p.Quantity).FirstOrDefaultAsync();
        }
    }
}
