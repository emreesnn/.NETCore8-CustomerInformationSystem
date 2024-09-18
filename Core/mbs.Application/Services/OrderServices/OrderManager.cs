using mbs.Application.Interfaces;
using mbs.Application.Middlewares.Exceptions;
using mbs.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Services.OrderServices
{
    public class OrderManager : IOrderService
    {
        private readonly IRepository<Order> repository;
        private readonly BaseException<Order> baseException;

        public OrderManager(IRepository<Order> repository, BaseException<Order> baseException)
        {
            this.repository = repository;
            this.baseException = baseException;
        }
        public async Task<Order?> AddAsync(Order data)
        {
            var createdEntity = await repository.CreateAsync(data);
            return createdEntity;
            
        }

        public async Task DeleteAsync(Order data, bool permanent = false)
        {
            var entity = await repository.GetAsync(b => b.Id == data.Id);
            await baseException.DataMustNotBeNull(entity);
            await repository.DeleteAsync(data.Id, permanent);
        }

        public async Task<IList<Order>?> GetAllAsync(Expression<Func<Order, bool>> predicate = null, Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null, Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IList<Order> orders = await repository.GetAllAsync(predicate, include, orderBy, enableTracking);
            return orders;
        }

        public async Task<Order?> GetAsync(Expression<Func<Order, bool>> predicate = null, Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            Order order = await repository.GetAsync(predicate, include,enableTracking);
            return order;
        }

        public async Task<Order?> UpdateAsync(Order data)
        {
            var entity = await repository.GetAsync(b => b.Id == data.Id);
            await baseException.DataMustNotBeNull(entity);

            entity.Title = data.Title;
            entity.Desc = data.Desc;
            entity.CustomerId = data.CustomerId;

            var updatedEntity = await repository.UpdateAsync(entity.Id, entity);
            return updatedEntity;
        }
    }
}
