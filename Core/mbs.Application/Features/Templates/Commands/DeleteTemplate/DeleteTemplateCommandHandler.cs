using AutoMapper;
using mbs.Application.Services.TemplateServices;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Templates.Commands.DeleteTemplate
{
    public class DeleteTemplateCommandHandler : IRequestHandler<DeleteTemplateCommandRequest, Unit>
    {
        private readonly ITemplateService templateService;
        private readonly IMapper mapper;

        public DeleteTemplateCommandHandler(ITemplateService templateService, IMapper mapper)
        {
            this.templateService = templateService;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteTemplateCommandRequest request, CancellationToken cancellationToken)
        {
            Template template = mapper.Map<Template>(request);
            await templateService.DeleteAsync(template);
            return Unit.Value;
        }
    }
}
