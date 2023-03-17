using E_Commerce.BLL.Specification;
using E_Commerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAllWithSpec(ISpecification<T> specification);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById (int? id);
        public Task<int> Add(T type);
        public Task<int> Update(T type);
        public Task<int> Delete(T type);
    }
}
