using AutoMapper;
using mbs.Application.Services.TemplateServices;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Templates.Commands.UpdateTemplate
{
    public class UpdateTemplateCommandHandler : IRequestHandler<UpdateTemplateCommandRequest, UpdateTemplateCommandResponse>
    {
        private readonly ITemplateService templateService;
        private readonly IMapper mapper;

        public UpdateTemplateCommandHandler(ITemplateService templateService, IMapper mapper)
        {
            this.templateService = templateService;
            this.mapper = mapper;
        }
        public async Task<UpdateTemplateCommandResponse> Handle(UpdateTemplateCommandRequest request, CancellationToken cancellationToken)
        {
            Template template = mapper.Map<Template>(request);
            var updatedEntity = await templateService.UpdateAsync(template);
            var response = mapper.Map<UpdateTemplateCommandResponse>(updatedEntity);
            return response;
        }
    }
}
