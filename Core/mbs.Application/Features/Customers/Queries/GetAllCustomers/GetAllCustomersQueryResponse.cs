using mbs.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<OrderDto>? Orders { get; set; }
    }
}
