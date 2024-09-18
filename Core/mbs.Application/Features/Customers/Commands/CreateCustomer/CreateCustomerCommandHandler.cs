using AutoMapper;
using mbs.Application.Services.BookServices;
using mbs.Application.Services.CustomerServices;
using mbs.Application.Services.OrderServices;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mbs.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        private readonly ICustomerService customerService;
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public CreateCustomerCommandHandler(ICustomerService customerService, IOrderService orderService, IMapper mapper)
        {
            this.customerService = customerService;
            this.orderService = orderService;
            this.mapper = mapper;
        }
        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {   
            Customer customer = mapper.Map<Customer>(request);
            var createdEntity = await customerService.AddAsync(customer);
            var response = mapper.Map<CreateCustomerCommandResponse>(createdEntity);
            return response;
        }
    }
}
