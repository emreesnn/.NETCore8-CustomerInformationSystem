using mbs.Application.DTOs;
using mbs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<OrderDto>? Orders { get; set; }
    }
}
