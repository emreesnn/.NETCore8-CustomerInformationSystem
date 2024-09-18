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

namespace mbs.Application.Services.TemplateServices.TemplateParameterService
{
    public class TemplateParameterManager : ITemplateParameterService
    {
        private readonly IRepository<TemplateParameter> repository;
        private readonly BaseException<TemplateParameter> baseException;

        public TemplateParameterManager(IRepository<TemplateParameter> repository, BaseException<TemplateParameter> baseException)
        {
            this.repository = repository;
            this.baseException = baseException;
        }
        public async Task<TemplateParameter?> AddAsync(TemplateParameter data)
        {
            var createdEntity = await repository.CreateAsync(data);
            return createdEntity;
        }
        public async Task<ICollection<TemplateParameter>?> AddRangeAsync(ICollection<TemplateParameter> datas)
        {
            await repository.AddRangeAsync(datas);
            return datas;
        }
        public async Task<TemplateParameter?> UpdateAsync(TemplateParameter data)
        {
            var entity = await repository.GetAsync(x => x.Id == data.Id);
            await baseException.DataMustNotBeNull(entity);

            entity.ParameterName = data.ParameterName;
            entity.TemplateId = data.TemplateId;

            var updatedEntity = await repository.UpdateAsync(entity.Id, entity);
            return updatedEntity;
        }

        public async Task DeleteAsync(TemplateParameter data, bool permanent = false)
        {
            var entity = await repository.GetAsync(x => x.Id == data.Id);
            await baseException.DataMustNotBeNull(entity);
            await repository.DeleteAsync(data.Id, true);
        }

        public async Task<IList<TemplateParameter>?> GetAllAsync(Expression<Func<TemplateParameter, bool>> predicate = null, Func<IQueryable<TemplateParameter>, IIncludableQueryable<TemplateParameter, object>>? include = null, Func<IQueryable<TemplateParameter>, IOrderedQueryable<TemplateParameter>>? orderBy = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            var datas = await repository.GetAllAsync(predicate, include, orderBy, withDeleted, enableTracking);
            return datas;
        }

        public async Task<TemplateParameter?> GetAsync(Expression<Func<TemplateParameter, bool>> predicate = null, Func<IQueryable<TemplateParameter>, IIncludableQueryable<TemplateParameter, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            TemplateParameter templateParameter = await repository.GetAsync(predicate, include, withDeleted, enableTracking);
            return templateParameter;
        }

    }
}
