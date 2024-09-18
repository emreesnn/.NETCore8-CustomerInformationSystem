using AutoMapper;
using mbs.Application.Interfaces;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.CustomerTemplateParameterValues.Commands.CreateCustomerTemplateParameterValue
{
    public class CreateCustomerTemplateParameterValueCommandHandler : IRequestHandler<CreateCustomerTemplateParameterValueCommandRequest, CreateCustomerTemplateParameterValueCommandResponse>
    {
        private readonly IRepository<CustomerTemplateParameterValue> repository;
        private readonly IMapper mapper;

        public CreateCustomerTemplateParameterValueCommandHandler(IRepository<CustomerTemplateParameterValue> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<CreateCustomerTemplateParameterValueCommandResponse> Handle(CreateCustomerTemplateParameterValueCommandRequest request, CancellationToken cancellationToken)
        {
            var data = mapper.Map<CustomerTemplateParameterValue>(request);
            var createdEntity = await repository.CreateAsync(data);
            var response = mapper.Map<CreateCustomerTemplateParameterValueCommandResponse>(createdEntity);
            return response;
        }
    }
}
