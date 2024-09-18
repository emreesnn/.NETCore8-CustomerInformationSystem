using MediatR;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Templates.Queries.ExecuteTemplate
{
    public class ExecuteTemplateQueryRequest : IRequest<IEnumerable<ExpandoObject>>
    {
        public int CustomerId { get; set; }
        public int TemplateId { get; set; }
    }
}
