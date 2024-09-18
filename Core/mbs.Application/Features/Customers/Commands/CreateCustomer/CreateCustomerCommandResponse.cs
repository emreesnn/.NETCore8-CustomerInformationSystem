using mbs.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<OrderDto>? Orders { get; set; }
    }
}
