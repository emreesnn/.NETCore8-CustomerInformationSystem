using AutoMapper;
using mbs.Application.Features.Books.Commands.CreateBook;
using mbs.Application.Interfaces;
using mbs.Application.Services.BookServices;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommandRequest, UpdateBookCommandResponse>
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public UpdateBookCommandHandler(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }

        public async Task<UpdateBookCommandResponse> Handle(UpdateBookCommandRequest request, CancellationToken cancellationToken)
        {
            var newBook = mapper.Map<Book>(request);
            var updatedEntity = await bookService.UpdateAsync(newBook);
            var response = mapper.Map<UpdateBookCommandResponse>(updatedEntity);
            return response;
        }

    }
}
