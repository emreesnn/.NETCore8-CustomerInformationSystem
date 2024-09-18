using AutoMapper;
using mbs.Application.Features.TemplateParameters.Commands.CreateTemplateParameter;
using mbs.Application.Interfaces;
using mbs.Application.Middlewares.Exceptions;
using mbs.Application.Services.TemplateServices.TemplateParameterService;
using mbs.Application.Services.TemplateServices.TemplateParameterValueService;
using mbs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Query;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mbs.Application.Services.TemplateServices
{
    public class TemplateManager : ITemplateService
    {
        private readonly IRepository<Template> repository;
        private readonly BaseException<Template> baseException;
        private readonly ITemplateParameterValueService templateParameterValueService;
        private readonly ITemplateParameterService templateParameterService;

        public TemplateManager(IRepository<Template> repository, 
            BaseException<Template> baseException, 
            ITemplateParameterValueService templateParameterValueService,
            ITemplateParameterService templateParameterService)
        {
            this.repository = repository;
            this.baseException = baseException;
            this.templateParameterValueService = templateParameterValueService;
            this.templateParameterService = templateParameterService;
        }

        public async Task<Template?> AddAsync(Template data)
        {
            //Fazladan boşlukları kaldırmak için
            string result = Regex.Replace(data.Sql, @"\s+", " ");
            data.Sql = result;
            var createdEntity = await repository.CreateAsync(data);
            return createdEntity;
        }
        public async Task<Template?> AddAllInOneAsync(Template data)
        {
            //Fazladan boşlukları kaldırmak için
            string result = Regex.Replace(data.Sql, @"\s+", " ");
            data.Sql = result;
            var createdEntity = await repository.CreateAsync(data);
            
            //Parametreleri sql'den ayıklama işlemi
            string pattern = @"@(\w+)";
            MatchCollection matches = Regex.Matches(data.Sql, pattern);
            if(matches is not null)
            {
                ICollection<TemplateParameter> templateParameters = new List<TemplateParameter>();
                foreach (Match match in matches)
                {
                    templateParameters.Add(new TemplateParameter()
                    {
                        ParameterName = match.Groups[1].Value,
                        TemplateId = createdEntity.Id,
                    });

                }
                var createdTemplateParameters = await templateParameterService.AddRangeAsync(templateParameters);
                createdEntity.Parameters = createdTemplateParameters;
            }
            return createdEntity;
            
        }

        public async Task<Template?> UpdateAsync(Template data)
        {
            var entity = await repository.GetAsync(x => x.Id == data.Id);
            await baseException.DataMustNotBeNull(entity);
            //Fazladan boşlukları kaldırmak için
            string result = Regex.Replace(data.Sql, @"\s+", " ");
            entity.Name = data.Name;
            entity.Sql = result;

            var updatedEntity = await repository.UpdateAsync(entity.Id, entity);
            return updatedEntity;
        }

        public async Task DeleteAsync(Template data, bool permanent = false)
        {
            var entity = await repository.GetAsync(x => x.Id == data.Id);
            await baseException.DataMustNotBeNull(entity);
            await repository.DeleteAsync(data.Id, true);
        }

        public async Task<IList<Template>?> GetAllAsync(Expression<Func<Template, bool>> predicate = null,
            Func<IQueryable<Template>, IIncludableQueryable<Template, object>>? include = null, Func<IQueryable<Template>,
                IOrderedQueryable<Template>>? orderBy = null, bool withDeleted = false,
            bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            var templates = await repository.GetAllAsync(predicate, include, orderBy, withDeleted, enableTracking);
            return templates;
        }

        public async Task<Template?> GetAsync(Expression<Func<Template, bool>> predicate = null, Func<IQueryable<Template>,
            IIncludableQueryable<Template, object>>? include = null, bool withDeleted = false,
            bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            Template template = await repository.GetAsync(predicate, include, withDeleted, enableTracking);
            return template;
        }

        public async Task<IEnumerable<ExpandoObject>> ExecuteTemplate(Template template, ICollection<TemplateParameter> parameters, int customerId)
        {
            foreach (var parameter in parameters)
            {
                CustomerTemplateParameterValue? value = await templateParameterValueService.
                    GetAsync(predicate: x => x.TemplateParameterId == parameter.Id && x.CustomerId == customerId);
                if (value == null) throw new BadRequestException("Bu müşteriye ait template bulunamadı.");
                string variableName = parameter.ParameterName;
                string pattern = $@"@{variableName}";
                string replacement = value.Value;
                string sql = Regex.Replace(template.Sql, pattern, replacement);
                template.Sql = sql;
            }


            IEnumerable<ExpandoObject> result = await repository.ExecuteSql(template.Sql);
            return result;
        }

    }
}
