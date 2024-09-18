using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Customers.Commands.AddTemplateToCustomer
{
    public class AddTemplateToCustomerCommandRequest : IRequest<Unit>
    {
        public int CustomerId { get; set; }
        public ICollection<int> TemplateIds { get; set; } = [];
    }
}
