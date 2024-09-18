using mbs.Application.DTOs;
using mbs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Customers.Queries.GetTemplateByCustomerId
{
    public class GetCustomerWithTemplatesQueryResponse
    {
        public string Name { get; set; }
        public ICollection<TemplateDto>? Templates { get; set; }
    }
}
