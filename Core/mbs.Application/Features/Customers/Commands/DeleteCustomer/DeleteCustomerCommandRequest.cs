using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
