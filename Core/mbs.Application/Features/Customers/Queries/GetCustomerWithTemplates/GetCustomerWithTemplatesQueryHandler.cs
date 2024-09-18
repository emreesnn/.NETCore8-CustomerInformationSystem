using AutoMapper;
using mbs.Application.Services.CustomerServices;
using mbs.Application.Services.TemplateServices;
using mbs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Customers.Queries.GetTemplateByCustomerId
{
    public class GetCustomerWithTemplatesQueryHandler : IRequestHandler<GetCustomerWithTemplatesQueryRequest, GetCustomerWithTemplatesQueryResponse>
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public GetCustomerWithTemplatesQueryHandler(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }
        public async Task<GetCustomerWithTemplatesQueryResponse> Handle(GetCustomerWithTemplatesQueryRequest request, CancellationToken cancellationToken)
        {
            var customer = await customerService.GetAsync(predicate: c => c.Id == request.Id, include: x => x.Include(c => c.Templates));
            var response = mapper.Map<GetCustomerWithTemplatesQueryResponse>(customer);
            return response;
        }
    }
}
