using mbs.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Books.Queries.GetBookById
{
    public class GetBookByIdQueryResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public AuthorDto Author { get; set; }
    }
}
