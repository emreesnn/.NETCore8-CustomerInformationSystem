using AutoMapper;
using mbs.Application.Features.Books.Queries.GetBookById;
using mbs.Application.Services.BookServices;
using mbs.Application.Services.CustomerServices;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQueryRequest, GetCustomerByIdQueryResponse>
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public GetCustomerByIdQueryHandler(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }
        public async Task<GetCustomerByIdQueryResponse> Handle(GetCustomerByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var customer = await customerService.GetAsync(predicate: c => c.Id == request.Id, include: x => x.Include(c => c.Orders));
            var response = mapper.Map<GetCustomerByIdQueryResponse>(customer);
            return response;
        }
    }
}
