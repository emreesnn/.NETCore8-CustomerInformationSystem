using mbs.Application.Helpers.ExpandoHelper;
using mbs.Application.Interfaces;
using mbs.Domain.Common;
using mbs.Persistance.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Dynamic;
using System.Linq.Expressions;
using static Dapper.SqlMapper;

namespace mbs.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase, new()
    {
        private readonly AppDbContext dbContext;
        private DbSet<T> Table { get => dbContext.Set<T>(); }
        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<T> CreateAsync(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await Table.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;

        }

        public async Task<ICollection<T>> AddRangeAsync(ICollection<T> entities)
        {
            foreach (var entity in entities) { entity.CreatedDate = DateTime.UtcNow; }
            await Table.AddRangeAsync(entities);
            await dbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            await Task.Run(() => Table.Update(entity));
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id, bool permanent = false)
        {
            var entity = await Table.FindAsync(id);
            if (entity is null) return false;
            if (permanent is false) { entity.IsDeleted = true; }
            if (permanent is true) { await Task.Run(() => Table.Remove(entity)); }
            await dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<T> GetAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (withDeleted is false) queryable = queryable.Where(x => x.IsDeleted == false);
            if (predicate is not null) queryable = queryable.Where(predicate);
            var entity = await queryable.FirstOrDefaultAsync();
            return entity ?? null;
        }

        public async Task<IList<T>> GetAllAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool withDeleted = false,
            bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (withDeleted is false) queryable = queryable.Where(x => x.IsDeleted == false);
            if (orderBy is not null)
                return await orderBy(queryable).ToListAsync();
            return await queryable.ToListAsync();
        }

        public async Task<IEnumerable<ExpandoObject>> ExecuteSql(string sql)
        {
            using (var connection = dbContext.Database.GetDbConnection())
            {
                var result = await connection.QueryAsync(sql);
                IEnumerable<ExpandoObject> singleKeyValues = result.Select(x => (ExpandoObject)ExpandoHelper.ToExpandoObject(x));
                return singleKeyValues;

            }
        }

    }
}
