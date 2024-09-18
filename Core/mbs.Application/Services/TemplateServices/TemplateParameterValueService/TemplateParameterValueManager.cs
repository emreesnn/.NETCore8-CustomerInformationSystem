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

namespace mbs.Application.Services.TemplateServices.TemplateParameterValueService
{
    public class TemplateParameterValueManager : ITemplateParameterValueService
    {
        private readonly IRepository<CustomerTemplateParameterValue> repository;
        private readonly BaseException<CustomerTemplateParameterValue> baseException;

        public TemplateParameterValueManager(IRepository<CustomerTemplateParameterValue> repository, BaseException<CustomerTemplateParameterValue> baseException)
        {
            this.repository = repository;
            this.baseException = baseException;
        }
        public async Task<CustomerTemplateParameterValue?> AddAsync(CustomerTemplateParameterValue data)
        {
            var createdEntity = await repository.CreateAsync(data);
            return createdEntity;
        }

        public async Task<CustomerTemplateParameterValue?> UpdateAsync(CustomerTemplateParameterValue data)
        {
            var entity = await repository.GetAsync(x => x.Id == data.Id);
            await baseException.DataMustNotBeNull(entity);

            entity.Value = data.Value;

            var updatedEntity = await repository.UpdateAsync(entity.Id, entity);
            return updatedEntity;
        }

        public async Task DeleteAsync(CustomerTemplateParameterValue data, bool permanent = false)
        {
            var entity = await repository.GetAsync(x => x.Id == data.Id);
            await baseException.DataMustNotBeNull(entity);
            await repository.DeleteAsync(data.Id, true);
        }

        public async Task<IList<CustomerTemplateParameterValue>?> GetAllAsync(Expression<Func<CustomerTemplateParameterValue, bool>> predicate = null, 
            Func<IQueryable<CustomerTemplateParameterValue>, IIncludableQueryable<CustomerTemplateParameterValue, object>>? include = null, 
            Func<IQueryable<CustomerTemplateParameterValue>, IOrderedQueryable<CustomerTemplateParameterValue>>? orderBy = null, bool withDeleted = false, 
            bool enableTracking = true, 
            CancellationToken cancellationToken = default)
        {
            var templateParameterValues = await repository.GetAllAsync(predicate, include, orderBy, withDeleted, enableTracking);
            return templateParameterValues;
        }

        public async Task<CustomerTemplateParameterValue?> GetAsync(Expression<Func<CustomerTemplateParameterValue, bool>> predicate = null, 
            Func<IQueryable<CustomerTemplateParameterValue>, IIncludableQueryable<CustomerTemplateParameterValue, object>>? include = null, bool withDeleted = false, 
            bool enableTracking = true, 
            CancellationToken cancellationToken = default)
        {
            CustomerTemplateParameterValue templateParameterValue = await repository.GetAsync(predicate, include, withDeleted, enableTracking);
            return templateParameterValue;
        }

        
    }
}
