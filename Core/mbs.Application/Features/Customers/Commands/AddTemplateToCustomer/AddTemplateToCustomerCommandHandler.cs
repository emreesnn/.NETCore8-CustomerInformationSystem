using mbs.Application.Services.CustomerServices;
using mbs.Application.Services.TemplateServices;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Customers.Commands.AddTemplateToCustomer
{
    public class AddTemplateToCustomerCommandHandler : IRequestHandler<AddTemplateToCustomerCommandRequest,Unit>
    {
        private readonly ICustomerService customerService;
        private readonly ITemplateService templateService;

        public AddTemplateToCustomerCommandHandler(ICustomerService customerService, ITemplateService templateService)
        {
            this.customerService = customerService;
            this.templateService = templateService;
        }

        public async Task<Unit> Handle(AddTemplateToCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var templates = await templateService.GetAllAsync(predicate: t => request.TemplateIds.Contains(t.Id));
            Customer customer = new()
            {
                Id = request.CustomerId,
                Templates = templates,
            };

            await customerService.UpdateAsync(customer);
            return Unit.Value;

        }
    }
}
