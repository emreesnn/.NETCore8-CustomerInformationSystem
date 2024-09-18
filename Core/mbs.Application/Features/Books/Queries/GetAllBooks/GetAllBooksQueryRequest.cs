using mbs.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Books.Queries.GetAllBooks
{
    public class GetAllBooksQueryRequest : IRequest<IList<GetAllBooksQueryResponse>>
    {
    }
}
