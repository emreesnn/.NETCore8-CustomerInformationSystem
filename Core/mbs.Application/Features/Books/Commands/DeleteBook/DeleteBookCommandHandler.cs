using AutoMapper;
using mbs.Application.Interfaces;
using mbs.Application.Services.BookServices;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommandRequest, Unit>
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public DeleteBookCommandHandler(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteBookCommandRequest request, CancellationToken cancellationToken)
        {
            Book book = mapper.Map<Book>(request);
            await bookService.DeleteAsync(book);
            return Unit.Value;
        }
    }
}
