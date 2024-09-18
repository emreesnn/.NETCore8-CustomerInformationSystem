using mbs.Application.Services.TemplateServices;
using mbs.Application.Services.TemplateServices.TemplateParameterService;
using mbs.Application.Services.TemplateServices.TemplateParameterValueService;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Templates.Queries.ExecuteTemplate
{
    public class ExecuteTemplateQueryHandler : IRequestHandler<ExecuteTemplateQueryRequest, IEnumerable<ExpandoObject>>
    {
        private readonly ITemplateService templateService;
        private readonly ITemplateParameterService templateParameterService;
        private readonly ITemplateParameterValueService templateParameterValueService;

        public ExecuteTemplateQueryHandler(ITemplateService templateService, ITemplateParameterService templateParameterService, ITemplateParameterValueService templateParameterValueService)
        {
            this.templateService = templateService;
            this.templateParameterService = templateParameterService;
            this.templateParameterValueService = templateParameterValueService;
        }
        public async Task<IEnumerable<ExpandoObject>> Handle(ExecuteTemplateQueryRequest request, CancellationToken cancellationToken)
        {
            ICollection<TemplateParameter>? templateParameter = await templateParameterService.GetAllAsync(predicate: x => x.TemplateId == request.TemplateId);
            
            Template? template = await templateService.GetAsync(predicate: x => x.Id == request.TemplateId);

            IEnumerable<ExpandoObject> result = await templateService.ExecuteTemplate(template, templateParameter, request.CustomerId);
            return result;
        }
    }
}
