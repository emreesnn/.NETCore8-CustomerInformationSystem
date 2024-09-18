using AutoMapper;
using mbs.Application.Features.Books.Queries.GetAllBooks;
using mbs.Application.Services.CustomerServices;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQueryRequest, IList<GetAllCustomersQueryResponse>>
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public GetAllCustomersQueryHandler(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllCustomersQueryResponse>> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
        {
            var customers = await customerService.GetAllAsync(include: x => x.Include(c => c.Orders));
            var response = mapper.Map<IList<GetAllCustomersQueryResponse>>(customers);
            return response;
        }

    }
}
