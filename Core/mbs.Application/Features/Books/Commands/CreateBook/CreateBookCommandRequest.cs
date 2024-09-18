using mbs.Application.Pipelines.Authorization;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandRequest : IRequest<CreateBookCommandResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int AuthorId { get; set; }
    }
}
