using mbs.Domain.Common;
using mbs.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Interfaces
{
    public interface IRepository<T> where T : EntityBase, new()
    {
        //Write
        Task<T> CreateAsync(T entity);
        Task<ICollection<T>> AddRangeAsync(ICollection<T> entities);
        Task<T> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id, bool permanent = false);

        //Read
        Task<T> GetAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = false);
        Task<IList<T>> GetAllAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool withDeleted = false,
            bool enableTracking = false);
        Task<IEnumerable<ExpandoObject>> ExecuteSql(string sql);

    }
}
