using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Templates.Queries.GetAllTemplates
{
    public class GetAllTemplatesQueryRequest : IRequest<IList<GetAllTemplatesQueryResponse>>
    {
    }
}
