using AutoMapper;
using mbs.Application.DTOs;
using mbs.Application.Interfaces;
using mbs.Application.Pipelines.Authorization;
using mbs.Application.Services.BookServices;
using mbs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Books.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQueryRequest, IList<GetAllBooksQueryResponse>>

    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public GetAllBooksQueryHandler(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllBooksQueryResponse>> Handle(GetAllBooksQueryRequest request, CancellationToken cancellationToken)
        {
            var books = await bookService.GetAllAsync(include: x => x.Include(b => b.Author));

            var map = mapper.Map<IList<GetAllBooksQueryResponse>>(books);
            return map;

        }
    }
}
