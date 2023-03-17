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
    public interface ISpecification<T> where T:BaseEntity
    {
        //public Expression<Func<T, bool>> Criteria { get; set; }
        //List<Expression<Func<T, object>>> Includes { get; set; }
        List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> IncludeThenIncludes { get; set; }
    }
}
