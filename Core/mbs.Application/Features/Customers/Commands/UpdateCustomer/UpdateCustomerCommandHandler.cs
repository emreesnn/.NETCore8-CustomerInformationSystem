using AutoMapper;
using mbs.Application.Services.CustomerServices;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public UpdateCustomerCommandHandler(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }
        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            //update or delete orders from customer when updating ?? its not functionality in this method
            //but we can add a new order for customer
            Customer customer = mapper.Map<Customer>(request);
            var updatedEntity = await customerService.UpdateAsync(customer);
            var response = mapper.Map< UpdateCustomerCommandResponse >(updatedEntity);
            return response;
        }
    }
}
