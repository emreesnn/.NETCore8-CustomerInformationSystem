using AutoMapper;
using mbs.Application.Interfaces;
using mbs.Application.Services.BookServices;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommandRequest, CreateBookCommandResponse>
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public CreateBookCommandHandler(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }
        public async Task<CreateBookCommandResponse> Handle(CreateBookCommandRequest request, CancellationToken cancellationToken)
        {
            Book book = mapper.Map<Book>(request);
            var createdEntity = await bookService.AddAsync(book);
            var response = mapper.Map<CreateBookCommandResponse>(createdEntity);
            return response;
        }
    }
}
