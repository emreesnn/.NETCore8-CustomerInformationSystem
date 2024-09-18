using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Customers.Queries.GetTemplateByCustomerId
{
    public class GetCustomerWithTemplatesQueryRequest : IRequest<GetCustomerWithTemplatesQueryResponse>
    {
        public int Id { get; set; }
    }
}
