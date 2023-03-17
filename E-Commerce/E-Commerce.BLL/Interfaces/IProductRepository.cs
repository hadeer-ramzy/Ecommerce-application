using E_Commerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Interfaces
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<int> QuantityInStock(int? id);
    }
}
