using AutoMapper;
using mbs.Application.Features.Customers.Commands.CreateCustomer;
using mbs.Application.Services.CustomerServices;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly ICustomerService customerService;

        public DeleteCustomerCommandHandler(IMapper mapper, ICustomerService customerService)
        {
            this.mapper = mapper;
            this.customerService = customerService;
        }
        public async Task<Unit> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            Customer customer = mapper.Map<Customer>(request);
            await customerService.DeleteAsync(customer);

            return Unit.Value;
        }
    }
}
