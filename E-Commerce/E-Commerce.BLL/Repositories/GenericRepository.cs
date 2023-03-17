using E_Commerce.BLL.Interfaces;
using E_Commerce.BLL.Specification;
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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly eCommerceContext context;

        public GenericRepository(eCommerceContext context)
        {
            this.context = context;
        }

        public async Task<int> Add(T type)
        {
            context.Set<T>().Add(type);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(T type)
        {
            context.Set<T>().Remove(type);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithSpec(ISpecification<T> specification)
        {
            return await BuildQuery(context.Set<T>(), specification).ToListAsync();
        }
        private IQueryable<T> BuildQuery(IQueryable<T> BaseQuery, ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.BuildQuery(BaseQuery,specification);
        }
        public async Task<T> GetById(int? id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<int> Update(T type)
        {
            context.Set<T>().Update(type);
            return await context.SaveChangesAsync();
        }
    }
}
