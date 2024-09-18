using AutoMapper;
using mbs.Application.Features.TemplateParameters.Commands.CreateTemplateParameter;
using mbs.Application.Features.Templates.Commands.CreateTemplate;
using mbs.Application.Interfaces;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.TemplateParameters.Commands.CreateTempleParameter
{
    public class CreateTemplateParameterCommandHandler : IRequestHandler<CreateTemplateParameterCommandRequest, List<CreateTemplateParameterCommandResponse>>
    {
        private readonly IRepository<TemplateParameter> repository;
        private readonly IMapper mapper;

        public CreateTemplateParameterCommandHandler(IRepository<TemplateParameter> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<CreateTemplateParameterCommandResponse>> Handle(CreateTemplateParameterCommandRequest request, CancellationToken cancellationToken)
        {
            var templateParameters = request.ParameterName.Select(paramName => new TemplateParameter
            {
                ParameterName = paramName,
                TemplateId = request.TemplateId
            }).ToList();

            var entities = await repository.AddRangeAsync(templateParameters);
            var response = mapper.Map<List<CreateTemplateParameterCommandResponse>>(entities);
            return response;
        }
    }
}
