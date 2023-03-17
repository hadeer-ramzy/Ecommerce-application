using E_Commerce.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Specification
{
    public class OrderSpecification : BaseSpecification<Order>
    {
        public OrderSpecification()
        {
            AddThenInclude(o => o.Include(r => r.ProductOrders).ThenInclude(r => r.Product));
            AddThenInclude(o => o.Include(e => e.Customer));
        }
    }
}
