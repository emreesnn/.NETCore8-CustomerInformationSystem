using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest<Unit>
    {
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
