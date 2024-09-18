using mbs.Application.DTOs;
using mbs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Books.Queries.GetAllBooks
{
    public class GetAllBooksQueryResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public AuthorDto Author { get; set; }
    }
}
