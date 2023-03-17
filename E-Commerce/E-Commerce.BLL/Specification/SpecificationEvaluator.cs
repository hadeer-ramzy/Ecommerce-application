using E_Commerce.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Specification
{
    public class SpecificationEvaluator<T> where T:BaseEntity
    {
        public static IQueryable<T> BuildQuery(IQueryable<T> baseQuery,ISpecification<T> specification)
        {
            var query = baseQuery;
            query=specification.IncludeThenIncludes.Aggregate(query,(start,include)=> include(start));
            return query;
        }
    }
}
