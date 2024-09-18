using AutoMapper;
using mbs.Application.Features.Templates.Rules;
using mbs.Application.Services.TemplateServices;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace mbs.Application.Features.Templates.Commands.CreateTemplate
{
    public class CreateTemplateCommandHandler : IRequestHandler<CreateTemplateCommandRequest, CreateTemplateCommandResponse>
    {
        private readonly ITemplateService templateService;
        private readonly IMapper mapper;
        private readonly TemplateRules templateRules;

        public CreateTemplateCommandHandler(ITemplateService templateService, IMapper mapper, TemplateRules templateRules)
        {
            this.templateService = templateService;
            this.mapper = mapper;
            this.templateRules = templateRules;
        }
        public async Task<CreateTemplateCommandResponse> Handle(CreateTemplateCommandRequest request, CancellationToken cancellationToken)
        {     
            Template template = mapper.Map<Template>(request);
            await templateRules.TemplateNameMustBeUnique(template.Name);
            var entity = await templateService.AddAllInOneAsync(template);
            var response = mapper.Map<CreateTemplateCommandResponse>(entity);
            return response;
        }
    }
}
