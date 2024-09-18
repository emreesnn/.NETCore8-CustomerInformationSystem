using mbs.Application.Interfaces;
using mbs.Application.Middlewares.Exceptions;
using mbs.Application.Services.OrderServices;
using mbs.Application.Services.TemplateServices;
using mbs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mbs.Application.Services.CustomerServices
{
    public class CustomerManager : ICustomerService
    {
        private readonly IRepository<Customer> repository;
        private readonly IOrderService orderService;
        private readonly BaseException<Customer> baseException;

        public CustomerManager(IRepository<Customer> repository, IOrderService orderService, BaseException<Customer> baseException)
        {
            this.repository = repository;
            this.orderService = orderService;
            this.baseException = baseException;
        }

        public async Task<Customer?> AddAsync(Customer data)
        {
            var createdEntity = await repository.CreateAsync(data);
            return createdEntity;
        }

        public async Task<Customer?> UpdateAsync(Customer data)
        {
            var entity = await repository.GetAsync(x => x.Id == data.Id);
            await baseException.DataMustNotBeNull(entity);

            entity.Name = data.Name == null ? entity.Name : data.Name;
            entity.Templates = data.Templates;

            var updatedEntity = await repository.UpdateAsync(entity.Id, entity);
            return updatedEntity;
        }

        public async Task DeleteAsync(Customer data, bool permanent = false)
        {
            var entity = await repository.GetAsync(predicate: x => x.Id == data.Id, include: x => x.Include(c => c.Orders));
            if (entity.Orders is not null)
            {
                foreach (Order item in entity.Orders)
                {
                    await orderService.DeleteAsync(item);
                }
            }
            await baseException.DataMustNotBeNull(entity);
            await repository.DeleteAsync(data.Id);
        }

        public async Task<Customer?> GetAsync(
            Expression<Func<Customer, bool>> predicate = null,
            Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default)
        {
            var customer = await repository.GetAsync(predicate, include, withDeleted, enableTracking);
            await baseException.DataMustNotBeNull(customer);
            return customer;
        }

        public async Task<IList<Customer>?> GetAllAsync(Expression<Func<Customer, bool>> predicate = null, Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>? include = null, Func<IQueryable<Customer>, IOrderedQueryable<Customer>>? orderBy = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            var customers = await repository.GetAllAsync(predicate, include, orderBy, withDeleted, enableTracking);
            await baseException.DataListMustNotBeNull(customers);
            return customers;
        }
    }
}
