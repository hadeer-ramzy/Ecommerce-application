using E_Commerce.DAL.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        //public BaseSpecification()//get all
        //{
        //}

        //public Expression<Func<T, bool>> Criteria { get; set; }  //where
        //public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>(); //include
        

        public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> IncludeThenIncludes { get; set; }=new List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();
        //public void AddInclude(Expression<Func<T, object>> include)
        //{
        //    this.Includes.Add(include);
        //}
        public void AddThenInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>> Theninclude)
            => this.IncludeThenIncludes.Add(Theninclude);
    }
}
